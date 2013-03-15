using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLEye;

namespace CLEyeTester
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
      comboBox.DataSource = Enumerable.Range(0, Camera.CLEyeGetCameraCount()).Select(Camera.CLEyeGetCameraUUID).ToList();
      resolutionComboBox.SelectedValueChanged += ResolutionComboBoxOnSelectedValueChanged;
      resolutionComboBox.DataSource = Enum.GetValues(typeof(CLEyeCameraResolution));
      colorModeComboBox.DataSource = Enum.GetValues(typeof(CLEyeCameraColorMode));

      _parameterDatas =
        typeof(CLEyeCameraParameter)
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .Select(x => new AttributeData(x))
        .ToDictionary(x => x.Parameter, x => x);

      propertiesDataGridView.DataSource =
        Enum.GetValues(typeof(CLEyeCameraParameter))
            .Cast<CLEyeCameraParameter>()
            .Select(x => new DataGridParameter { Parameter = x, Range = string.Format("{0} - {1}", _parameterDatas[x].Range.Min, _parameterDatas[x].Range.Max), Value = _parameterDatas[x].DefaultValue }).ToList();
      propertiesDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
      propertiesDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      propertiesDataGridView.Columns[1].ReadOnly = true;
      propertiesDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      propertiesDataGridView.Columns[2].ReadOnly = true;
      propertiesDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      propertiesDataGridView.CellValidating += PropertiesDataGridViewOnCellValidating;
    }

    private void PropertiesDataGridViewOnCellValidating(object sender, DataGridViewCellValidatingEventArgs args)
    {
      if (args.ColumnIndex != 3) return;
      var row = propertiesDataGridView.Rows[args.RowIndex];
      var parameter = (CLEyeCameraParameter)row.Cells[1].Value;
      var range = _parameterDatas[parameter].Range;
      int formattedValue;
      if (!int.TryParse(args.FormattedValue.ToString(), out formattedValue))
      {
        args.Cancel = true;
      }
      else if (formattedValue > range.Max || formattedValue < range.Min)
      {
        row.Cells[3].ErrorText = "Invalid range!";
      }
      else
      {
        row.Cells[3].ErrorText = string.Empty;
      }
    }

    private void ResolutionComboBoxOnSelectedValueChanged(object sender, EventArgs eventArgs)
    {
      var resolution = (CLEyeCameraResolution)resolutionComboBox.SelectedItem;
      switch (resolution)
      {
        case CLEyeCameraResolution.CleyeQvga:
          fpsComboBox.DataSource = new[] { 15, 30, 60, 75, 100, 125 };
          fpsComboBox.SelectedIndex = 1;
          break;
        case CLEyeCameraResolution.CleyeVga:
          fpsComboBox.DataSource = new[] { 15, 30, 40, 50, 60, 75 };
          fpsComboBox.SelectedIndex = 1;
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private CancellationTokenSource _cancellationTokenSource;
    private Camera _camera;
    private bool _led;
    private readonly Dictionary<CLEyeCameraParameter, AttributeData> _parameterDatas;

    private void StartButtonClick(object sender, EventArgs e)
    {
      if (_cancellationTokenSource != null) return;
      var cameraUuid = (Guid)comboBox.SelectedItem;
      var resolution = (CLEyeCameraResolution)resolutionComboBox.SelectedItem;
      var colorMode = (CLEyeCameraColorMode)colorModeComboBox.SelectedItem;
      var isOutputEnabled = outputCheckBox.Checked;
      var fps = (int)fpsComboBox.SelectedItem;
      var selectedParameters = ((IEnumerable<DataGridParameter>)propertiesDataGridView.DataSource)
        .Where(x => x.Selected)
        .ToDictionary(x => x.Parameter, x => x.Value);
      _cancellationTokenSource = new CancellationTokenSource();

      var token = _cancellationTokenSource.Token;
      token.Register(() =>
      {
        _cancellationTokenSource = null;
        _camera = null;
      });

      var unusedBitmaps = new BlockingCollection<RawBitmap>();
      var displayBitmap = new Display(pictureBox, unusedBitmaps.Add);

      Task.Factory.StartNew(() =>
      {
        _camera = new Camera();
        
        using (_camera)
        {
          _camera.Open(cameraUuid, colorMode, resolution, fps, selectedParameters);
          var res = resolution == CLEyeCameraResolution.CleyeVga ? new { w = 640, h = 480 } : new { w = 320, h = 240 };

          for (int i = 0; i < 8; i++)
          {
            IntPtr p;
            var bitmap = _camera.CreateBitmap(res.w, res.h, out p, colorMode);
            unusedBitmaps.Add(new RawBitmap(bitmap, p));
          }

          
          Writer writer = null;
          if (isOutputEnabled)
          {
            var fileName = string.Format(outputTextBox.Text, DateTime.Now);
            writer = new Writer(fileName, res.w, res.h, fps, unusedBitmaps.Add);
          }
          var start = DateTime.Now;
          while (!token.IsCancellationRequested)
          {
            var rawBitmap = unusedBitmaps.Take(token);
            if(!_camera.Capture(rawBitmap.IntPtr))
              continue;

            if (writer != null)
            {
              writer.Enqueue(rawBitmap);
            }

            if ((DateTime.Now - start).TotalMilliseconds > 40) // 25 fps
            {
              displayBitmap.Enqueue(rawBitmap);
            }
          }
        }
      }, token, TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
    }

    private void StopButtonClick(object sender, EventArgs e)
    {
      if (_cancellationTokenSource == null) return;
      _cancellationTokenSource.Cancel();
    }

    private void LEDButtonClick(object sender, EventArgs e)
    {
      if (_camera == null) return;
      _led = !_led;
      _camera.LED(_led);
    }
  }

  public class DataGridParameter
  {
// ReSharper disable LocalizableElement
    [DisplayName("x")]
    public bool Selected { get; set; }
    [DisplayName("Parameter")]
    public CLEyeCameraParameter Parameter { get; set; }
    [DisplayName("Range")]
    public string Range { get; set; }
    [DisplayName("Value")]
    public int Value { get; set; }
// ReSharper restore LocalizableElement
  }

  public class AttributeData
  {
    public AttributeData(FieldInfo x)
    {
      Range = x.GetCustomAttributes(typeof(ParameterRangeAttribute)).Cast<ParameterRangeAttribute>().Single();
      Parameter = (CLEyeCameraParameter)x.GetValue(null);
      DefaultValue = Range.Min == 0 && Range.Max == 1 ? 1 : 0;
    }

    public ParameterRangeAttribute Range { get; set; }
    public CLEyeCameraParameter Parameter { get; set; }
    public int DefaultValue { get; set; }
  }

  public class RawBitmap
  {
    public RawBitmap(Bitmap bitmap, IntPtr intPtr)
    {
      Bitmap = bitmap;
      IntPtr = intPtr;
    }

    public Bitmap Bitmap { get; private set; }
    public IntPtr IntPtr { get; private set; }
  }
}
