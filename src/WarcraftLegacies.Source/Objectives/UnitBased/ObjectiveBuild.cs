using MacroTools.Localization;
using MacroTools.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

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
      Description = Loc.Format("Build {unit}s ({current}/{target})",
        ("{unit}", GetObjectName(_objectId)),
        ("{current}", _currentBuildCount.ToString()),
        ("{target}", _targetBuildCount.ToString()));
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
