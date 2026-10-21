using WarcraftLegacies.Source.Factions.Forsaken;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Paths;

/// <summary>Sylvanas breaks free of the Lich King's will, but keeps the Forsaken at the Scourge's side for now.</summary>
public sealed class PathRiseOfTheForsakenScourge : PathRiseOfTheForsaken
{
  public PathRiseOfTheForsakenScourge()
  {
    Name = "Rise of the Forsaken: The Scourge";
    Description = "With the Icecrown Obelisks shattered, Sylvanas's will is her own once more, but vengeance can wait. The Forsaken keep their hold in Northrend and fight on beside the Scourge, and claim the ruins of Capital City as their home once it falls to their allies.";
  }

  /// <inheritdoc />
  protected override void OnBecameForsaken(ForsakenBases bases) => bases.ClaimUndercity(true);
}
