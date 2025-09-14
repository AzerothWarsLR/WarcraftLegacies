using MacroTools.QuestSystem;
using WCSharp.Events;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
  public sealed class ObjectiveBuild : Objective
  {
    private readonly int _objectId;
    private int _currentBuildCount;
    private readonly int _targetBuildCount;

    private int CurrentBuildCount
    {
      set
      {
        _currentBuildCount = value;
        Description = $"Build {GetObjectName(_objectId)}s ({_currentBuildCount}/{_targetBuildCount})";
      }
    }

    public ObjectiveBuild(int objectId, int targetBuildCount)
    {
      _objectId = objectId;
      _targetBuildCount = targetBuildCount;
      CurrentBuildCount = 0;
      PlayerUnitEvents.Register(UnitTypeEvent.FinishesConstruction, OnBuild, objectId);
    }

    private void OnBuild()
    {
      CurrentBuildCount = _currentBuildCount + 1;
      if (_currentBuildCount == _targetBuildCount)
      {
        Progress = QuestProgress.Complete;
      }
    }
  }
}