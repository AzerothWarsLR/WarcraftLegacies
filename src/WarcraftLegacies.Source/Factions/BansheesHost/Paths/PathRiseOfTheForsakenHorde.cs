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
    Description = "Sylvanas's will is her own once more. Cast off the Lich King's chains, leave Northrend behind and seek allies among the Horde from an outpost in Durotar. Beneath Capital City, the Undercity waits to become your home.";
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.Horde;

  /// <inheritdoc />
  protected override void OnBecameForsaken(ForsakenBases bases)
  {
    bases.MoveToDurotar();
  }
}
