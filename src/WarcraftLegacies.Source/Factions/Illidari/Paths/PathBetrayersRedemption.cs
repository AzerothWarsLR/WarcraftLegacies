using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Illidari.Paths;

/// <summary>Lets the Illidari join the Night Elves once the Night Elves are losing.</summary>
public sealed class PathBetrayersRedemption : FactionPath
{
  private const int HordeThreshold = 2;
  private const int NightElfThreshold = 2;
  private const int CapitalsLost = 2;

  public PathBetrayersRedemption()
  {
    Name = "The Betrayer's Redemption";
    IconName = "HeroDemonHunter";
    Description = "The night elves are hard pressed and their old enemies grow strong. Illidan returns from exile to stand with his people once more, whether they want him or not.";
    var outnumbered = new ObjectiveTeamCondition(
      "The Horde has more than 2 members, or the Night Elves have fewer than 2",
      () => TeamSetup.Horde.UndefeatedPlayerCount > HordeThreshold ||
            TeamSetup.NightElves.UndefeatedPlayerCount < NightElfThreshold);
    var losingLands = new ObjectiveTeamLostCapitals(TeamSetup.NightElves, CapitalsLost,
      AllLegends.Druids.Nordrassil, AllLegends.Druids.TempleOfTheMoon, AllLegends.Sentinels.Auberdine,
      AllLegends.Sentinels.Feathermoon, AllLegends.Sentinels.VaultOfTheWardens);
    AddMustStayTrueRequirement(new ObjectiveEitherOf(outnumbered, losingLands,
      "The Night Elves are outnumbered or have lost 2 of their capitals")
    { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.NightElves;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
  }
}
