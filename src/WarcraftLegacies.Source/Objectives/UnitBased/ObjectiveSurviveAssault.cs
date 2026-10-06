using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>
/// An <see cref="Objective"/> that starts incomplete. Progress is driven externally by whatever mechanic
/// is tracking the assault, via <see cref="MarkSurvived"/>.
/// </summary>
public sealed class ObjectiveSurviveAssault : Objective
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveSurviveAssault"/> class.
  /// </summary>
  /// <param name="description">Describes what the player must survive.</param>
  public ObjectiveSurviveAssault(string description) => SetDescription(description);

  /// <summary>Marks the assault as having been survived.</summary>
  public void MarkSurvived() => Progress = QuestProgress.Complete;
}
