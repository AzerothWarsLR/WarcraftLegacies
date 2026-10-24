using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.Scourge.Events;
using WarcraftLegacies.Source.Objectives.TurnBased;

namespace WarcraftLegacies.Source.Factions.Scourge.Paths;

/// <summary>
/// The Scourge throws off the Burning Legion before Archimonde arrives.
/// </summary>
public sealed class PathLichKingBreaksFree : FactionPath
{
  private const int EarliestTurn = 20;

  private readonly ScourgeSplitEvent _split;

  public PathLichKingBreaksFree(ScourgeSplitEvent split)
  {
    _split = split;
    Name = "The Lich King Breaks Free";
    IconName = "HeroLich";
    Description = "The Lich King has grown strong enough to defy his masters. Break free of the Burning Legion and fight on your own terms. Both sides grow stronger in their hatred of each other.";
    AddRequirement(new ObjectiveTurn(EarliestTurn) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _split.HappenNow(faction.ColoredName);
}
