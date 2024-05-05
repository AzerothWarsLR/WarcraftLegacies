using System.Collections.Generic;
using War3Api.Object.Enums;

namespace Launcher.Extensions
{
  public static class TargetExtensions
  {
    public static bool CanTargetGround(this List<Target> targets)
    {
      if (targets.Contains(Target.Ground))
        return true;

      return !targets.Contains(Target.Air);
    }
    
    public static bool CanTargetAir(this List<Target> targets)
    {
      if (targets.Contains(Target.Air))
        return true;

      return !targets.Contains(Target.Ground);
    }
  }
}