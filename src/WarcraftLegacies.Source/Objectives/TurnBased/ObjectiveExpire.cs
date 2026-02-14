using System;
using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.TurnBased;

/// <summary>
/// Starts completed, then fails when the specified turn has been reached.
/// </summary>
public sealed class ObjectiveExpire : Objective
{
  private const int WarningTurnsBeforeExpiry = 2;

  private readonly int _expirationTurn;
  private readonly int _warningTurn;
  private readonly string _questName;
  private readonly List<Faction> _assignedFactions = new();
  private readonly EventHandler _turnEndedHandler;

  /// <param name="expirationTurn">The turn on which this objective will fail</param>
  /// <param name="questName">The name of the quest this objective belongs to</param>
  public ObjectiveExpire(int expirationTurn, string questName)
  {
    Description = $"Turn {expirationTurn} hasn't started";
    _expirationTurn = expirationTurn;
    _warningTurn = expirationTurn - WarningTurnsBeforeExpiry;
    _questName = questName;
    ShowsInPopups = false;

    _turnEndedHandler = (_, _) => OnTurnEnded();
    GameTimeManager.TurnEnded += _turnEndedHandler;
  }

  private void OnTurnEnded()
  {
    var currentTurn = GameTimeManager.GetTurn();
    if (currentTurn == _warningTurn)
    {
      OnWarning();
    }

    if (currentTurn >= _expirationTurn)
    {
      OnExpire();
    }
  }

  public override void OnAdd(Faction whichFaction)
  {
    _assignedFactions.Add(whichFaction);
    Progress = QuestProgress.Complete;
  }

  private void OnExpire()
  {
    Progress = QuestProgress.Failed;
    Dispose();
  }

  private void OnWarning()
  {
    if (Progress != QuestProgress.Complete)
    {
      return;
    }

    foreach (var assignedFaction in _assignedFactions)
    {
      var assignedFactionPlayer = assignedFaction.Player;
      if (assignedFactionPlayer != null)
      {
        assignedFactionPlayer.DisplayTextTo($"\n|c00FF7F00WARNING|r - Quest {_questName} will expire in {WarningTurnsBeforeExpiry} turns.");
      }
    }
  }

  private void Dispose()
  {
    GameTimeManager.TurnEnded -= _turnEndedHandler;
  }
}
