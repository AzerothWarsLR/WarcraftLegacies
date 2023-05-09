using System.Collections.Generic;

namespace DesyncSafeAnalyzer
{
  
  public static class DesyncSafeNatives
  {
    private static readonly List<string> SafeWc3Natives = new List<string>
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
      "CreateMinimapIcon",
      "SkinManagerGetLocalPath",
      "QuestSetEnabled",
      "ClearTextMessages",
      "GetPlayerId"
    };

    private static readonly List<string> SafeDotNetNatives = new List<string>
    {
      "ElementAt",
      "Contains",
      "TryGetValue"
    };
    
    /// <summary>
    /// Returns true if the provided native function name is desync safe.
    /// </summary>
    public static bool IsSafe(string functionName) => SafeWc3Natives.Contains(functionName) || SafeDotNetNatives.Contains(functionName);
  }
}