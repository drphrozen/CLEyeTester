using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLEyeTester
{
  public class Display
  {
    private readonly PictureBox _pictureBox;
    private readonly Action<RawBitmap> _bitmapProcessed;
    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    private readonly CancellationToken _cancellationToken;
    private readonly BlockingCollection<RawBitmap> _captureQueue = new BlockingCollection<RawBitmap>();

    public Display(PictureBox pictureBox, Action<RawBitmap> bitmapProcessed)
    {
      _pictureBox = pictureBox;
      _bitmapProcessed = bitmapProcessed;
      _cancellationToken = _cancellationTokenSource.Token;
      Task.Factory.StartNew(Run, _cancellationTokenSource.Token, TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void Run()
    {
      while (!_cancellationTokenSource.IsCancellationRequested)
      {
        try
        {
          var rawBitmap = _captureQueue.Take(_cancellationToken);
          _pictureBox.Image = rawBitmap.Bitmap;
          _bitmapProcessed(rawBitmap);
        }
        catch (OperationCanceledException)
        {
          break;
        }
      }
    }

    public void Enqueue(RawBitmap rawBitmap)
    {
      _captureQueue.Add(rawBitmap);
    }

  }
}
