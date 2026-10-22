using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Forsaken;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Paths;

/// <summary>The Forsaken abandon Northrend and the Scourge, and join the Horde.</summary>
public sealed class PathRiseOfTheForsakenHorde : PathRiseOfTheForsaken
{
  public PathRiseOfTheForsakenHorde(QuestData bansheesVengeance, QuestData rangerLord) : base(bansheesVengeance, rangerLord)
  {
    Name = "Rise of the Forsaken: The Horde";
    Description = "The Lich King's hold on the dead is failing, and Sylvanas's will is her own once more. Abandon Northrend, cast off his chains, and seek allies among the outcasts of the Horde, beginning with a foothold in Orgrimmar. Take Capital City yourself to make the Undercity your home.";
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.Horde;

  /// <inheritdoc />
  protected override void OnBecameForsaken(ForsakenBases bases)
  {
    bases.MoveToOrgrimmar();
  }
}
