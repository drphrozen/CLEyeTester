using System;

namespace CLEye
{
  public enum CLEyeCameraParameter
  {
    /// <summary>
    /// camera sensor parameters
    /// [false, true]
    /// </summary>
    [ParameterRange(0, 1)]
    CleyeAutoGain,
    /// <summary>[0, 79]</summary>
    [ParameterRange(0, 79)]
    CleyeGain,
    /// <summary>[false, true]</summary>
    [ParameterRange(0, 1)]
    CleyeAutoExposure,
    /// <summary>[0, 511]</summary>
    [ParameterRange(0, 511)]
    CleyeExposure,
    /// <summary>[false, true]</summary>
    [ParameterRange(0, 1)]
    CleyeAutoWhitebalance,
    /// <summary>[0, 255]</summary>
    [ParameterRange(0, 255)]
    CleyeWhitebalanceRed,
    /// <summary>[0, 255]</summary>
    [ParameterRange(0, 255)]
    CleyeWhitebalanceGreen,
    /// <summary>[0, 255]</summary>
    [ParameterRange(0, 255)]
    CleyeWhitebalanceBlue,
    /// <summary>
    /// camera linear transform parameters
    /// [false, true]
    /// </summary>
    [ParameterRange(0, 1)]
    CleyeHflip,
    /// <summary>[false, true]</summary>
    [ParameterRange(0, 1)]
    CleyeVflip,
    /// <summary>[-500, 500]</summary>
    [ParameterRange(-500, 500)]
    CleyeHkeystone,
    /// <summary>[-500, 500]</summary>
    [ParameterRange(-500, 500)]
    CleyeVkeystone,
    /// <summary>[-500, 500]</summary>
    [ParameterRange(-500, 500)]
    CleyeXoffset,
    /// <summary>[-500, 500]</summary>
    [ParameterRange(-500, 500)]
    CleyeYoffset,
    /// <summary>[-500, 500]</summary>
    [ParameterRange(-500, 500)]
    CleyeRotation,
    /// <summary>[-500, 500]</summary>
    [ParameterRange(-500, 500)]
    CleyeZoom,
    /// <summary>
    /// camera non-linear transform parameters
    /// [-500, 500]
    /// </summary>
    [ParameterRange(-500, 500)]
    CleyeLenscorrection1,
    /// <summary>[-500, 500]</summary>
    [ParameterRange(-500, 500)]
    CleyeLenscorrection2,
    /// <summary>[-500, 500]</summary>
    [ParameterRange(-500, 500)]
    CleyeLenscorrection3,
    /// <summary>[-500, 500]</summary>
    [ParameterRange(-500, 500)]
    CleyeLensbrightness,
  };

  [AttributeUsage(AttributeTargets.Field)]
  public class ParameterRangeAttribute : Attribute
  {
    public ParameterRangeAttribute(int min, int max)
    {
      Max = max;
      Min = min;
    }

    public int Max { get; private set; }
    public int Min { get; private set; }
  }
}