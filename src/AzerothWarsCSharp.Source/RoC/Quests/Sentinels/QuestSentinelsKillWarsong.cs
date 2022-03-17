public class QuestSentinelsKillWarsong{

  
    private const int RESEARCH_ID = FourCC(R007);
  


    private string operator CompletionPopup( ){
      return "The Warsong presence on Kalimdor has been eliminated. The land has been protected from their misbegotten race.";
    }

    private string operator CompletionDescription( ){
      return "Enable the Watcher Bastion to be built";
    }

    private void OnComplete( ){
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
