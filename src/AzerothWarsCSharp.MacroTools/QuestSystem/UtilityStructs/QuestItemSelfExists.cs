using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class QuestItemSelfExists : QuestItemData{
    public override void OnAdd(){
      Progress = QuestProgress.Complete;
      Holder.ScoreStatusChanged += OnAnyFactionScoreStatusChanged;
    }

    private void OnAnyFactionScoreStatusChanged(object? sender, Faction faction)
    {
      if (faction.ScoreStatus == ScoreStatus.Defeated)
      {
        Progress = QuestProgress.Failed;
      }
    }

    public QuestItemSelfExists()
    {
      Progress = QuestProgress.Complete;
      ShowsInQuestLog = false;
    }

  }
}