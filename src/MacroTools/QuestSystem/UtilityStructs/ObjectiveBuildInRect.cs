using MacroTools.Extensions;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  /// Completed when an eligible player completes construction on a building in the specified <see cref="Rectangle"/>.
  /// </summary>
  public class ObjectiveBuildInRect : Objective
  {
    private readonly int _objectId;
    private readonly Rectangle _targetRect;
    private int _currentBuildCount;
    private readonly int _targetBuildCount;
    private readonly string _areaName;

    private int CurrentBuildCount
    {
      set
      {
        _currentBuildCount = value;
        Description = $"Build {_targetBuildCount} {GetObjectName(_objectId)}s {_areaName} ({_currentBuildCount} / {_targetBuildCount})";
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveBuildInRect"/> class.
    /// </summary>
    public ObjectiveBuildInRect(Rectangle targetRect, string areaName, int objectId, int count = 1)
    {
      _areaName = areaName;
      _targetBuildCount = count;
      _targetRect = targetRect;
      _objectId = objectId;
      DisplaysPosition = true;
      CurrentBuildCount = 0;
      PingPath = "MinimapQuestTurnIn";
      PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnDeath, objectId);
      CreateTrigger()
        .RegisterEnterRegion(targetRect)
        .AddAction(() =>
        {
          var triggerUnit = GetTriggerUnit();
          if (!IsUnitValid(triggerUnit))
            return;
          CurrentBuildCount = _currentBuildCount + 1;
          if (_currentBuildCount == _targetBuildCount)
          {
            Progress = QuestProgress.Complete;
          }
        });
    }

    private void OnDeath()
    {
      if (Progress == QuestProgress.Complete)
        return;

      var triggerUnit = GetTriggerUnit();
      if (!IsUnitValid(triggerUnit))
        return;
      var point = triggerUnit.GetPosition();
      if (point.X > _targetRect.Left && point.X < _targetRect.Right && point.Y > _targetRect.Bottom && point.Y < _targetRect.Top)
      {
        CurrentBuildCount = _currentBuildCount - 1;
        Progress = QuestProgress.Incomplete;
      }
    }

    /// <inheritdoc />
    public override Point Position => new(GetRectCenterX(_targetRect.Rect), GetRectCenterY(_targetRect.Rect));

    private bool IsUnitValid(unit whichUnit) =>
      EligibleFactions.Contains(whichUnit.OwningPlayer()) && IsUnitType(whichUnit, UNIT_TYPE_STRUCTURE) && whichUnit.GetTypeId() == _objectId;
  }
}
