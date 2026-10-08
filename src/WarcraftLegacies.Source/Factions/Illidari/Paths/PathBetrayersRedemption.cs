using MacroTools.Factions;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Illidari.Paths;

/// <summary>
/// With the Night Elves outnumbered, Illidan returns to his people to fight beside them.
/// </summary>
public sealed class PathBetrayersRedemption : FactionPath
{
  private const int HordeThreshold = 2;
  private const int NightElfThreshold = 2;

  public PathBetrayersRedemption()
  {
    Name = "The Betrayer's Redemption";
    IconName = "HeroDemonHunter";
    Description = "The night elves are hard pressed and their old enemies grow strong. Illidan returns from exile to stand with his people once more, whether they want him or not.";
    AddMustStayTrueRequirement(new ObjectiveTeamCondition(
      "The Horde has more than 2 members, or the Night Elves have fewer than 2",
      () => TeamSetup.Horde.UndefeatedPlayerCount > HordeThreshold ||
            TeamSetup.NightElves.UndefeatedPlayerCount < NightElfThreshold) { ShowsInQuestLog = false });
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
