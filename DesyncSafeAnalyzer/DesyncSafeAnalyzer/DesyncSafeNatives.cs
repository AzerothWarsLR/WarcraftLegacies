using System.Collections.Generic;

namespace DesyncSafeAnalyzer
{
  
  public static class DesyncSafeNatives
  {
    private static readonly List<string> SafeFunctions = new List<string>
    {
      "BlzSetSpecialEffectColor",
      "BlzSetSpecialEffectColorByPlayer",
      "StartSound"
    };
    
    /// <summary>
    /// Returns true if the provided native function name is desync safe.
    /// </summary>
    public static bool IsSafe(string nativeFunctionName) => SafeFunctions.Contains(nativeFunctionName);
  }
}