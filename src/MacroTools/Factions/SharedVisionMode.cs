namespace MacroTools.Factions;

/// <summary>
/// Describes how members of a <see cref="Team"/> share vision with eachother.
/// </summary>
public enum TeamSharedVisionMode
{
  /// <summary>
  /// All players on a <see cref="Team"/> share vision.
  /// </summary>
  All,

  /// <summary>
  /// Only <see cref="Team"/> members that started on the same team as each other share vision.
  /// </summary>
  TraditionalAlliesOnly
}
