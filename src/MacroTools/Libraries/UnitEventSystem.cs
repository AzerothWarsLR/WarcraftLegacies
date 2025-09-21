using System.Collections.Generic;

namespace MacroTools.Libraries;

/// <summary>
/// Static unit event system that provides unit death and damage event listeners.
/// </summary>
public static class UnitEventSystem
{
  // Stores the mapping between unit IDs and death event callbacks
  private static readonly Dictionary<int, System.Action> _unitDeathCallbacks = new Dictionary<int, System.Action>();

  // Static constructor that initializes the system automatically
  static UnitEventSystem()
  {
    InitializeDeathTrigger();
  }

  private static void InitializeDeathTrigger()
  {
    trigger trigger = trigger.Create();

    // Register unit death events for all players
    for (var playerId = 0; playerId < 24; playerId++)
    {
      trigger.RegisterPlayerUnitEvent(player.Create(playerId), playerunitevent.Death, null);
    }

    trigger.AddAction(OnUnitDeath);
  }

  private static void OnUnitDeath()
  {
    var dyingUnit = @event.Unit;
    var unitId = dyingUnit.HandleId;

    if (_unitDeathCallbacks.TryGetValue(unitId, out var callback))
    {
      callback();
      _unitDeathCallbacks.Remove(unitId); // Remove the triggered callback
    }
  }

  /// <summary>
  /// Registers a callback for a unit death event.
  /// </summary>
  public static void RegisterDeathEvent(unit unit, System.Action callback)
  {
    var unitId = unit.HandleId;
    _unitDeathCallbacks[unitId] = callback;
  }
}
