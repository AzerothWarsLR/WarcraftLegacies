using MacroTools.Setup;
using WCSharp.Effects;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Forsaken.Spells;

/// <summary>Units killed by a unit of a certain type have a chance to rise as minions that fight for its owner for a while.</summary>
public sealed class DarkMinionsOnKill
{
  public required int KillerTypeId { get; init; }
  public required int MinionTypeId { get; init; }
  public required int Chance { get; init; }
  public required float MinionDuration { get; init; }
  public required string RiseEffectPath { get; init; }

  /// <summary>Starts listening for deaths.</summary>
  public void Register()
  {
    for (var playerId = 0; playerId < 28; playerId++)
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerUnitDies, OnUnitDies, playerId);
    }
  }

  private void OnUnitDies()
  {
    var killer = @event.KillingUnit;
    if (killer == null || killer.UnitType != KillerTypeId)
    {
      return;
    }

    var dying = @event.Unit;
    if (dying.IsUnitType(unittype.Structure) || dying.IsUnitType(unittype.Mechanical) ||
        dying.IsUnitType(unittype.Summoned) || dying.IsUnitType(unittype.Hero) || dying.Owner.IsAlly(killer.Owner) ||
        GetRandomInt(1, 100) > Chance)
    {
      return;
    }

    var minion = unit.Create(killer.Owner, MinionTypeId, dying.X, dying.Y, dying.Facing);
    minion.ApplyTimedLife(0, MinionDuration);
    EffectSystem.Add(effect.Create(RiseEffectPath, dying.X, dying.Y), 1);
  }
}
