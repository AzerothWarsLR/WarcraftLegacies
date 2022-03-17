public class QuestJinthaAlor{

  
    private const int JINTHAALOR_RESEARCH = FourCC(R02N);
    private const int BEAR_RIDER_ID = FourCC(o02K);
    private const int TROLL_SHRINE_ID = FourCC(o04X);
  


    private string operator CompletionPopup( ){
      return "JinthaFourCC(Alor has fallen. The Vilebranch trolls lend their might to the " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Control of JinthaFourCC(Alor, 300 gold tribute && the ability to train " + GetObjectName(BEAR_RIDER_ID) + "s from the " + GetObjectName(TROLL_SHRINE_ID);
    }

    private void OnComplete( ){
      SetPlayerTechResearched(Holder.Player, JINTHAALOR_RESEARCH, 1);
      AdjustPlayerStateBJ( 300, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(JINTHAALOR_RESEARCH, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Ancient Egg", "The Vilebranch trolls of JinthaFourCC(Alor are controlled by their fear of the Soulflayer)s egg, hidden within their shrine. Smash it to gain their loyalty.", "ReplaceableTextures\\CommandButtons\\BTNForestTrollShadowPriest.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_JINTHAALOR, false));
      ;;
    }


}
