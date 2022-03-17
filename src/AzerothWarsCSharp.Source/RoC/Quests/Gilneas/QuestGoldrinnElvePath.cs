using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Gilneas
{
  public class QuestGoldrinnElvePath{

  
    private const int QUEST_RESEARCH_ID = FourCC(R07U)   ;//This research is given when the quest is completed
  



    boolean operator Global( ){
      return true;
    }

    private string operator CompletionPopup( ){
      return "Goldrinn has joined Gilneas && they have joined the Night Elves";
    }

    private string operator CompletionDescription( ){
      return "Goldrinn will be trainable at the altar";
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Shrine of the Wolf God", "To understand the plight of her people, Tess will go to the Night Elves to understand what it is to be a Worgen. She needs to reach the Shrine of Goldrinn in Mount Hyjal", "ReplaceableTextures\\CommandButtons\\BTNWorgenMoon.blp");
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_TESS, gg_rct_GoldrinnHyjal, "Shrine of Goldrinn in Mount Hyjal"));
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_GENN));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
