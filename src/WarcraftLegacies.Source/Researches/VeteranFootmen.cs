using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ResearchSystems;


namespace WarcraftLegacies.Source.Researches
{
  /// <summary>
  /// When Veteran Footman is researched, the researching player loses the ability to train Footmen,
  /// and gains the ability to train Veteran Footmen.
  /// </summary>
  public sealed class VeteranFootmen : Research
  {
    /// <inheritdoc />
    public VeteranFootmen(int researchTypeId, int goldCost, int lumberCost) : base(researchTypeId, goldCost, lumberCost)
    {
    }

    /// <inheritdoc />
    public override void OnResearch(player researchingPlayer)
    {
      var faction = researchingPlayer.GetFaction();
      faction?.ModObjectLimit(Constants.UNIT_HFOO_FOOTMAN_LORDAERON, -Faction.UNLIMITED);
      faction?.ModObjectLimit(Constants.UNIT_H029_VETERAN_FOOTMAN_LORDAERON, Faction.UNLIMITED);
    }
  }
}