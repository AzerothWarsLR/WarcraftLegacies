using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Researches;

namespace WarcraftLegacies.Source.Factions.Lordaeron.Researches;

/// <summary>
/// When Veteran Footman is researched, the researching player loses the ability to train Footmen,
/// and gains the ability to train Veteran Footmen.
/// </summary>
public sealed class VeteranFootmen : Research
{
  /// <inheritdoc />
  public VeteranFootmen(int researchTypeId, int goldCost, int lumberCost =0) : base(researchTypeId, goldCost, lumberCost)
  {
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var faction = researchingPlayer.GetPlayerData().Faction;
    faction?.ModObjectLimit(UNIT_HFOO_FOOTMAN_LORDAERON, -Faction.Unlimited);
    faction?.ModObjectLimit(UNIT_H029_VETERAN_FOOTMAN_LORDAERON, Faction.Unlimited);
  }
}
