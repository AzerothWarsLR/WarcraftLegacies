using System;
using System.Collections.Generic;
using MacroTools.Setup;
using MacroTools.Spells;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>A unit with this ability gains attack damage for each enemy it kills, up to a limit set by the ability's level.</summary>
public sealed class FirelordsHunger
{
  private readonly Dictionary<unit, int> _kills = new();
  private readonly Dictionary<unit, int> _heroKills = new();
  private readonly Dictionary<unit, int> _applied = new();

  public required int AbilityTypeId { get; init; }
  public required int KillsPerDamage { get; init; }
  public required int DamagePerHeroKill { get; init; }
  public required LeveledAbilityField<int> MaximumDamage { get; init; }

  /// <summary>Starts listening for deaths.</summary>
  public void Register()
  {
    for (var playerId = 0; playerId < 28; playerId++)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDies, OnUnitDies, playerId);
    }
  }

  /// <summary>The bonus damage <paramref name="whichUnit"/> has gained so far.</summary>
  public int GetBonusDamage(unit whichUnit) => Count(_applied, whichUnit);

  private static int Count(Dictionary<unit, int> counter, unit whichUnit)
  {
    if (counter.TryGetValue(whichUnit, out var count))
    {
      return count;
    }

    return 0;
  }

  private void OnUnitDies()
  {
    var killer = @event.KillingUnit;
    if (killer == null)
    {
      return;
    }

    var level = killer.GetAbilityLevel(AbilityTypeId);
    var dying = @event.Unit;
    if (level == 0 || dying.IsUnitType(unittype.Structure) || dying.Owner.IsAlly(killer.Owner))
    {
      return;
    }

    var counter = dying.IsUnitType(unittype.Hero) ? _heroKills : _kills;
    var count = Count(counter, killer);
    counter[killer] = count + 1;

    Refresh(killer, level);
  }

  private void Refresh(unit whichUnit, int level)
  {
    var earned = Count(_kills, whichUnit) / KillsPerDamage + Count(_heroKills, whichUnit) * DamagePerHeroKill;
    var bonus = Math.Min(earned, MaximumDamage.GetValue(level));
    var applied = GetBonusDamage(whichUnit);
    if (bonus == applied)
    {
      return;
    }

    BlzSetUnitBaseDamage(whichUnit, BlzGetUnitBaseDamage(whichUnit, 0) + bonus - applied, 0);
    _applied[whichUnit] = bonus;
  }
}
