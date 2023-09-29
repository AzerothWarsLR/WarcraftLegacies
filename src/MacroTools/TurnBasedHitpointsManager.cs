using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using static War3Api.Common;

namespace MacroTools
{
  /// <summary>A tool for giving units additional hit points per turn.</summary>
  public static class TurnBasedHitpointsManager
  {
    /// <summary>Registered units will gain this many hit points, as a percentage of their maximum, per turn.</summary>
    public const float HitPointPercentagePerTurn = 0.1f;

    /// <summary>Past this turn, units will not gain maximum hit points.</summary>
    private const float TurnLimit = 60;

    private static readonly Dictionary<unit, int> UnitBaseHitPoints = new();
    private static bool _intialized;
    
    /// <summary>Causes the unit to continously gain maximum hit points as each turn passes.</summary>
    public static void Register(unit whichUnit)
    {
      UnitBaseHitPoints.Add(whichUnit, whichUnit.GetMaximumHitPoints());
      if (_intialized) 
        return;
      
      GameTime.TurnEnded += OnTurnEnded;
      _intialized = true;
    }

    private static void OnTurnEnded(object? sender, EventArgs eventArgs)
    {
      var turn = GameTime.GetTurn();
      foreach (var (unit, baseHitPoints) in UnitBaseHitPoints)
      {
        var bonusPercentage = HitPointPercentagePerTurn * turn;
        unit.SetMaximumHitpoints((int)(baseHitPoints * (1 + bonusPercentage)));
        unit.SetCurrentHitpoints(unit.GetMaximumHitPoints());
      }
      
      if (turn >= TurnLimit) 
        GameTime.TurnEnded -= OnTurnEnded;
    }
  }
}