using System;
using MacroTools.Extensions;
using MacroTools.QuestSystem;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased;

/// <summary>
/// Completed when an eligible player completes construction on a building in the specified <see cref="Rectangle"/>.
/// </summary>
public sealed class ObjectiveBuildInRect : Objective
{
  private readonly int _objectId;
  private int _currentBuildCount;
  private readonly int _targetBuildCount;
  private readonly string _areaName;

  private int CurrentBuildCount
  {
    set
    {
      _currentBuildCount = value;
      Description = _targetBuildCount > 1
        ? $"Build {_targetBuildCount} {GetObjectName(_objectId)}s {_areaName} ({_currentBuildCount}/{_targetBuildCount})"
        : $"Build {GetObjectName(_objectId)} {_areaName}";
    }
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveBuildInRect"/> class.
  /// </summary>
  public ObjectiveBuildInRect(Rectangle targetRect, string areaName, int objectId, int count = 1)
  {
    if (count < 1)
    {
      throw new ArgumentOutOfRangeException(nameof(count), $"{nameof(count)} must be at least 1.");
    }

    _areaName = areaName;
    _targetBuildCount = count;
    _objectId = objectId;
    DisplaysPosition = true;
    CurrentBuildCount = 0;
    PingPath = "MinimapQuestTurnIn";

    PlayerUnitEvents.Register(UnitTypeEvent.FinishesConstruction, () =>
    {
      if (!targetRect.Contains(GetTriggerUnit().GetPosition()))
      {
        return;
      }

      CurrentBuildCount = _currentBuildCount + 1;
      if (_currentBuildCount == _targetBuildCount)
      {
        Progress = QuestProgress.Complete;
      }
    }, objectId);

    Position = targetRect.Center;
  }
}
