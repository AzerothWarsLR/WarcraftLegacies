using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.GameLogic;

namespace WarcraftLegacies.Source.Objectives.TurnBased;

/// <summary>Complete while it is night.</summary>
public sealed class ObjectiveNight : Objective
{
  private timer? _refreshTimer;

  public ObjectiveNight()
  {
    SetDescription("It is night");
  }

  /// <inheritdoc />
  public override void OnAdd(Faction whichFaction)
  {
    Refresh();
    _refreshTimer = timer.Create();
    _refreshTimer.Start(1, true, Refresh);
  }

  private void Refresh()
  {
    if (ProgressLocked)
    {
      _refreshTimer?.Dispose();
      _refreshTimer = null;
      return;
    }

    Progress = DayNight.IsNight() ? QuestProgress.Complete : QuestProgress.Incomplete;
  }
}
