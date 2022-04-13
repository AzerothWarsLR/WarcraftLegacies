using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Quests.Legion
{
  public sealed class QuestLegionKillLordaeron : QuestData
  {
    public QuestLegionKillLordaeron() : base("Token Resistance",
      "The Kingdom of Lordaeron must be eliminated to pave the way for the Legion's arrival.",
      "ReplaceableTextures\\CommandButtons\\BTNTichondrius.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LegendLordaeron.LegendCapitalpalace));
      AddQuestItem(new QuestItemLegendDead(LegendLordaeron.LegendStratholme));
      AddQuestItem(new QuestItemLegendDead(LegendLordaeron.LegendTyrshand));
    }

    protected override string CompletionPopup =>
      "The Kingdom of Lordaeron has fallen, eliminating AzerothFourCC(s vanguard against the Legion.";

    protected override string RewardDescription => "Tichondrius gains 15 Strength, Agility and Intelligence";

    protected override void OnComplete()
    {
      Display.DisplayHeroReward(LegendLegion.LEGEND_TICHONDRIUS.Unit, 15, 15, 15, 0);
      AddHeroAttributes(LegendLegion.LEGEND_TICHONDRIUS.Unit, 15, 15, 15);
    }
  }
}