using System;
using System.Collections.Generic;
using MacroTools.GameTime;

namespace MacroTools.TurnBasedHitPoints;

/// <summary>A tool for giving units additional hit points per turn.</summary>
public static class TurnBasedHitpointsManager
{
  /// <summary>Past this turn, units will not gain maximum hit points.</summary>
  private const float TurnLimit = 45;

  private static readonly Dictionary<unit, TurnBasedHitpointData> _unitData = new();
  private static bool _intialized;

  /// <summary>Causes the unit to continously gain maximum hit points as each turn passes.</summary>
  public static void Register(unit whichUnit, float hitPointPercentagePerTurn)
  {
    if (_unitData.ContainsKey(whichUnit))
    {
      throw new InvalidOperationException($"Tried to register {whichUnit.Name} to {nameof(TurnBasedHitpointsManager)}, but it's already registered.");
    }

    _unitData.Add(whichUnit, new TurnBasedHitpointData
    {
      HitPointPercentagePerTurn = hitPointPercentagePerTurn,
      BaseHitPoints = whichUnit.MaxLife
    });
    if (_intialized)
    {
      return;
    }

    GameTimeManager.TurnEnded += OnTurnEnded;
    _intialized = true;
  }

  public static void UnRegister(unit whichUnit)
  {
    if (_unitData.ContainsKey(whichUnit))
    {
      _unitData.Remove(whichUnit);
    }
  }

  private static void OnTurnEnded(object? sender, EventArgs eventArgs)
  {
    var turn = GameTimeManager.GetTurn();
    foreach (var (unit, turnBasedHitpointData) in _unitData)
    {
      var bonusPercentage = turnBasedHitpointData.HitPointPercentagePerTurn * turn;
      var bonusHitPoints = (int)Math.Ceiling(turnBasedHitpointData.BaseHitPoints * bonusPercentage);
      var value = turnBasedHitpointData.BaseHitPoints + bonusHitPoints;
      unit.MaxLife = value;

      var heal = turnBasedHitpointData.BaseHitPoints * turnBasedHitpointData.HitPointPercentagePerTurn;
      var value1 = (int)Math.Ceiling(unit.Life + heal);
      unit.Life = value1;
    }

    if (turn >= TurnLimit)
    {
      GameTimeManager.TurnEnded -= OnTurnEnded;
    }
  }

  private sealed class TurnBasedHitpointData
  {
    public float HitPointPercentagePerTurn { get; init; }
    public int BaseHitPoints { get; init; }
  }
}
