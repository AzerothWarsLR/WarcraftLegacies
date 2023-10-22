using MacroTools.Extensions;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.DummyCasters
{
  /// <summary>
  /// Provides methods for casting abilities through a dummy unit.
  /// </summary>
  public static class DummyCast
  {
    /// <summary>
    /// A filter that can be applied to dummy casts so that the casts are only performed on particular targets.
    /// </summary>
    public delegate bool CastFilter(unit caster, unit target);

    /// <summary>
    /// Causes the specified spell to be channeled at a particular point.
    /// </summary>
    public static void ChannelOnPoint(unit caster, int abilityId, string orderId, int level, Point targetPoint, float duration)
    {
      CreateUnit(GetOwningPlayer(caster), DummyCasterManager.UnitTypeId, targetPoint.X, targetPoint.Y, 0)
        .AddAbility(abilityId)
        .SetAbilityLevel(abilityId, level)
        .IssueOrder(orderId)
        .SetTimedLife(duration);
    }

    /// <summary>
    /// Causes the specified spell to be channeled at the caster's point.
    /// </summary>
    public static void ChannelAtCaster(unit caster, int abilityId, string orderId, int level, float duration)
    {
      CreateUnit(GetOwningPlayer(caster), DummyCasterManager.UnitTypeId, caster.GetPosition().X, caster.GetPosition().Y, 0)
        .AddAbility(abilityId)
        .SetAbilityLevel(abilityId, level)
        .IssueOrder(orderId)
        .SetTimedLife(duration);
    }
  }
}