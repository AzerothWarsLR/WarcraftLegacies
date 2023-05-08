using System.Collections.Generic;

namespace DesyncSafeAnalyzer
{
  
  public static class DesyncSafeNatives
  {
    private static readonly List<string> SafeFunctions = new List<string>
    {
      "BlzSetSpecialEffectColor",
      "BlzSetSpecialEffectColorByPlayer",
      "StartSound",
      "PingMinimap",
      "SetCameraField",
      "GetRectMinX",
      "GetRectMinY",
      "GetRectMaxX",
      "GetRectMaxY",
      "SetCameraBounds",
      "BlzChangeMinimapTerrainTex",
      "CameraSetupApplyForceDuration",
      "SetMinimapIconVisible",
      "GetUnitX",
      "GetUnitY",
      "GetItemX",
      "GetItemY",
      "ElementAt",
      "GetRandomInt",
      "Remove",
      "CreateMinimapIcon",
      "SkinManagerGetLocalPath",
      "QuestSetEnabled",
      "ClearTextMessages"
    };
    
    /// <summary>
    /// Returns true if the provided native function name is desync safe.
    /// </summary>
    public static bool IsSafe(string nativeFunctionName) => SafeFunctions.Contains(nativeFunctionName);
  }
}