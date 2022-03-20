using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public class QuestTownWatch{

  
    private const int QUEST_RESEARCH_ID = FourCC(R077)   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => 
      return "The Cultists have been eliminated. Our towns are now safe.";
    }

    protected override string CompletionDescription => 
      return "Gain 4000 lumber && 500 gold";
    }

    protected override void OnComplete(){
      AdjustPlayerStateBJ( 500, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
      AdjustPlayerStateBJ( 4000, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Cult of the Damned", "Unholy Cultists are spreading a deadly plague among the villages of Lordaeron. We must stop them, prevent the corruption, && kill all the Cultists.", "ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp");
      this.AddQuestItem(QuestItemResearch.create(FourCC(Rhse), )h083)));
      this.AddQuestItem(QuestItemBuild.create(FourCC(h084), 8));
      this.AddQuestItem(QuestItemKillXUnit.create(FourCC(u01U), 3));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
