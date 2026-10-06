namespace MacroTools.WorldEvents;

/// <summary>
/// Where a <see cref="WorldEvent"/> is in its lifecycle.
/// </summary>
public enum WorldEventState
{
  /// <summary>The event's requirements haven't all been met yet.</summary>
  Upcoming,

  /// <summary>The event's requirements are met and it's counting down to happening.</summary>
  Imminent,

  /// <summary>The event has happened.</summary>
  Happened,

  /// <summary>The event can no longer happen, because a requirement failed or it was cancelled.</summary>
  Cancelled
}
