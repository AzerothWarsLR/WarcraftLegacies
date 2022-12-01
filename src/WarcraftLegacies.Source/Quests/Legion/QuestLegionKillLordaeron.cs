using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Legion
{
  public sealed class QuestLegionKillLordaeron : QuestData
  {
    public QuestLegionKillLordaeron() : base("Token Resistance",
      "The Kingdom of Lordaeron must be eliminated to pave the way for the Legion's arrival.",
      "ReplaceableTextures\\CommandButtons\\BTNTichondrius.blp")
    {
      AddObjective(new ObjectiveLegendDead(LegendLordaeron.CapitalPalace));
      AddObjective(new ObjectiveLegendDead(LegendLordaeron.Stratholme));
      AddObjective(new ObjectiveLegendDead(LegendLordaeron.TyrsHand));
    }

    protected override string CompletionPopup =>
      "The Kingdom of Lordaeron has fallen, eliminating AzerothFourCC(s vanguard against the Legion.";

    protected override string RewardDescription => "Tichondrius gains 15 Strength, Agility and Intelligence";

    protected override void OnComplete(Faction completingFaction)
    {
      LegendLegion.LEGEND_TICHONDRIUS.Unit.DisplayHeroReward(15, 15, 15, 0);
      LegendLegion.LEGEND_TICHONDRIUS.Unit.AddHeroAttributes(15, 15, 15);
    }
  }
}