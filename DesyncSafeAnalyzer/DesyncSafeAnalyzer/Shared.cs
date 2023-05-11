using System.Collections.Generic;
using System.Linq;
using DesyncSafeAnalyzer.Tools;
using Microsoft.CodeAnalysis;

namespace DesyncSafeAnalyzer
{
  public static class Shared
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
      "GetPlayerId",
      "FourCC",
      "BlzFrameSetVisible"
    };

    private static readonly List<string> SafeDotNetNatives = new List<string>
    {
      "ElementAt",
      "Contains",
      "TryGetValue",
      "First"
    };
    
    /// <summary>
    /// True if the method can be safely called nonsynchronously with no chance of causing desynchronizations.
    /// </summary>
    public static bool IsMethodDesyncSafe(IMethodSymbol method)
    {
      var methodAttributes = method.GetAttributes();
      return SafeWc3Natives.Contains(method.Name) || SafeDotNetNatives.Contains(method.Name) ||
             methodAttributes.Any(attribute => attribute.AttributeClass.Name == nameof(DesyncSafeAttribute));
    }

    /// <summary>
    /// Returns true if the method should be restricted to only allowing access to desync-safe methods and properties.
    /// </summary>
    public static bool IsProtectedMethod(string methodName) =>
      methodName == "InvokeForClient" || methodName == "InvokeForClients";
  }
}