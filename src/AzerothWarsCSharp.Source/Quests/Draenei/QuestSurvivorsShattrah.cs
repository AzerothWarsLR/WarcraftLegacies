using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public class QuestSurvivorsShattrah{

  
    private const int QUESTRESEARCH_ID = FourCC(R082)   ;//This research is given when the quest is completed
  



    protected override string CompletionPopup => 
      return "The hero Maraad is now trainable at the Altar";
    }

    protected override string CompletionDescription => 
      return "Maraad will join the survivors on the Exodar";
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Survivors of Shattrah", "The Shattrah massacre was swift && brutal, if (the Draenei hold long enough in Outland, they might regroup with some of the survivors.", "ReplaceableTextures\\CommandButtons\\BTNGlazeroth.blp");
      this.AddQuestItem(QuestItemTime.create(480));
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_EXODARSHIP));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUESTRESEARCH_ID;
      ;;
    }


  }
}
