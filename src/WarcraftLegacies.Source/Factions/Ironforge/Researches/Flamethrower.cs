using MacroTools.Extensions;
using MacroTools.Researches;

namespace WarcraftLegacies.Source.Factions.Ironforge.Researches;

/// <summary>
/// When Flamethrower is researched, the researching player loses the ability to train Steam Tanks,
/// and gains the ability to train Flame Tanks.
/// </summary>
public sealed class Flamethrower : Research
{
  private readonly int _steamTank;
  private readonly int _flameTank;

  /// <inheritdoc />
  public Flamethrower(int researchTypeId, int steamTank, int flameTank, int goldCost, int lumberCost = 0)
    : base(researchTypeId, goldCost, lumberCost)
  {
    _steamTank = steamTank;
    _flameTank = flameTank;
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var faction = researchingPlayer.GetPlayerData().Faction;
    faction?.ModObjectLimit(_steamTank, -3);
    faction?.ModObjectLimit(_flameTank, 3);
  }
}
