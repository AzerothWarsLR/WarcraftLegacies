using MacroTools.Extensions;
using MacroTools.Factions;
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
  /// A specific player starts training any unit. Fires the instant gold is deducted, before the unit exists.
  /// </summary>
  public static string PlayerStartsTraining => nameof(PlayerStartsTraining);

  /// <summary>
  /// A specific player starts constructing any structure. Fires the instant gold is deducted.
  /// </summary>
  public static string PlayerStartsConstruction => nameof(PlayerStartsConstruction);

  /// <summary>
  /// A specific player is dealing damage with any of their units. Fires pre-mitigation.
  /// <remarks>As this event uses <see cref="playerunitevent.Damaging"/>, it is guaranteed to fire before events
  /// that use <see cref="playerunitevent.Damaged"/>. Use this for damage modification, but do not check
  /// for damage thresholds as the damage event may not represent the final damage value. </remarks>
  /// </summary>
  public static string PlayerDealingDamage => nameof(PlayerDealingDamage);

  /// <summary>
  /// A specific player deals damage with any of their units. Fires post-mitigation.
  /// <remarks>As this event uses <see cref="playerunitevent.Damaged"/>, it is guaranteed to fire after events
  /// that use <see cref="playerunitevent.Damaging"/>. Do not modify the damage event in response to this, as it
  /// will invalidate preceding event responses that may have checked for particular damage thresholds.</remarks>
  /// </summary>
  public static string PlayerDealsDamage => nameof(PlayerDealsDamage);

  /// <summary>
  /// A specific player takes damage with any of their units.
  /// <remarks>As this event uses <see cref="playerunitevent.Damaged"/>, it is guaranteed to fire after events
  /// that use <see cref="playerunitevent.Damaging"/>. Do not modify the damage event in response to this, as it
  /// will invalidate preceding event responses that may have checked for particular damage thresholds.</remarks>
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
    PlayerUnitEvents.AddCustomEvent(PlayerStartsTraining, () => @event.Player.Id, playerunitevent.TrainStart);
    PlayerUnitEvents.AddCustomEvent(PlayerStartsConstruction, () => @event.Player.Id, playerunitevent.ConstructStart);
    PlayerUnitEvents.AddCustomEvent(PlayerDealingDamage, () => @event.DamageSource.Owner.Id, playerunitevent.Damaging);
    PlayerUnitEvents.AddCustomEvent(PlayerDealsDamage, () => @event.DamageSource.Owner.Id, playerunitevent.Damaged);
    PlayerUnitEvents.AddCustomEvent(PlayerTakesDamage, () => @event.Unit.Owner.Id, playerunitevent.Damaged);
    PlayerUnitEvents.AddCustomEvent(PlayerUnitDies, () => @event.Unit.Owner.Id, playerunitevent.Death);
    PlayerUnitEvents.AddCustomEvent(FactionUnitKills, () => @event.KillingUnit.Owner.GetPlayerData().Faction?.Id ?? -1, playerunitevent.Death);
    PlayerUnitEvents.AddCustomEvent(PlayerSpellEffect, () => @event.Unit.Owner.Id, playerunitevent.SpellEffect);
  }
}
