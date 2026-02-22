using MacroTools.Factions;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.FactionBased;

/// <summary>
/// An <see cref="Objective"/> that starts <see cref="QuestProgress.Complete"/> and fails any time the owning
/// <see cref="Faction"/> does not have its <see cref="player"/> slot filled.
/// </summary>
public sealed class ObjectiveSelfExists : Objective
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveSelfExists"/> class.
  /// </summary>
  public ObjectiveSelfExists()
  {
    Progress = QuestProgress.Complete;
    ShowsInQuestLog = false;
    ShowsInPopups = false;
  }

  public override void OnAdd(Faction whichFaction)
  {
    Progress = QuestProgress.Complete;
    whichFaction.ScoreStatusChanged += OnAnyFactionScoreStatusChanged;
    timer.Create().Start(55, false, () =>
    {
      if (whichFaction.Player == null)
      {
        Progress = QuestProgress.Failed;
      }
      @event.ExpiredTimer.Dispose();
    });
  }

  private void OnAnyFactionScoreStatusChanged(object? sender, Faction faction)
  {
    if (faction.ScoreStatus == ScoreStatus.Defeated)
    {
      Progress = QuestProgress.Failed;
    }
  }
}
