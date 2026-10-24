using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Forsaken;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Paths;

/// <summary>Sylvanas breaks free of the Lich King's will, but keeps the Forsaken at the Scourge's side for now.</summary>
public sealed class PathRiseOfTheForsakenScourge : PathRiseOfTheForsaken
{
  public PathRiseOfTheForsakenScourge(QuestData bansheesVengeance, QuestData rangerLord) : base(bansheesVengeance, rangerLord)
  {
    Name = "Rise of the Forsaken: The Scourge";
    Description = "Sylvanas's will is her own once more, but vengeance can wait. Hold Northrend and fight on beside the Scourge for now. Beneath Capital City, the Undercity waits to become your home.";
  }

  /// <inheritdoc />
  protected override void OnBecameForsaken(ForsakenBases bases)
  {
  }
}
