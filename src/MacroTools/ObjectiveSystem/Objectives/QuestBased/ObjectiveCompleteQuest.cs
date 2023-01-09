using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.QuestBased
{
  public sealed class ObjectiveCompleteQuest : Objective
  {
    public ObjectiveCompleteQuest(QuestData target)
    {
      Description = "Complete the quest " + target.Title;
      target.ProgressChanged += OnQuestProgressChanged;
    }

    private void OnQuestProgressChanged(object? sender, QuestProgressChangedEventArgs args)
    {
      Progress = args.Quest.Progress switch
      {
        QuestProgress.Complete => QuestProgress.Complete,
        QuestProgress.Failed => QuestProgress.Failed,
        _ => Progress
      };
    }
  }
}