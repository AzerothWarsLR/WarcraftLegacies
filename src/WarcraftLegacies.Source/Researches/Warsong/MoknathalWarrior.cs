using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Researches;

namespace WarcraftLegacies.Source.Researches.Warsong;

/// <summary>
/// When Mok'nathal Warriors' is researched, the researching player loses the ability to train Warsong Grunts,
/// and gains the ability to train Mok'nathal Warriors.
/// </summary>
public sealed class MoknathalWarrior : Research
{
  /// <inheritdoc />
  public MoknathalWarrior(int researchTypeId, int goldCost) : base(researchTypeId, goldCost)
  {
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var faction = researchingPlayer.GetPlayerData().Faction;
    if (faction != null)
    {
      faction.ModObjectLimit(UNIT_HFOO_LORDAERON, -Faction.Unlimited);
      faction.ModObjectLimit(UNIT_H029_VETERAN_FOOTMAN_LORDAERON, Faction.Unlimited);
    }
  }
}
