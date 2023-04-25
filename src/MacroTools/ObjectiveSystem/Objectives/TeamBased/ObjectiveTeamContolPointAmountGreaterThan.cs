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
      whichTeam.ControlPointsChanged += OnTeamControlPointsChanged;
    }
    
    private  void OnTeamControlPointsChanged(object? sender, Team team)
    {
      if (team.ControlPoints.Count > _controlPointCount)
        Progress = QuestProgress.Complete;
    }
  }
}