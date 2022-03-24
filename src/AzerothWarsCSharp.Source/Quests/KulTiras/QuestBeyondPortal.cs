using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestBeyondPortal : QuestData
  {
    private static readonly int QUEST_RESEARCH_ID = FourCC("R085"); //This research is given when the quest is completed

    public QuestBeyondPortal() : base("Beyond the Dark Portal",
      "The Orc threat from Draenor still looms over all. Eliminate every trace of the Orcs && their bases.",
      "ReplaceableTextures\\CommandButtons\\BTNDarkPortal.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LEGEND_BLACKTEMPLE, false));
      AddQuestItem(new QuestItemLegendDead(LEGEND_HELLFIRECITADEL));
      AddQuestItem(new QuestItemLegendDead(LEGEND_BLACKROCKSPIRE));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QUEST_RESEARCH_ID;
      ;
      ;
    }


    protected override string CompletionPopup => "The orcs are no more && we can now train Fusillier.";

    protected override string CompletionDescription => "You will be able to train Fusillier from the Barrack";
  }
}