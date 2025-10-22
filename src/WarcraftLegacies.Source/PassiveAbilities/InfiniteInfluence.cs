using System.Linq;
using MacroTools.UnitTypeTraits;
using MacroTools.Utils;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.PassiveAbilities;

/// <summary>
///   Prevents the unit from casting abilities that aren't within range of a player-controlled hero.
/// </summary>
public sealed class InfiniteInfluence : UnitTypeTrait
{
  /// <summary>
  /// How near a player-controlled hero the caster has to be.
  /// </summary>
  public required float Radius { get; init; }

  public InfiniteInfluence(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    foreach (var unitTypeId in UnitTypeIds)
    {
      PlayerUnitEvents.Register(UnitTypeEvent.SpellCast, OnSpellCast, unitTypeId);
    }
  }

  private void OnSpellCast()
  {
    var triggerUnit = @event.Unit;
    if (!IsWithinRangeOfAnyHero(triggerUnit.Owner, new Point(@event.SpellTargetX, @event.SpellTargetY)))
    {
      triggerUnit.IssueOrder("stop");
    }
  }

  private bool IsWithinRangeOfAnyHero(player caster, Point position)
  {
    return GlobalGroup
      .EnumUnitsInRange(position, Radius)
      .Any(x => IsAlliedHero(caster, x));
  }

  private static bool IsAlliedHero(player caster, unit whichUnit)
  {
    return whichUnit.IsUnitType(unittype.Hero) && whichUnit.Owner == caster && whichUnit.Alive;
  }
}
