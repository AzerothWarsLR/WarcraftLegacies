namespace MacroTools.Paths;

/// <summary>
/// Where a <see cref="FactionPath"/> is in its lifecycle.
/// </summary>
public enum PathState
{
  /// <summary>The path's requirements haven't all been met yet.</summary>
  Locked,

  /// <summary>The path can be accepted or declined.</summary>
  Available,

  /// <summary>The path was accepted and is counting down; it can still be cancelled.</summary>
  Committing,

  /// <summary>The path was taken.</summary>
  Taken,

  /// <summary>The player turned the path down.</summary>
  Declined,

  /// <summary>The path can no longer be taken, because its offer ran out, a requirement failed, or another path was taken.</summary>
  Closed
}
