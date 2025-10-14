using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ResearchSystems;

namespace WarcraftLegacies.Source.Researches;

/// <summary>
/// When Veteran Footman is researched, the researching player loses the ability to train Footmen,
/// and gains the ability to train Veteran Footmen.
/// </summary>
public sealed class SunfuryWarrior : Research
{
  /// <inheritdoc />
  public SunfuryWarrior(int researchTypeId, int goldCost) : base(researchTypeId, goldCost)
  {
  }

  /// <inheritdoc />
  public override void OnResearch(player researchingPlayer)
  {
    var faction = researchingPlayer.GetPlayerData().Faction;
    faction?.ModObjectLimit(UNIT_HHES_SWORDSMAN_QUELTHALAS, -Faction.Unlimited);
    faction?.ModObjectLimit(UNIT_NBEL_SUNFURY_WARRIOR_QUELTHALAS, Faction.Unlimited);
  }
}
