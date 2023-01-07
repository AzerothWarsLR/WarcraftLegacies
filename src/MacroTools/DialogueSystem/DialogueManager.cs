namespace MacroTools.DialogueSystem
{
  /// <summary>
  /// Responsible for registering <see cref="Dialogue"/> events and disposing of them when the dialogue finishes playing.
  /// </summary>
  public static class DialogueManager
  {
    /// <summary>
    /// Causes the <see cref="Dialogue"/> to be played when its conditions have been met.
    /// </summary>
    /// <param name="dialogue"></param>
    public static void Add(Dialogue dialogue)
    {
      foreach (var objective in dialogue.Objectives)
      {
        objective.ProgressChanged += dialogue.OnObjectiveCompleted;
        foreach (var faction in objective.EligibleFactions) 
          objective.OnAdd(faction);
      }

      dialogue.Completed += DialogueFinished;
    }

    private static void DialogueFinished(object? sender, Dialogue dialogue)
    {
      foreach (var objective in dialogue.Objectives) 
        objective.ProgressChanged -= dialogue.OnObjectiveCompleted;

      dialogue.Completed -= DialogueFinished;
    }
  }
}