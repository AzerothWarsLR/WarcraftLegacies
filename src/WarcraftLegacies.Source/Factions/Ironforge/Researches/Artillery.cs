using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Researches;

namespace WarcraftLegacies.Source.Factions.Ironforge.Researches;

/// <summary>
/// When Artillery is researched, the researching player loses the ability to train Steam Tanks,
/// and gains the ability to train Artillery Tanks.
/// </summary>
public sealed class Artillery : Research
{
  /// <inheritdoc />
  public Artillery(int researchTypeId, int goldCost, int lumberCost = 0) : base(researchTypeId, goldCost, lumberCost)
  {
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var faction = researchingPlayer.GetPlayerData().Faction;
    faction?.ModObjectLimit(UNIT_H01P_STEAM_TANK_IRONFORGE, -Faction.Unlimited);
    faction?.ModObjectLimit(UNIT_TP02_ARTILLERY_TANK_IRONFORGE, Faction.Unlimited);
  }
}
