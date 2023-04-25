using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.FactionBased
{
  public sealed class ObjectiveTeamLostDuel : Objective
  {
    public ObjectiveTeamLostDuel(Team whichTeam)
    {
      Description = whichTeam.Name + " has lost the duel";
      if (Team.ControlPointCount) = 1;
    }

    private  void OnAnyFactionScoreStatusChanged(object? sender, Faction faction)
    {
      if (faction.ScoreStatus == ScoreStatus.Defeated)
        Progress = QuestProgress.Complete;
    }
  }
}