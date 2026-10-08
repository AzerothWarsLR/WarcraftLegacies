using System;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.MetaBased;

/// <summary>Completed while a condition about teams holds.</summary>
public sealed class ObjectiveTeamCondition : Objective
{
  private readonly Func<bool> _condition;

  public ObjectiveTeamCondition(string description, Func<bool> condition)
  {
    _condition = condition;
    SetDescription(description);
    TeamChanges.OnAnyTeamChanged(Refresh);
    GameTimeManager.RegisterOnTurnRepeating(GameTimeManager.Turn + 1, Refresh);
  }

  /// <inheritdoc />
  public override void OnAdd(Faction faction) => Refresh();

  private void Refresh() => Progress = _condition() ? QuestProgress.Complete : QuestProgress.Incomplete;
}
