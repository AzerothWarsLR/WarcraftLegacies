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
    Description = "Break the Lich King's chains. The Scourge leaves the Burning Legion's team after a ceasefire, and both sides gain a Power from the betrayal.";
    AddRequirement(new ObjectiveTurn(EarliestTurn) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _split.HappenNow();
}
