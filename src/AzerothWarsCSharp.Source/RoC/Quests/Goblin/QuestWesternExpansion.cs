public class QuestWesternExpansion{

  
    private const int QUEST_RESEARCH_ID = FourCC(R07Y);
  


    private string operator CompletionPopup( ){
      return "The western shores are now clear of pesky elves, our business expansion can continue && our Zeppelins can fly safe.";
    }

    private string operator CompletionDescription( ){
      return "Learn to train " + GetObjectName(FourCC(h091)) + "s";
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Western Expansion", "Feathermoon Stronghold && Auberdine give the Elves a grip on the western shore of Kalimdor. We need to destroy them to clear a way for our business expansion west!", "ReplaceableTextures\\CommandButtons\\BTNNightElfShipyard.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_FEATHERMOON));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_AUBERDINE));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


}
