using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestBeyondPortal : QuestData
  {
    public QuestBeyondPortal() : base("Beyond the Dark Portal",
      "The Orc threat from Draenor still looms over all. Eliminate every trace of the Orcs && their bases.",
      "ReplaceableTextures\\CommandButtons\\BTNDarkPortal.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendFelHorde.LegendBlacktemple, false));
      AddQuestItem(new QuestItemLegendDead(LegendFelHorde.LegendHellfirecitadel));
      AddQuestItem(new QuestItemLegendDead(LegendFelHorde.LegendBlackrockspire));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = FourCC("R085");
    }
    
    protected override string CompletionPopup => "The orcs are no more and we can now train Fusillier.";

    protected override string RewardDescription => "You will be able to train Fusillier from the Barrack";
  }
}