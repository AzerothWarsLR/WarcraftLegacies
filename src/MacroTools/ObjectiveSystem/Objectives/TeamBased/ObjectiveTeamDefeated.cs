using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.TeamBased
{
  public sealed class ObjectiveTeamDefeated : Objective
  {
    public ObjectiveTeamDefeated(Team whichTeam)
    {
      Description = whichTeam.Name + " has been defeated";
      foreach (var faction in whichTeam.GetAllFactions())
      {
        faction.ScoreStatusChanged += OnTeamFactionScoreStatusChanged;
      }
        
    }

    private  void OnTeamFactionScoreStatusChanged(object? sender, Faction faction)
    {
      if (faction.Player != null && faction.Player.GetTeam()!.UndefeatedPlayerCount == 0)
        Progress = QuestProgress.Complete;
    }
  }
}