using System.Collections.Generic;
using CLEye;

namespace CLEyeTester
{
  public class CameraSettings
  {
    public CameraSettings()
    {
      Parameters = new Dictionary<CLEyeCameraParameter, int>();
    }
    public CLEyeCameraColorMode ColorMode { get; set; }
    public CLEyeCameraResolution Resolution { get; set; }
    public Dictionary<CLEyeCameraParameter, int> Parameters { get; private set; }
  }
  // QVGA 
  // VGA  
}
