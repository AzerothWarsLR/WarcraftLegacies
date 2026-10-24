using System;
using MacroTools.GameTime;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.TurnBased;

public sealed class ObjectiveTurn : Objective
{
  private readonly Func<bool>? _condition;
  private int _targetTurn;

  /// <param name="targetTurn">The turn number on which this objective should complete</param>
  /// <param name="condition">Optional extra condition that must also be true for it to complete</param>
  public ObjectiveTurn(int targetTurn, Func<bool>? condition = null)
  {
    _condition = condition;
    TargetTurn = targetTurn;
  }

  /// <summary>The turn on which this objective completes. Changing it moves the objective to the new turn.</summary>
  public int TargetTurn
  {
    get => _targetTurn;
    set
    {
      _targetTurn = value;
      SetDescription("Turn {turn} has started", ("{turn}", value.ToString()));
      GameTimeManager.RegisterOnTurn(Math.Max(value, GameTimeManager.Turn + 1), () => OnTurn(value), _condition);
    }
  }

  private void OnTurn(int turn)
  {
    if (turn == _targetTurn)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
