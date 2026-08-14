using System;
using MacroTools.GameTime;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.TurnBased;

public sealed class ObjectiveTurn : Objective
{
  /// <param name="targetTurn">The turn number on which this objective should complete</param>
  /// <param name="condition">Optional extra condition that must also be true for it to complete</param>
  public ObjectiveTurn(int targetTurn, Func<bool>? condition = null)
  {
    SetDescription("Turn {turn} has started", ("{turn}", targetTurn.ToString()));
    GameTimeManager.RegisterOnTurn(targetTurn, OnComplete, condition);
  }

  private void OnComplete()
  {
    Progress = QuestProgress.Complete;
  }
}
