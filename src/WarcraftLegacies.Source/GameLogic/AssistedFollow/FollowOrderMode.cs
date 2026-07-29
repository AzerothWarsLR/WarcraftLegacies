namespace WarcraftLegacies.Source.GameLogic.AssistedFollow;

/// <summary>
/// Controls how right-click orders targeting a friendly hero are handled.
/// </summary>
public enum FollowOrderMode
{
  /// <summary>Leaves Warcraft III's native moving-target follow order untouched.</summary>
  Native,

  /// <summary>Mirrors the hero's movement orders as stable point orders.</summary>
  StableDestination
}
