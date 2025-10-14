using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Events;

namespace MacroTools.Setup;

/// <summary>
/// Provides a set of custom player unit events for the <see cref="PlayerUnitEvents"/> system.
/// </summary>
public static class CustomPlayerUnitEvents
{
  /// <summary>
  /// A specific player finishes training any unit.
  /// </summary>
  public static string PlayerFinishesTraining => nameof(PlayerFinishesTraining);

  /// <summary>
  /// A specific player deals damage with any of their units.
  /// </summary>
  public static string PlayerDealsDamage => nameof(PlayerDealsDamage);

  /// <summary>
  /// A specific player takes damage with any of their units.
  /// </summary>
  public static string PlayerTakesDamage => nameof(PlayerTakesDamage);

  /// <summary>
  /// A unit owned by a specific player dies.
  /// </summary>
  public static string PlayerUnitDies => nameof(PlayerUnitDies);

  /// <summary>
  /// A unit owned by a specific <see cref="Faction"/> kills a unit.
  /// </summary>
  public static string FactionUnitKills => nameof(FactionUnitKills);

  /// <summary>
  /// A unit owned by a specific player casts any spell.
  /// </summary>
  public static string PlayerSpellEffect => nameof(PlayerSpellEffect);

  static CustomPlayerUnitEvents()
  {
    PlayerUnitEvents.AddCustomEvent(PlayerFinishesTraining, () => @event.TrainedUnit.Owner.Id, playerunitevent.TrainFinish);
    PlayerUnitEvents.AddCustomEvent(PlayerDealsDamage, () => @event.DamageSource.Owner.Id, playerunitevent.Damaged);
    PlayerUnitEvents.AddCustomEvent(PlayerTakesDamage, () => @event.Unit.Owner.Id, playerunitevent.Damaged);
    PlayerUnitEvents.AddCustomEvent(PlayerUnitDies, () => @event.Unit.Owner.Id, playerunitevent.Death);
    PlayerUnitEvents.AddCustomEvent(FactionUnitKills, () => @event.KillingUnit.Owner.GetPlayerData().Faction.Id, playerunitevent.Death);
    PlayerUnitEvents.AddCustomEvent(PlayerSpellEffect, () => @event.Unit.Owner.Id, playerunitevent.SpellEffect);
  }
}
