using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Researches;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Researches;

/// <summary>Swaps the researching player's Risen Footmen for Risen Captains.</summary>
public sealed class RisenVeterans : Research
{
  /// <inheritdoc />
  public RisenVeterans(int researchTypeId, int goldCost, int lumberCost = 0) : base(researchTypeId, goldCost, lumberCost)
  {
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var faction = researchingPlayer.GetPlayerData().Faction;
    faction?.ModObjectLimit(UNIT_U101_RISEN_FOOTMAN_FALLENPRINCE, -Faction.Unlimited);
    faction?.ModObjectLimit(UNIT_U102_RISEN_CAPTAIN_FALLENPRINCE, Faction.Unlimited);
  }
}
