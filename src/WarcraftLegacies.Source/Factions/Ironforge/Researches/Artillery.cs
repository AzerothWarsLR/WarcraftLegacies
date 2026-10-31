using MacroTools.Extensions;
using MacroTools.Researches;

namespace WarcraftLegacies.Source.Factions.Ironforge.Researches;

/// <summary>
/// When Artillery is researched, the researching player loses the ability to train Steam Tanks,
/// and gains the ability to train Artillery Tanks.
/// </summary>
public sealed class Artillery : Research
{
  private readonly int _steamTank;
  private readonly int _artilleryTank;

  /// <inheritdoc />
  public Artillery(int researchTypeId, int steamTank, int artilleryTank, int goldCost, int lumberCost = 0)
    : base(researchTypeId, goldCost, lumberCost)
  {
    _steamTank = steamTank;
    _artilleryTank = artilleryTank;
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var faction = researchingPlayer.GetPlayerData().Faction;
    faction?.ModObjectLimit(_steamTank, -3);
    faction?.ModObjectLimit(_artilleryTank, 3);
  }
}
