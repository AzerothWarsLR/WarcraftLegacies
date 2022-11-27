using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools
{
  /// <summary>
  /// Provides a set of custom player unit events for the <see cref="PlayerUnitEvent"/> system.
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
    /// A unit owned by a specific player dies.
    /// </summary>
    public static string PlayerUnitDies => nameof(PlayerUnitDies);
    
    static CustomPlayerUnitEvents()
    {
      PlayerUnitEvents.AddCustomEventFilter(EVENT_PLAYER_UNIT_TRAIN_FINISH,
        PlayerFinishesTraining,
        () => GetPlayerId(GetOwningPlayer(GetTrainedUnit())));
      
      PlayerUnitEvents.AddCustomEventFilter(EVENT_PLAYER_UNIT_DAMAGED,
        PlayerDealsDamage,
        () => GetPlayerId(GetOwningPlayer(GetEventDamageSource())));
      
      PlayerUnitEvents.AddCustomEventFilter(EVENT_PLAYER_UNIT_DEATH,
        PlayerUnitDies,
        () => GetPlayerId(GetOwningPlayer(GetTriggerUnit())));
    }
  }
}