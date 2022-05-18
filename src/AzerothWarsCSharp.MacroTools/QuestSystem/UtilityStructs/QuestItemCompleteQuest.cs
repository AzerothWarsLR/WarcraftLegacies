namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class QuestItemCompleteQuest : QuestItemData
  {
    public QuestItemCompleteQuest(QuestData target)
    {
      Description = "Complete the quest " + target.Title;
      target.ProgressChanged += OnQuestProgressChanged;
    }

    private void OnQuestProgressChanged(object? sender, QuestData questData)
    {
      Progress = questData.Progress switch
      {
        QuestProgress.Complete => QuestProgress.Complete,
        QuestProgress.Failed => QuestProgress.Failed,
        _ => Progress
      };
    }
  }
}