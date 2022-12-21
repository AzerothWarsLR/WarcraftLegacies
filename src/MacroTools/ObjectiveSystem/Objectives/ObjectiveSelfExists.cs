using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives
{
  public sealed class ObjectiveSelfExists : Objective
  {
    public ObjectiveSelfExists()
    {
      Progress = QuestProgress.Complete;
      ShowsInQuestLog = false;
    }

    internal override void OnAdd(Faction whichFaction)
    {
      Progress = QuestProgress.Complete;
      whichFaction.ScoreStatusChanged += OnAnyFactionScoreStatusChanged;
    }

    private void OnAnyFactionScoreStatusChanged(object? sender, Faction faction)
    {
      if (faction.ScoreStatus == ScoreStatus.Defeated) Progress = QuestProgress.Failed;
    }
  }
}