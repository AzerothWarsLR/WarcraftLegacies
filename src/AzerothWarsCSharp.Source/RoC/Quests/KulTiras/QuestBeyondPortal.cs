public class QuestBeyondPortal{

 
    private const int QUEST_RESEARCH_ID = FourCC(R085)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "The orcs are no more && we can now train Fusillier.";
    }

    private string operator CompletionDescription( ){
      return "You will be able to train Fusillier from the Barrack";
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Beyond the Dark Portal", "The Orc threat from Draenor still looms over all. Eliminate every trace of the Orcs && their bases.", "ReplaceableTextures\\CommandButtons\\BTNDarkPortal.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_BLACKTEMPLE, false));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_HELLFIRECITADEL));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_BLACKROCKSPIRE));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


}
