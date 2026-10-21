using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.Scourge.Events;
using WarcraftLegacies.Source.Objectives.TurnBased;

namespace WarcraftLegacies.Source.Factions.Legion.Paths;

/// <summary>
/// The Legion casts out the Scourge before the Lich King can betray it.
/// </summary>
public sealed class PathPurgeTheUnworthy : FactionPath
{
  private const int EarliestTurn = 20;

  private readonly ScourgeSplitEvent _split;

  public PathPurgeTheUnworthy(ScourgeSplitEvent split)
  {
    _split = split;
    Name = "Purge the Unworthy";
    IconName = "Archimonde";
    Description = "The Lich King was only ever a tool, and a tool that thinks for itself is a danger to its masters. Cast the Scourge out of the Burning Legion before it can turn on you. Hatred will make both sides stronger.";
    AddRequirement(new ObjectiveTurn(EarliestTurn) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _split.HappenNow(faction.ColoredName);
}
