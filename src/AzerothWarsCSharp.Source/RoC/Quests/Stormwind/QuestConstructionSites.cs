


  
    private const int RESEARCH_ID = FourCC(R022);
  


    private string operator CompletionPopup( ){

    }

    private string operator CompletionDescription( ){

    }

    private void OnComplete( ){
      if (GetLocalPlayer() == this.Holder.Player){
        PingMinimap(GetUnitX(gg_unit_h053_1121), GetUnitY(gg_unit_h053_1121), 5);
        PingMinimap(GetUnitX(gg_unit_h055_0035), GetUnitY(gg_unit_h055_0035), 5);
      }
      SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1);
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){

      this.AddQuestItem(QuestItemTime.create(360));
      ;;
    }


}
