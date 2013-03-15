using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using AForge.Video.FFMPEG;

namespace CLEyeTester
{
  public class Writer : IDisposable
  {
    private readonly Action<RawBitmap> _bitmapProcessed;
    private VideoFileWriter _videoFileWriter;
    private readonly BlockingCollection<RawBitmap> _captureQueue = new BlockingCollection<RawBitmap>();
    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    private readonly CancellationToken _cancellationToken;

    public Writer(string fileName, int width, int height, int fps, Action<RawBitmap> bitmapProcessed)
    {
      _bitmapProcessed = bitmapProcessed;
      _videoFileWriter = new VideoFileWriter();
      _videoFileWriter.Open(fileName, width, height, fps, VideoCodec.MPEG4, width * height * fps); // a quarter of the raw size (if in color mode)
      _cancellationToken = _cancellationTokenSource.Token;
      Task.Factory.StartNew(Run, _cancellationTokenSource.Token, TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
    }

    private void Run()
    {
      while (!_cancellationToken.IsCancellationRequested)
      {
        try
        {
          var rawBitmap = _captureQueue.Take(_cancellationToken);
          _videoFileWriter.WriteVideoFrame(rawBitmap.Bitmap);
          _bitmapProcessed(rawBitmap);
        }
        catch (OperationCanceledException)
        {
          break;
        }
      }
    }

    public void Enqueue(RawBitmap bitmap)
    {
      _captureQueue.Add(bitmap);
    }

    public void Dispose()
    {
      if (_videoFileWriter == null)
        return;
      _videoFileWriter.Dispose();
      _videoFileWriter = null;
    }
  }
}
