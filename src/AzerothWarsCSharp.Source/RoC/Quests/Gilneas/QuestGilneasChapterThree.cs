//Kill Arugal
public class QuestGilneasChapterThree{

   
    private const int RESEARCH_ID = FourCC(R02R);
  



    private string operator CompletionPopup( ){
      return "Tess has acquired the Scythe of Elune && saved the Worgen.";
    }

    private string operator CompletionDescription( ){
      return "A return to the Alliance of Lordaeron. If you manage to keep Genn Greymane alive, you gain him as a hero";
    }

    private void OnComplete( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
      SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1);
      GOLDRINNELVE_PATH.Progress = QUEST_PROGRESS_INCOMPLETE;
      GOLDRINNHUMAN_PATH.Progress = QUEST_PROGRESS_INCOMPLETE;
      RescueNeutralUnitsInRect(gg_rct_DarnassusWorgen, this.Holder.Player);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }


    public  thistype ( ){
      thistype this = thistype.allocate("Chapter Three: The Blackwald", "Killing Arugal will bring an end to the Worgen Curse, he holds the Scythe of Elune that will give the worgen their sanity", "ReplaceableTextures\\CommandButtons\\BTNfinger of death .blp");
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_TESS, gg_rct_StartQuest3, "The city is safe"));
      this.AddQuestItem(QuestItemLegendHasArtifact.create(LEGEND_TESS, ARTIFACT_SCYTHEOFELUNE));
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_GENN));
      ;;
    }


}
