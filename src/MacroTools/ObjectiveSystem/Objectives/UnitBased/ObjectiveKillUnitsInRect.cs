using System.Collections.Generic;
using System.Linq;
using MacroTools.QuestSystem;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace MacroTools.ObjectiveSystem.Objectives.UnitBased;

/// <summary>
/// Objective that can be completed by killing every creep unit in all the specified Rectangles.
/// </summary>
public sealed class ObjectiveKillUnitsInRects : Objective
{
  private readonly List<Rectangle> _rects;
  private readonly string _areaName;
  private int _maxKillCount;
  private int _currentKillCount;

  private int CurrentKillCount
  {
    get => _currentKillCount;
    set
    {
      _currentKillCount = value;
      Description = $"All creeps in {_areaName} are dead ({_currentKillCount}/{_maxKillCount})";
      if (_currentKillCount == _maxKillCount)
      {
        Progress = QuestProgress.Complete;
      }
    }
  }

  public ObjectiveKillUnitsInRects(List<Rectangle> rects, string areaName)
  {
    _rects = rects;
    _areaName = areaName;
    Position = rects.First().Center;
    DisplaysPosition = true;

    RegisterKillTriggers();
    CurrentKillCount = 0;
  }

  private void RegisterKillTriggers()
  {
    foreach (var rect in _rects)
    {
      var unitsNearby = GlobalGroup
        .EnumUnitsInRect(rect)
        .Where(x => GetOwningPlayer(x) == Player(PLAYER_NEUTRAL_AGGRESSIVE) && !IsUnitType(x, UNIT_TYPE_ANCIENT) &&
                    !IsUnitType(x, UNIT_TYPE_SAPPER) && !IsUnitType(x, UNIT_TYPE_STRUCTURE));

      foreach (var unit in unitsNearby)
      {
        _maxKillCount++;
        var killTrigger = CreateTrigger();
        TriggerRegisterUnitEvent(killTrigger, unit, EVENT_UNIT_DEATH);
        TriggerAddAction(killTrigger, () =>
        {
          CurrentKillCount++;
          DestroyTrigger(GetTriggeringTrigger());
        });
      }
    }
  }
}
