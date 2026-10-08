using MacroTools.Factions;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Sentinels.Paths;

/// <summary>
/// The Sentinels leave the Night Elves to join whichever Alliance team is smaller.
/// </summary>
public sealed class PathWardensVengeanceAlliance : PathWardensVengeance
{
  public PathWardensVengeanceAlliance(ObjectiveTriggered illidanReturned) : base(illidanReturned)
  {
    Name = "Wardens' Vengeance: The Alliance";
    Description = "Maiev will not fight beside the Betrayer. Leave the Night Elves and join the Alliance against him, standing with whichever of its kingdoms needs you most.";
  }

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) =>
    TeamSetup.NorthAlliance.UndefeatedPlayerCount < TeamSetup.SouthAlliance.UndefeatedPlayerCount
      ? TeamSetup.NorthAlliance
      : TeamSetup.SouthAlliance;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
  }
}
