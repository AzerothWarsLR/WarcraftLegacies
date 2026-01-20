using System.Linq;
using MacroTools.UnitTraits;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
///   Prevents the unit from casting abilities that aren't within range of a player-controlled hero.
/// </summary>
public sealed class InfiniteInfluence : UnitTrait, IEffectOnSpellCast
{
  /// <summary>
  /// How near a player-controlled hero the caster has to be.
  /// </summary>
  public required float Radius { get; init; }

  public void OnSpellCast()
  {
    var triggerUnit = @event.Unit;
    if (!IsWithinRangeOfAnyHero(triggerUnit.Owner, @event.SpellTargetX, @event.SpellTargetY))
    {
      triggerUnit.IssueOrder(ORDER_STOP);
    }
  }

  private bool IsWithinRangeOfAnyHero(player caster, float x, float y)
  {
    return GlobalGroup
      .EnumUnitsInRange(x, y, Radius)
      .Any(u => IsAlliedHero(caster, u));
  }

  private static bool IsAlliedHero(player caster, unit whichUnit)
  {
    return whichUnit.IsUnitType(unittype.Hero) && whichUnit.Owner == caster && whichUnit.Alive;
  }
}
