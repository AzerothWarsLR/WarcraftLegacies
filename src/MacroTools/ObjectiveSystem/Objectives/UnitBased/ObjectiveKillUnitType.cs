using MacroTools.QuestSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
  /// <summary>
  ///   Completes when the quest holder has killed a certain number of units.
  /// </summary>
  public sealed class ObjectiveKillUnitType : Objective
  {
    private readonly int _targetKillXUnitCount;
    private int _currentKillXUnitCount;

    public ObjectiveKillXUnit(int targetKillXUnitCount)
    {
      _targetKillXUnitCount = targetKillXUnitCount;
      CurrentKillXUnitCount = 0;
      PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnKillUnit);
    }

    private int CurrentKillXUnitCount
    {
      set
      {
        _currentKillXUnitCount = value;
        Description = $"Kill units ({_currentKillXUnitCount}/{_targetKillXUnitCount})";
      }
    }

    private void OnKillUnit()
    {
      CurrentKillXUnitCount = _currentKillXUnitCount + 1;
      if (_currentKillXUnitCount == _targetKillXUnitCount) Progress = QuestProgress.Complete;
    }
  }
}