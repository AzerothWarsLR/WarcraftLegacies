using System;
using System.Collections.Generic;

namespace MacroTools.Libraries;

/// <summary>
/// Static unit event system that provides unit death and damage event listeners.
/// </summary>
public static class UnitEventSystem
{
  // Stores the mapping between units and death event callbacks
  private static readonly Dictionary<unit, Action> _unitDeathCallbacks = new();

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
      trigger.RegisterPlayerUnitEvent(player.Create(playerId), playerunitevent.Death);
    }

    trigger.AddAction(OnUnitDeath);
  }

  private static void OnUnitDeath()
  {
    var dyingUnit = @event.Unit;

    if (_unitDeathCallbacks.TryGetValue(dyingUnit, out var callback))
    {
      callback();
      _unitDeathCallbacks.Remove(dyingUnit); // Remove the triggered callback
    }
  }

  /// <summary>
  /// Registers a callback for a unit death event.
  /// </summary>
  public static void RegisterDeathEvent(unit unit, Action callback)
  {
    _unitDeathCallbacks[unit] = callback;
  }
}
