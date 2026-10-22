using MacroTools.Extensions;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;

namespace WarcraftLegacies.Source.Factions.Forsaken.Researches;

/// <summary>Lets the town halls train Dark Rangers in place of Wailing Sorrows, whose Chaos ability raises them as Dark Rangers.</summary>
public sealed class DarkRangers : Research
{
  /// <inheritdoc />
  public DarkRangers(int researchTypeId, int goldCost, int lumberCost = 0) : base(researchTypeId, goldCost, lumberCost)
  {
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var faction = researchingPlayer.GetPlayerData().Faction;
    if (faction == null)
    {
      return;
    }

    faction.ModObjectLimit(UNIT_U10A_WAILING_SORROW_BANSHEESHOST_ELITE, -ForsakenObjectInfo.EliteLimit);
    faction.ModObjectLimit(UNIT_N0BY_DARK_RANGER_FORSAKEN, ForsakenObjectInfo.EliteLimit);
  }
}
