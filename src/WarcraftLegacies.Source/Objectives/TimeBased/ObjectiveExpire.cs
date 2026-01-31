using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Systems;

namespace WarcraftLegacies.Source.Objectives.TimeBased;

/// <summary>
///   Starts completed, then fails when the specified amount of time has elapsed.
/// </summary>
public sealed class ObjectiveExpire : Objective
{
  private readonly timer _expirationTimer;
  private readonly timer _warningTimer;
  private readonly string _questName;
  private readonly List<Faction> _assignedFactions = new();

  /// <param name="duration">The time after which the objective will fail</param>
  /// <param name="questName">The name of the quest this objective belongs to.</param>
  public ObjectiveExpire(int duration, string questName)
  {
    var turn = GameTime.ConvertGameTimeToTurn(duration);
    Description = $"Turn {turn} hasn't started";
    _expirationTimer = timer.Create();
    _warningTimer = timer.Create();
    _expirationTimer.Start(duration, false, OnExpire);
    _warningTimer.Start(duration - 120, false, OnWarning);
    _questName = questName;
    ShowsInPopups = false;
  }

  public override void OnAdd(Faction whichFaction)
  {
    _assignedFactions.Add(whichFaction);
    Progress = QuestProgress.Complete;
  }

  private void OnExpire()
  {
    _expirationTimer.Dispose();
    Progress = QuestProgress.Failed;
  }

  private void OnWarning()
  {
    _warningTimer.Dispose();
    foreach (var assignedFaction in _assignedFactions)
    {
      if (Progress != QuestProgress.Complete)
      {
        assignedFaction.Player.DisplayTextTo($"\n|c00FF7F00WARNING|r - Quest {_questName} will expire in 2 minutes.");
      }
    }
  }
}
