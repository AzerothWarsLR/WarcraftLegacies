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
      whichTeam.ControlPointsChanged += OnTeamControlPointsChanged;
    }
    
    private  void OnTeamControlPointsChanged(object? sender, Team team)
    {
      if (team.ControlPoints.Count < _controlPointCount)
        Progress = QuestProgress.Complete;
    }
  }
}