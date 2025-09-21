using System.Collections.Generic;
using System.Linq;
using MacroTools.QuestSystem;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased;

/// <summary>
/// Objective that is completed when all Neutral Hostile units in an are are dead.
/// </summary>
public sealed class ObjectiveHostilesInAreaAreDead : Objective
{
  private readonly string _areaName;
  private readonly int _maxKillCount;
  private int _currentKillCount;

  private int CurrentKillCount
  {
    get => _currentKillCount;
    set
    {
      _currentKillCount = value;
      Description = $"All creeps {_areaName} are dead ({_currentKillCount}/{_maxKillCount})";
      if (_currentKillCount == _maxKillCount)
      {
        Progress = QuestProgress.Complete;
      }
    }
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveHostilesInAreaAreDead"/> class.
  /// </summary>
  public ObjectiveHostilesInAreaAreDead(ICollection<Rectangle> rectangles, string areaName)
  {
    if (rectangles.Count == 1)
    {
      Position = rectangles.First().Center;
      DisplaysPosition = true;
    }

    _areaName = areaName;
    foreach (var rectangle in rectangles)
    {
      var unitsInAreas = GlobalGroup.EnumUnitsInRect(rectangle)
        .Where(x => x.Owner == player.NeutralAggressive && !x.IsUnitType(unittype.Ancient) &&
                    !x.IsUnitType(unittype.Sapper));
      foreach (var unit in unitsInAreas)
      {
        _maxKillCount++;
        var deathTrigger = trigger.Create();
        deathTrigger.RegisterUnitEvent(unit, unitevent.Death);
        deathTrigger.AddAction(() =>
        {
          CurrentKillCount++;
          @event.Trigger.Dispose();
        });
      }
    }
    CurrentKillCount = 0;
  }
}
