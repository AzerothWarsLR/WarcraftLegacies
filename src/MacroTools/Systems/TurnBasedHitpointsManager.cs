using System;
using System.Collections.Generic;

namespace MacroTools.Systems
{
  /// <summary>A tool for giving units additional hit points per turn.</summary>
  public static class TurnBasedHitpointsManager
  {
    /// <summary>Past this turn, units will not gain maximum hit points.</summary>
    private const float TurnLimit = 45;

    private static readonly Dictionary<unit, TurnBasedHitpointData> UnitData = new();
    private static bool _intialized;

    /// <summary>Causes the unit to continously gain maximum hit points as each turn passes.</summary>
    public static void Register(unit whichUnit, float hitPointPercentagePerTurn)
    {
      if (UnitData.ContainsKey(whichUnit))
        throw new InvalidOperationException($"Tried to register {GetUnitName(whichUnit)} to {nameof(TurnBasedHitpointsManager)}, but it's already registered.");

      UnitData.Add(whichUnit, new TurnBasedHitpointData
      {
        HitPointPercentagePerTurn = hitPointPercentagePerTurn,
        BaseHitPoints = BlzGetUnitMaxHP(whichUnit)
      });
      if (_intialized)
        return;

      GameTime.TurnEnded += OnTurnEnded;
      _intialized = true;
    }

    public static void UnRegister(unit whichUnit)
    {
      if (UnitData.ContainsKey(whichUnit))
        UnitData.Remove(whichUnit);
    }

    private static void OnTurnEnded(object? sender, EventArgs eventArgs)
    {
      var turn = GameTime.GetTurn();
      foreach (var (unit, turnBasedHitpointData) in UnitData)
      {
        var bonusPercentage = turnBasedHitpointData.HitPointPercentagePerTurn * turn;
        var bonusHitPoints = (int)Math.Ceiling(turnBasedHitpointData.BaseHitPoints * bonusPercentage);
        int value = turnBasedHitpointData.BaseHitPoints + bonusHitPoints;
        BlzSetUnitMaxHP(unit, value);

        var heal = turnBasedHitpointData.BaseHitPoints * turnBasedHitpointData.HitPointPercentagePerTurn;
        int value1 = (int)Math.Ceiling(GetUnitState(unit, UNIT_STATE_LIFE) + heal);
        SetUnitState(unit, UNIT_STATE_LIFE, value1);
      }

      if (turn >= TurnLimit)
        GameTime.TurnEnded -= OnTurnEnded;
    }

    private sealed class TurnBasedHitpointData
    {
      public float HitPointPercentagePerTurn { get; init; }
      public int BaseHitPoints { get; init; }
    }
  }
}