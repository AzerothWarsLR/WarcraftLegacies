using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public class QuestSentinelsKillWarsong{

  
    private const int RESEARCH_ID = FourCC(R007);
  


    protected override string CompletionPopup => 
      return "The Warsong presence on Kalimdor has been eliminated. The land has been protected from their misbegotten race.";
    }

    protected override string CompletionDescription => 
      return "Enable the Watcher Bastion to be built";
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Green-skinned Brutes", "The Warsong Clan has arrived near Ashenvale && begun threatening the wilds. These invaders must be repelled.", "ReplaceableTextures\\CommandButtons\\BTNRaider.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_STONEMAUL));
      ;;
    }


  }
}
