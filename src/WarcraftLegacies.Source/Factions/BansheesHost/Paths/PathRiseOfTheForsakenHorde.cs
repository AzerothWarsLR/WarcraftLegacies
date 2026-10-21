using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.Forsaken;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Paths;

/// <summary>The Forsaken abandon Northrend and the Scourge, and join the Horde.</summary>
public sealed class PathRiseOfTheForsakenHorde : PathRiseOfTheForsaken
{
  public PathRiseOfTheForsakenHorde()
  {
    Name = "Rise of the Forsaken: The Horde";
    Description = "With the Icecrown Obelisks shattered, the Lich King's hold on the dead is failing, and Sylvanas's will is her own once more. Abandon Northrend, cast off his chains, and seek allies among the outcasts of the Horde, beginning with a foothold in Orgrimmar. Capital City will be your home once your new allies take it.";
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction) => TeamSetup.Horde;

  /// <inheritdoc />
  protected override void OnBecameForsaken(ForsakenBases bases)
  {
    bases.MoveToOrgrimmar();
    bases.ClaimUndercity(false);
  }
}
