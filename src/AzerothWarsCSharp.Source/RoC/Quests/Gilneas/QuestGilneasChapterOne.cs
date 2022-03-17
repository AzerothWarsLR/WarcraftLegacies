//Reach Gilneas City

using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Gilneas
{
  public class QuestGilneasChapterOne{



    private string operator CompletionPopup( ){
      return "Gilneas City is under attack, you must defend it at all cost.";
    }

    private string operator CompletionDescription( ){
      return "Chapter Two - The defense of Gilneas";
    }

    private void OnComplete( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Chapter One: The Outskirts", "The road to Gilneas City is full of dangers, hurry to the city", "ReplaceableTextures\\CommandButtons\\BTNworgen.blp");
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_TESS, gg_rct_Chapter2Map, "Gilneas City"));
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_TESS));
      ;;
    }


  }
}
