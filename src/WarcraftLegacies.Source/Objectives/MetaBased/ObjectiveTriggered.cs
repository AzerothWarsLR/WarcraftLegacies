using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.MetaBased;

/// <summary>
/// Completed when code calls <see cref="Trigger"/>, for requirements that are easier to watch for elsewhere.
/// </summary>
public sealed class ObjectiveTriggered : Objective
{
  public ObjectiveTriggered(string description) => SetDescription(description);

  /// <summary>Completes the objective.</summary>
  public void Trigger() => Progress = QuestProgress.Complete;

  /// <summary>Fails the objective.</summary>
  public void Fail() => Progress = QuestProgress.Failed;
}
