//Survive and defend the city
public class QuestGilneasChapterTwo{



    private string operator CompletionPopup( ){
      return "The origin of the curse has been found, the wizard Arugal is the culprit.";
    }

    private string operator CompletionDescription( ){
      return "Chapter Three: The Blackwald";
    }

    private void OnComplete( ){
      FACTION_GILNEAS.AddQuest(GOLDRINNELVE_PATH);
      GOLDRINNELVE_PATH.Progress = QUEST_PROGRESS_UNDISCOVERED;
      FACTION_GILNEAS.AddQuest(GOLDRINNHUMAN_PATH);
      GOLDRINNHUMAN_PATH.Progress = QUEST_PROGRESS_UNDISCOVERED;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Chapter Two: The Defense of Gilneas", "Defend the city until a cure for the curse of worgen is found. Do !let the Cathedral && Castle be destroyed", "ReplaceableTextures\\CommandButtons\\BTNGilneanCastle.blp");
     this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_TESS, gg_rct_Chapter2Start, "Base camp"));
     this.AddQuestItem(QuestItemTime.create(940));
      ;;
    }


}
