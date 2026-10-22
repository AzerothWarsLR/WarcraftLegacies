using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Paths;
using WarcraftLegacies.Source.Factions.FallenPrince;
using WarcraftLegacies.Source.Factions.Scourge;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Quelthalas.Paths;

/// <summary>Lets Quel'thalas become the Banshee's Host once the Scourge kills Sylvanas and Windrunner Spire is lost.</summary>
public sealed class PathBansheesHost : FactionPath
{
  private readonly BansheesHostTransformation _transformation;

  public PathBansheesHost(BansheesHostTransformation transformation, LegendaryHero sylvanas, Capital windrunnerSpire)
  {
    _transformation = transformation;
    Name = "The Banshee's Host";
    IconName = "Banshee";
    Description = "Slain by the Scourge and driven from Windrunner Spire, Sylvanas rises again as a banshee. Her kingdom lost, she gathers the restless spirits of her people at Deathknell and En'kilah, and leads them to the Scourge's side.";
    AddRequirement(new ObjectiveLegendKilledBy(sylvanas, "the Scourge", IsScourge) { ShowsInQuestLog = false });
    AddMustStayTrueRequirement(new ObjectiveCapitalNotControlled(windrunnerSpire) { ShowsInQuestLog = false });
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

  private static bool IsScourge(player whichPlayer)
  {
    var faction = whichPlayer.GetPlayerData().Faction;
    return faction is ScourgeFaction || faction is FallenPrinceFaction;
  }
}
