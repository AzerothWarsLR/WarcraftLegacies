using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Forsaken;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Paths;

/// <summary>Sylvanas breaks free of the Lich King's will, but keeps the Forsaken at the Scourge's side for now.</summary>
public sealed class PathRiseOfTheForsakenScourge : PathRiseOfTheForsaken
{
  public PathRiseOfTheForsakenScourge(QuestData bansheesVengeance, QuestData rangerLord) : base(bansheesVengeance, rangerLord)
  {
    Name = "Rise of the Forsaken: The Scourge";
    Description = "The Lich King's hold on the dead is failing, and Sylvanas's will is her own once more, but vengeance can wait. The Forsaken keep their hold in Northrend and fight on beside the Scourge, and can take Capital City to make the Undercity their home.";
  }

  /// <inheritdoc />
  protected override void OnBecameForsaken(ForsakenBases bases)
  {
  }
}
