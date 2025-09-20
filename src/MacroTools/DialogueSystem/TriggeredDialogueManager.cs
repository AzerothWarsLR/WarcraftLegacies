namespace MacroTools.DialogueSystem;

/// <summary>
/// Responsible for registering <see cref="Dialogue"/> events and disposing of them when the dialogue finishes playing.
/// </summary>
public static class TriggeredDialogueManager
{
  /// <summary>
  /// Causes the <see cref="TriggeredDialogue"/> to be played when its conditions have been met.
  /// </summary>
  public static void Add(TriggeredDialogue dialogue)
  {
    foreach (var objective in dialogue.Objectives)
    {
      objective.ProgressChanged += dialogue.OnObjectiveCompleted;
      foreach (var faction in objective.EligibleFactions)
      {
        objective.OnAdd(faction);
      }
    }

    dialogue.Completed += DialogueFinished;
  }

  private static void DialogueFinished(object? sender, TriggeredDialogue triggeredDialogue)
  {
    foreach (var objective in triggeredDialogue.Objectives)
    {
      objective.ProgressChanged -= triggeredDialogue.OnObjectiveCompleted;
    }

    triggeredDialogue.Completed -= DialogueFinished;
  }
}
