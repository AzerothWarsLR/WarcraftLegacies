using MacroTools.QuestSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
  /// <summary>
  ///   Completes when the quest holder has killed a certain number of units of a certain type.
  /// </summary>
  public sealed class ObjectiveKillUnitType : Objective
  {
    private readonly int _objectId;
    private readonly int _targetKillXUnitCount;
    private int _currentKillXUnitCount;

    public ObjectiveKillUnitType(int objectId, int targetKillXUnitCount)
    {
      _objectId = objectId;
      _targetKillXUnitCount = targetKillXUnitCount;
      CurrentKillXUnitCount = 0;
      PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnKillUnit, objectId);
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