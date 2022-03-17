public class QuestSentinelsKillFrostwolf{

  
    private const int RESEARCH_ID = FourCC(R052);
    private const int AMARA_ID = FourCC(h03I);
  


    private string operator CompletionPopup( ){
      return "The Frostwolves have been ousted from Kalimdor, along with their Tauren allies. They will !be missed.";
    }

    private string operator CompletionDescription( ){
      return "The demihero Amara && the hero Jarod";
    }

    private void OnComplete( ){
      SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1);
      DisplayUnitTypeAcquired(this.Holder.Player, AMARA_ID, "You can now revive Amara from the Altar of Elders.");
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(AMARA_ID, 1);
      this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Drive Them Back", "The Frostwolf Clan is beginning to seize a firm foothold within the Barrens && on the plains of Mulgore. They must be driven back.", "ReplaceableTextures\\CommandButtons\\BTNThrall.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_THUNDERBLUFF));
      ;;
    }


}
