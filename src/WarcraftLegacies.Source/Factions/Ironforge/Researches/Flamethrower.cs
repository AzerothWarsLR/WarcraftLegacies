using MacroTools.Extensions;
using MacroTools.Researches;

namespace WarcraftLegacies.Source.Factions.Ironforge.Researches;

/// <summary>
/// When Flamethrower is researched, the researching player loses the ability to train Steam Tanks,
/// and gains the ability to train Flame Tanks.
/// </summary>
public sealed class Flamethrower : Research
{
  /// <inheritdoc />
  public Flamethrower(int researchTypeId, int goldCost, int lumberCost = 0) : base(researchTypeId, goldCost, lumberCost)
  {
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var faction = researchingPlayer.GetPlayerData().Faction;
    faction?.ModObjectLimit(UNIT_H01P_STEAM_TANK_IRONFORGE, -3);
    faction?.ModObjectLimit(UNIT_TP01_FLAME_TANK_IRONFORGE, 3);
  }
}
