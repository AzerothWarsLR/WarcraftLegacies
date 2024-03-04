using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.QuestSystem;
using WCSharp.Events;
using WCSharp.Shared.Data;


namespace MacroTools.ObjectiveSystem.Objectives.UnitBased
{
  /// <summary>
  /// Completed when an eligible player completes construction on a certain number of unique buildings building in the
  /// specified <see cref="Rectangle"/>.
  /// </summary>
  public sealed class ObjectiveBuildUniqueBuildingsInRect : Objective
  {
    private int _currentBuildCount;
    private readonly int _targetBuildCount;
    private readonly string _areaName;
    private readonly List<int> _uniqueBuildingIdsBuilt = new();
    private readonly Rectangle _targetRect;

    private int CurrentBuildCount
    {
      set
      {
        _currentBuildCount = value;
        Description = $"Build {_targetBuildCount} different buildings {_areaName} ({_currentBuildCount}/{_targetBuildCount})";
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveBuildInRect"/> class.
    /// </summary>
    public ObjectiveBuildUniqueBuildingsInRect(Rectangle targetRect, string areaName, int count)
    {
      switch (count)
      {
        case < 1:
          throw new ArgumentOutOfRangeException(nameof(count), $"{nameof(count)} must be at least 1.");
        case > 9:
          throw new ArgumentOutOfRangeException(nameof(count), $"{nameof(count)} must be less than 10.");
      }

      _targetRect = targetRect;
      _areaName = areaName;
      _targetBuildCount = count;
      DisplaysPosition = true;
      CurrentBuildCount = 0;
      PingPath = "MinimapQuestTurnIn";

      PlayerUnitEvents.Register(UnitTypeEvent.FinishesConstruction, OnBuild);

      Position = targetRect.Center;
    }

    private void OnBuild()
    {
      var buildingId = GetUnitTypeId(GetConstructedStructure());
      if (!_targetRect.Contains(GetTriggerUnit().GetPosition()) || _uniqueBuildingIdsBuilt.Contains(buildingId))
        return;

      _uniqueBuildingIdsBuilt.Add(buildingId);
      CurrentBuildCount = _currentBuildCount + 1;
      if (_currentBuildCount == _targetBuildCount)
      {
        Progress = QuestProgress.Complete;
        Dispose();
      }
    }

    private void Dispose()
    {
      PlayerUnitEvents.Unregister(UnitTypeEvent.FinishesConstruction, OnBuild);
    }
  }
}