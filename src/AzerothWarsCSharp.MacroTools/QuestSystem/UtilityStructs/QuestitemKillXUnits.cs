using WCSharp.Events;

using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  /// Completes when the quest holder has killed a certain number of units of a certain type.
  /// </summary>
  public class QuestItemKillXUnit : QuestItemData
  {
    private readonly int _objectId;
    private int _currentKillXUnitCount;
    private readonly int _targetKillXUnitCount;

    private int CurrentKillXUnitCount
    {
      set
      {
        _currentKillXUnitCount = value;
        Description = $"Kill {GetObjectName(_objectId)}s ({_currentKillXUnitCount}/{_targetKillXUnitCount})";
      }
    }

    public QuestItemKillXUnit(int objectId, int targetKillXUnitCount)
    {
      _objectId = objectId;
      _targetKillXUnitCount = targetKillXUnitCount;
      CurrentKillXUnitCount = 0;
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDies, OnKillUnit, objectId);
    }

    private void OnKillUnit()
    {
      CurrentKillXUnitCount = _currentKillXUnitCount + 1;
      if (_currentKillXUnitCount == _targetKillXUnitCount)
      {
        Progress = QuestProgress.Complete;
      }
    }
  }
}