


  
    using AzerothWarsCSharp.MacroTools.FactionSystem;
    using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

    private static readonly int researchId = FourCC("R022");
  


    protected override string completionPopup => 

    }

    protected override string completionDescription => 

    }

    protected override void OnComplete(){
      if (GetLocalPlayer() == this.Holder.Player){
        PingMinimap(GetUnitX(gg_unit_h053_1121), GetUnitY(gg_unit_h053_1121), 5);
        PingMinimap(GetUnitX(gg_unit_h055_0035), GetUnitY(gg_unit_h055_0035), 5);
      }
      SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1);
    }

    protected override void OnAdd( ){
      this.Holder.ModObjectLimit(RESEARCH_ID, Faction.UNLIMITED);
    }

    public  thistype ( ){

      this.AddQuestItem(new QuestItemTime(360));
      
    }


}
