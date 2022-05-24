using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class ObjectiveSelfExists : Objective
  {
    public ObjectiveSelfExists()
    {
      Progress = QuestProgress.Complete;
      ShowsInQuestLog = false;
    }

    internal override void OnAdd()
    {
      Progress = QuestProgress.Complete;
      Holder.ScoreStatusChanged += OnAnyFactionScoreStatusChanged;
    }

    private void OnAnyFactionScoreStatusChanged(object? sender, Faction faction)
    {
      if (faction.ScoreStatus == ScoreStatus.Defeated) Progress = QuestProgress.Failed;
    }
  }
}