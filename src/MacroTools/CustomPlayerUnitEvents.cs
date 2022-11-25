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
    public static string PlayerFinishesTraining => "PlayerFinishesTraining";

    /// <summary>
    /// A specific player deals damage with any of their units.
    /// </summary>
    public static string PlayerDealsDamage => "PlayerDealsDamage";
    
    static CustomPlayerUnitEvents()
    {
      PlayerUnitEvents.AddCustomEventFilter(EVENT_PLAYER_UNIT_TRAIN_FINISH,
        PlayerFinishesTraining,
        () => GetPlayerId(GetOwningPlayer(GetTrainedUnit())));
      
      PlayerUnitEvents.AddCustomEventFilter(EVENT_PLAYER_UNIT_DAMAGED,
        PlayerDealsDamage,
        () => GetPlayerId(GetOwningPlayer(GetEventDamageSource())));
    }
  }
}