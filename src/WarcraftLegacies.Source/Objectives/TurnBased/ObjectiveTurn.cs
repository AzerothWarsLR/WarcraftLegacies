using System;
using MacroTools.GameTime;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.TurnBased;

public sealed class ObjectiveTurn : Objective
{
  private readonly int _targetTurn;
  private readonly EventHandler _turnEndedHandler;

  /// <param name="targetTurn">The turn number on which this objective should complete</param>
  public ObjectiveTurn(int targetTurn)
  {
    _targetTurn = targetTurn;
    Description = $"Turn {targetTurn} has started";

    _turnEndedHandler = (_, _) => CheckCompletion();
    GameTimeManager.TurnEnded += _turnEndedHandler;
  }

  private void CheckCompletion()
  {
    if (GameTimeManager.GetTurn() < _targetTurn)
    {
      return;
    }

    Progress = QuestProgress.Complete;
    Dispose();
  }

  private void Dispose()
  {
    GameTimeManager.TurnEnded -= _turnEndedHandler;
  }
}
