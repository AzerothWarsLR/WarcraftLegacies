using WCSharp.Events;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  ///   Completes when the quest holder has killed a certain number of units of a certain type.
  /// </summary>
  public class ObjectiveKillXUnit : Objective
  {
    private readonly int _objectId;
    private readonly int _targetKillXUnitCount;
    private int _currentKillXUnitCount;

    public ObjectiveKillXUnit(int objectId, int targetKillXUnitCount)
    {
      _objectId = objectId;
      _targetKillXUnitCount = targetKillXUnitCount;
      CurrentKillXUnitCount = 0;
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDies, OnKillUnit, objectId);
    }

    private int CurrentKillXUnitCount
    {
      set
      {
        _currentKillXUnitCount = value;
        Description = $"Kill {GetObjectName(_objectId)}s ({_currentKillXUnitCount}/{_targetKillXUnitCount})";
      }
    }

    private void OnKillUnit()
    {
      CurrentKillXUnitCount = _currentKillXUnitCount + 1;
      if (_currentKillXUnitCount == _targetKillXUnitCount) Progress = QuestProgress.Complete;
    }
  }
}