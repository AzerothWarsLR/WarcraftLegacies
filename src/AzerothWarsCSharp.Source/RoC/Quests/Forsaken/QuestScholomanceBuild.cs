using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Forsaken
{
  public class QuestScholomanceBuild{

  
    private const int QUEST_RESEARCH_ID = FourCC(R04Z)   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => 
      return "Putress is now trainable.";
    }

    protected override string CompletionDescription => 
      return "Putress is trainable at the altar";
    }

    protected override void OnComplete(){
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){

      this.AddQuestItem(QuestItemBuild.create(FourCC(u011), 2));
      this.AddQuestItem(QuestItemBuild.create(FourCC(h08C), 20));
      this.AddQuestItem(QuestItemBuild.create(FourCC(u014), 1));
      this.AddQuestItem(QuestItemBuild.create(FourCC(u01J), 2));
      this.AddQuestItem(QuestItemUpgrade.create(FourCC(h08B), )h089)));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
