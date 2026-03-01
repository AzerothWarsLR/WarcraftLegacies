using MacroTools.GameTime;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.TurnBased;

public sealed class ObjectiveTurn : Objective
{
  /// <param name="targetTurn">The turn number on which this objective should complete</param>
  public ObjectiveTurn(int targetTurn)
  {
    Description = $"Turn {targetTurn} has started";
    GameTimeManager.RegisterOnTurn(targetTurn, OnComplete);
  }

  private void OnComplete()
  {
    Progress = QuestProgress.Complete;
  }
}
