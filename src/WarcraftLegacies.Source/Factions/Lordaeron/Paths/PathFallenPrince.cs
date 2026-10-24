using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Lordaeron.Paths;

/// <summary>Lets Lordaeron become the Fallen Prince once Stratholme and Arthas have fallen.</summary>
public sealed class PathFallenPrince : FactionPath
{
  private readonly FallenPrinceTransformation _transformation;

  public PathFallenPrince(FallenPrinceTransformation transformation, Capital stratholme, LegendaryHero arthas)
  {
    _transformation = transformation;
    Name = "The Fallen Prince";
    IconName = "HeroDeathKnight";
    Description = "With Stratholme in ashes and the prince slain, Arthas rises again as a death knight. His kingdom lost, he raises the dead of Stratholme and Northrend and marches with the Scourge.";
    AddRequirement(new ObjectiveCapitalDead(stratholme) { ShowsInQuestLog = false });
    AddRequirement(new ObjectiveLegendDead(arthas) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction)
  {
    if (!FactionManager.TryGetFactionByType<ScourgeFaction>(out var scourge))
    {
      return null;
    }

    var scourgePlayer = scourge.Player;
    return scourgePlayer == null ? null : scourgePlayer.GetPlayerData().Team;
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction) => _transformation.Execute(faction);
}
