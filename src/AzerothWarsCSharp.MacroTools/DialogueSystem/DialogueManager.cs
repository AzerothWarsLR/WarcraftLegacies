namespace AzerothWarsCSharp.MacroTools.DialogueSystem
{
  /// <summary>
  /// Responsible for registering <see cref="Dialogue"/> events and disposing of them when the dialogue finishes playing.
  /// </summary>
  public static class DialogueManager
  {
    public static void Add(Dialogue dialogue)
    {
      foreach (var objective in dialogue.Objectives)
      {
        objective.ProgressChanged += dialogue.OnObjectiveCompleted;
      }

      dialogue.Completed += DialogueFinished;
    }

    private static void DialogueFinished(object? sender, Dialogue dialogue)
    {
      foreach (var objective in dialogue.Objectives)
      {
        objective.ProgressChanged -= dialogue.OnObjectiveCompleted;
      }

      dialogue.Completed -= DialogueFinished;
    }
  }
}