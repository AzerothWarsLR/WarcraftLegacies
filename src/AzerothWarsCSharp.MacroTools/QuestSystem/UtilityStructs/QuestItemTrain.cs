using System.Collections.Generic;
using WCSharp.Events;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class QuestItemTrain : QuestItemData
  {
    private static readonly List<QuestItemTrain> ByIndex = new();
    private readonly int _objectId;
    private readonly int _trainFromId;
    private int _currentTrainCount;
    private readonly int _targetTrainCount;

    private int CurrentTrainCount
    {
      set
      {
        _currentTrainCount = value;
        Description = "Train " + GetObjectName(_objectId) + "s from the " + GetObjectName(_trainFromId) + " (" +
                      I2S(_currentTrainCount) + "/" + I2S(_targetTrainCount) + ")";
      }
    }

    public QuestItemTrain(int objectId, int trainFromId, int targetTrainCount)
    {
      _objectId = objectId;
      _trainFromId = trainFromId;
      ByIndex.Add(this);
      _targetTrainCount = targetTrainCount;
      CurrentTrainCount = 0;
    }

    private static void OnAnyTrain()
    {
      unit triggerUnit = GetTrainedUnit();
      foreach (var item in ByIndex)
      {
        if (!item.ProgressLocked && item._objectId == GetUnitTypeId(triggerUnit) &&
            item.Holder.Player == GetOwningPlayer(GetTrainedUnit()))
        {
          item.CurrentTrainCount = item._currentTrainCount + 1;
          if (item._currentTrainCount == item._targetTrainCount)
          {
            item.Progress = QuestData.QUEST_PROGRESS_COMPLETE;
          }
        }
      }
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesTraining, OnAnyTrain);
    }
  }
}