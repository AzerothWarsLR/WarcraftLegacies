using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  /// Objective that is completed when all Neutral Hostile units in an are are dead.
  /// </summary>
  public sealed class ObjectiveKillAllInArea : Objective
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
      }
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveKillAllInArea"/> class.
    /// </summary>
    public ObjectiveKillAllInArea(IEnumerable<Rectangle> rectangles, string areaName)
    {
      _areaName = areaName;
      foreach (var rectangle in rectangles)
      {
        foreach (var unit in CreateGroup().EnumUnitsInRect(rectangle).EmptyToList()
                   .Where(x => x.OwningPlayer() == Player(PLAYER_NEUTRAL_AGGRESSIVE) && !x.IsType(UNIT_TYPE_ANCIENT)))
        {
          _maxKillCount++;
          CreateTrigger()
            .RegisterUnitEvent(unit, EVENT_UNIT_DEATH)
            .AddAction(() => CurrentKillCount--);
        }
      }
    }
  }
}