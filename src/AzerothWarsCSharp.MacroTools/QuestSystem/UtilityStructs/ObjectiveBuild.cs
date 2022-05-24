using WCSharp.Events;

using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
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
        Description = "Build " + GetObjectName(_objectId) + "s (" + I2S(_currentBuildCount) + "/" +
                      I2S(_targetBuildCount) + ")";
      }
    }

    public ObjectiveBuild(int objectId, int targetBuildCount)
    {
      _objectId = objectId;
      _targetBuildCount = targetBuildCount;
      CurrentBuildCount = 0;
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesConstruction, OnBuild, objectId);
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