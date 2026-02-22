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

  private readonly string _questName;
  private readonly List<Faction> _assignedFactions = new();

  /// <param name="expirationTurn">The turn on which this objective will fail</param>
  /// <param name="questName">The name of the quest this objective belongs to</param>
  public ObjectiveExpire(int expirationTurn, string questName)
  {
    Description = $"Turn {expirationTurn} hasn't started";
    _questName = questName;
    ShowsInPopups = false;

    GameTimeManager.OnTurn(expirationTurn, OnExpire);

    if (expirationTurn > WarningTurnsBeforeExpiry)
    {
      GameTimeManager.OnTurn(expirationTurn - WarningTurnsBeforeExpiry, OnWarning);
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
  }

  private void OnWarning()
  {
    if (Progress == QuestProgress.Complete)
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
}
