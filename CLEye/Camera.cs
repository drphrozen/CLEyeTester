using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace CLEye
{
  public class Camera : IDisposable
  {
    #region [ CLEyeMulticam Imports ]
    [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int CLEyeGetCameraCount();
    [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern Guid CLEyeGetCameraUUID(int camId);

    [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr CLEyeCreateCamera(Guid camUUID, CLEyeCameraColorMode mode, CLEyeCameraResolution res, float frameRate);
    [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CLEyeDestroyCamera(IntPtr camera);
    [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CLEyeCameraStart(IntPtr camera);
    [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CLEyeCameraStop(IntPtr camera);
    [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CLEyeCameraLED(IntPtr camera, bool on);
    [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CLEyeSetCameraParameter(IntPtr camera, CLEyeCameraParameter param, int value);
    [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int CLEyeGetCameraParameter(IntPtr camera, CLEyeCameraParameter param);
    [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CLEyeCameraGetFrameDimensions(IntPtr camera, ref int width, ref int height);
    [DllImport("CLEyeMulticam.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern bool CLEyeCameraGetFrame(IntPtr camera, IntPtr pData, int waitTimeout);
    #endregion

    [DllImport("kernel32.dll")]
    static extern void RtlZeroMemory(IntPtr dst, int length);

    #region [ Variables ]
    private IntPtr _camera = IntPtr.Zero;
    private List<IntPtr> _bitmaps = new List<IntPtr>(16);
    #endregion

    public void Open(int cameraId, CLEyeCameraColorMode colorMode, CLEyeCameraResolution resolution, float fps)
    {
      Open(CLEyeGetCameraUUID(cameraId), colorMode, resolution, fps);
    }

    private bool IsIndexed(CLEyeCameraColorMode colorMode)
    {
      switch (colorMode)
      {
        case CLEyeCameraColorMode.CleyeMonoProcessed:
          return true;
        case CLEyeCameraColorMode.CleyeColorProcessed:
          return false;
        case CLEyeCameraColorMode.CleyeMonoRaw:
          return true;
        case CLEyeCameraColorMode.CleyeColorRaw:
          return false;
        case CLEyeCameraColorMode.CleyeBayerRaw:
          return true;
        default:
          throw new ArgumentOutOfRangeException("colorMode");
      }
    }

    public void Open(Guid uuid, CLEyeCameraColorMode colorMode, CLEyeCameraResolution resolution, float fps, IDictionary<CLEyeCameraParameter, int> parameters = null)
    {
      if (_camera != IntPtr.Zero) return;
      int w = 0, h = 0;
      _camera = CLEyeCreateCamera(uuid, colorMode, resolution, fps);
      if (_camera == IntPtr.Zero) return;
      CLEyeCameraGetFrameDimensions(_camera, ref w, ref h);

      foreach (var parameter in parameters ?? new Dictionary<CLEyeCameraParameter, int>())
      {
        CLEyeSetCameraParameter(_camera, parameter.Key, parameter.Value);
      }

      CLEyeCameraStart(_camera);
    }

    public void LED(bool on)
    {
      if (_camera == IntPtr.Zero) return;
      CLEyeCameraLED(_camera, on);
    }

    public Bitmap CreateBitmap(int w, int h, out IntPtr ptr, CLEyeCameraColorMode colorMode)
    {
      var result = IsIndexed(colorMode)
        ? CreateGrayscaleBitmap(w, h, out ptr)
        : CreateColorBitmap(w, h, out ptr);
      _bitmaps.Add(ptr);
      return result;
    }

    public Bitmap CreateGrayscaleBitmap(int w, int h, out IntPtr ptr)
    {
      // allocate bitmap memory
      ptr = Marshal.AllocHGlobal(w * h);
      RtlZeroMemory(ptr, w * h);

      // create bitmap object
      var bmpGraph = new Bitmap(w, h, w, PixelFormat.Format8bppIndexed, ptr);

      // setup gray-scale palette
      var grayPalette = bmpGraph.Palette;
      for (var i = 0; i < grayPalette.Entries.Length; i++)
        grayPalette.Entries[i] = Color.FromArgb(i, i, i);
      bmpGraph.Palette = grayPalette;

      // set bitmap to the picture box
      return bmpGraph;
    }
    public Bitmap CreateColorBitmap(int w, int h, out IntPtr ptr)
    {
      // allocate bitmap memory
      ptr = Marshal.AllocHGlobal(w * h * 4);
      RtlZeroMemory(ptr, w * h * 4);

      // create bitmap object
      var bmpGraph = new Bitmap(w, h, w * 4, PixelFormat.Format32bppRgb, ptr);

      // set bitmap to the picture box
      return bmpGraph;
    }

    public bool Capture(IntPtr ptr)
    {
      return _camera != IntPtr.Zero && CLEyeCameraGetFrame(_camera, ptr, 500);
    }

    public void Stop()
    {
      if (_camera == IntPtr.Zero) return;
      CLEyeCameraStop(_camera);
      CLEyeDestroyCamera(_camera);
      foreach (var bitmap in _bitmaps)
      {
        Marshal.FreeHGlobal(bitmap);
      }
      _bitmaps.Clear();
      _camera = IntPtr.Zero;
    }

    public void Dispose()
    {
      Stop();
    }
  }
}