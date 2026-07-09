using MacroTools.GameTime;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.TurnBased;

public sealed class ObjectiveTurn : Objective
{
  /// <param name="targetTurn">The turn number on which this objective should complete</param>
  public ObjectiveTurn(int targetTurn)
  {
    SetDescription("Turn {turn} has started", ("{turn}", targetTurn.ToString()));
    GameTimeManager.RegisterOnTurn(targetTurn, OnComplete);
  }

  private void OnComplete()
  {
    Progress = QuestProgress.Complete;
  }
}
