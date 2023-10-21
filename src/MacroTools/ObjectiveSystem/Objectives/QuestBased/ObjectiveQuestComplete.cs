using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.QuestBased
{
  public sealed class ObjectiveQuestComplete : Objective
  {
    public ObjectiveQuestComplete(QuestData target)
    {
      Description = $"Complete the quest {target.Title}";
      target.ProgressChanged += OnQuestProgressChanged;
      Progress = QuestProgress.Incomplete;
    }

    private void OnQuestProgressChanged(object? sender, QuestProgressChangedEventArgs args)
    {
      if (args.Quest.Progress == QuestProgress.Complete) 
        Progress = QuestProgress.Complete;
    }
  }
}