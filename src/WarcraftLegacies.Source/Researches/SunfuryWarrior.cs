using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ResearchSystems;


namespace WarcraftLegacies.Source.Researches
{
  /// <summary>
  /// When Veteran Footman is researched, the researching player loses the ability to train Footmen,
  /// and gains the ability to train Veteran Footmen.
  /// </summary>
  public sealed class SunfuryWarrior : Research
  {
    /// <inheritdoc />
    public SunfuryWarrior(int researchTypeId, int goldCost, int lumberCost) : base(researchTypeId, goldCost, lumberCost)
    {
    }

    /// <inheritdoc />
    public override void OnResearch(player researchingPlayer)
    {
      var faction = researchingPlayer.GetFaction();
      faction?.ModObjectLimit(Constants.UNIT_HHES_SWORDSMAN_QUEL_THALAS, -Faction.UNLIMITED);
      faction?.ModObjectLimit(Constants.UNIT_NBEL_SUNFURY_WARRIOR_QUEL_THALAS, Faction.UNLIMITED);
    }
  }
}