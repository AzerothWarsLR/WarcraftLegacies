using WCSharp.Events;

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
        Description = "Kill " + GetObjectName(_objectId) + "s (" + I2S(_currentKillXUnitCount) + "/" +
                      I2S(_targetKillXUnitCount) + ")";
      }
    }

    public QuestItemKillXUnit(int objectId, int targetKillXUnitCount)
    {
      _objectId = objectId;
      _targetKillXUnitCount = targetKillXUnitCount;
      CurrentKillXUnitCount = 0;
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDies, OnAnyKillXUnit, objectId);
    }

    private void OnAnyKillXUnit()
    {
      CurrentKillXUnitCount = _currentKillXUnitCount + 1;
      if (_currentKillXUnitCount == _targetKillXUnitCount)
      {
        Progress = QuestProgress.Complete;
      }
    }
  }
}