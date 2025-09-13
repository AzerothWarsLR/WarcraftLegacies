using System.Linq;
using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Utils;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace MacroTools.PassiveAbilities
{
  /// <summary>
  ///   Prevents the unit from casting abilities that aren't within range of a player-controlled hero.
  /// </summary>
  public sealed class InfiniteInfluence : PassiveAbility
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
        PlayerUnitEvents.Register(UnitTypeEvent.SpellCast, OnSpellCast, unitTypeId);
    }
    
    private void OnSpellCast()
    {
      var triggerUnit = GetTriggerUnit();
      if (!IsWithinRangeOfAnyHero(triggerUnit.OwningPlayer(), new Point(GetSpellTargetX(), GetSpellTargetY()))) 
        IssueImmediateOrder(triggerUnit, "stop");
    }

    private bool IsWithinRangeOfAnyHero(player caster, Point position)
    {
      return GlobalGroup
        .EnumUnitsInRange(position, Radius)
        .Any(x => IsAlliedHero(caster, x));
    }

    private static bool IsAlliedHero(player caster, unit whichUnit)
    {
      return whichUnit.IsType(UNIT_TYPE_HERO) && whichUnit.OwningPlayer() == caster && UnitAlive(whichUnit);
    }
  }
}