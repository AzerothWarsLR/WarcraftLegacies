using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.TeamBased
{
  public class ObjectiveTeamControlPointAmountLessThan : Objective
  {
    private int _controlPointCount;
    
    public ObjectiveTeamControlPointAmountLessThan(Team whichTeam, int cpAmount)
    {
      Description = $"{whichTeam.Name} has less than {cpAmount} ControlPoints";
      _controlPointCount = cpAmount;
      foreach (var faction in whichTeam.GetAllFactions())
      {
        if (faction.Player != null)
          PlayerData.ByHandle(faction.Player).ControlPointsChanged += OnTeamControlPointsChanged;
      }
    }
    
    private  void OnTeamControlPointsChanged(object? sender, PlayerData playerData)
    {
      if (playerData.Team != null && playerData.Team.ControlPoints.Count < _controlPointCount)
        Progress = QuestProgress.Complete;
      if (playerData.Team != null && playerData.Team.ControlPoints.Count >= _controlPointCount)
        Progress = QuestProgress.Incomplete;
    }
  }
}