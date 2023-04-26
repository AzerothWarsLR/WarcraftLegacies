using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.TeamBased
{
  public sealed class ObjectiveTeamContolPointAmountGreaterThan : Objective
  {
    private int _controlPointCount;
    
    public ObjectiveTeamContolPointAmountGreaterThan(Team whichTeam, int cpAmount)
    {
      Description = $"{whichTeam.Name} has more than {cpAmount} ControlPoints";
      _controlPointCount = cpAmount;
      foreach (var faction in whichTeam.GetAllFactions())
      {
        if (faction.Player != null)
          PlayerData.ByHandle(faction.Player).ControlPointsChanged += OnTeamControlPointsChanged;
      }
    }
    
    private  void OnTeamControlPointsChanged(object? sender, PlayerData playerData)
    {
      if (playerData.Team != null && playerData.Team.ControlPoints.Count > _controlPointCount)
        Progress = QuestProgress.Complete;
    }
  }
}