using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.FactionBased;

public sealed class ObjectiveFactionDefeated : Objective
{
  public ObjectiveFactionDefeated(Faction whichFaction)
  {
    Description = whichFaction.Name + " has been defeated";
    whichFaction.ScoreStatusChanged += OnAnyFactionScoreStatusChanged;
  }

  private void OnAnyFactionScoreStatusChanged(object? sender, Faction faction)
  {
    if (faction.ScoreStatus == ScoreStatus.Defeated)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
