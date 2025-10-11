using MacroTools.Extensions;
using MacroTools.Instances;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.Slipstream;

internal static class SlipstreamSpellHelper
{
  public static bool IsPointValidTarget(unit caster, Point targetPoint)
  {
    return IsPointValidTarget(caster, targetPoint, targetPoint);
  }

  public static bool IsPointValidTarget(unit caster, Point targetPoint, Point targetLocation)
  {
    var casterPosition = caster.GetPosition();
    var isPathable = pathingtype.Walkability.GetPathable(targetPoint.X, targetPoint.Y);
    var isWithinRange = Util.DistanceBetweenPoints(casterPosition.X, casterPosition.Y, targetLocation.X, targetLocation.Y) < 500;
    var isSameInstance = InstanceSystem.GetPointInstance(casterPosition) == InstanceSystem.GetPointInstance(targetPoint);

    return !isPathable && !isWithinRange && isSameInstance;
  }
}
