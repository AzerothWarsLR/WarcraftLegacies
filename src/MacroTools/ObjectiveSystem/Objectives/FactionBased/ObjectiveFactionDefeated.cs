using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.FactionBased
{
  public class ObjectiveFactionDefeated : Objective
  {
    public ObjectiveFactionDefeated(FactionSystem.Faction whichFaction)
    {
      Description = whichFaction.Name + " has been defeated";
      whichFaction.ScoreStatusChanged += OnAnyFactionScoreStatusChanged;
    }

    private  void OnAnyFactionScoreStatusChanged(object? sender, FactionSystem.Faction faction)
    {
      if (faction.ScoreStatus == ScoreStatus.Defeated)
        Progress = QuestProgress.Complete;
    }
  }
}