using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.FactionBased;

public sealed class ObjectiveFactionContolPointAmountGreaterThan : Objective
{
  private readonly int _controlPointCount;

  public ObjectiveFactionContolPointAmountGreaterThan(Faction whichFaction, int cpAmount)
  {
    Description = $"{whichFaction.Name} has more than {cpAmount} ControlPoints";
    _controlPointCount = cpAmount;
    if (whichFaction.Player != null)
    {
      PlayerData.ByHandle(whichFaction.Player).ControlPointsChanged += OnTeamControlPointsChanged;
    }
  }

  private void OnTeamControlPointsChanged(object? sender, PlayerData playerData)
  {
    if (playerData.ControlPoints.Count > _controlPointCount)
    {
      Progress = QuestProgress.Complete;
    }

    if (playerData.ControlPoints.Count <= _controlPointCount)
    {
      Progress = QuestProgress.Incomplete;
    }
  }
}
