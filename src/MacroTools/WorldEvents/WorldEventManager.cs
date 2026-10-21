using System;
using System.Collections.Generic;

namespace MacroTools.WorldEvents;

/// <summary>
/// Keeps track of every <see cref="WorldEvent"/> in the game.
/// </summary>
public static class WorldEventManager
{
  private static readonly List<WorldEvent> _events = new();

  /// <summary>Fired when a <see cref="WorldEvent"/> is registered.</summary>
  public static event Action<WorldEvent>? EventRegistered;

  /// <summary>Starts tracking a <see cref="WorldEvent"/>. It happens as soon as its requirements are met.</summary>
  public static void Register(WorldEvent worldEvent)
  {
    _events.Add(worldEvent);
    EventRegistered?.Invoke(worldEvent);
    worldEvent.OnRegistered();
  }

  /// <summary>Returns every registered <see cref="WorldEvent"/>, in the order they were registered.</summary>
  public static IReadOnlyList<WorldEvent> GetAll() => _events;
}
