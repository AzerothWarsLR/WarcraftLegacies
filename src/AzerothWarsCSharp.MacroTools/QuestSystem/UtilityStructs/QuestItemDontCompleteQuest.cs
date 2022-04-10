namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class QuestItemDontCompleteQuest : QuestItemData
  {
    public QuestItemDontCompleteQuest(QuestData target)
    {
      Description = "Do not complete the quest " + target.Title;
      target.ProgressChanged += OnQuestProgressChanged;
    }

    internal override void OnAdd()
    {
      Progress = QuestProgress.Complete;
    }

    private void OnQuestProgressChanged(object? sender, QuestData questData)
    {
      if (questData.Progress == QuestProgress.Complete) Progress = QuestProgress.Failed;
    }
  }
}