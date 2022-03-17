public class QuestSapphiron{

  
    private const int SAPPHIRON_ID = FourCC(ubdd);
    private const int SAPPHIRON_RESEARCH = FourCC(R025);
  


    private string operator CompletionPopup( ){
      return "Sapphiron has been slain, && has been reanimated as a mighty Frost Wyrm under the command of the Scourge.";
    }

    private string operator CompletionDescription( ){
      return "The demihero Sapphiron";
    }

    private void OnComplete( ){
      CreateUnit(this.Holder.Player, SAPPHIRON_ID, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()), GetUnitFacing(GetTriggerUnit()));
      SetPlayerTechResearched(this.Holder.Player, SAPPHIRON_RESEARCH, 1);
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(SAPPHIRON_RESEARCH, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Sapphiron", "Kill Sapphiron the Blue Dragon to have KelFourCC(Tuzad reanimate her as a Frost Wyrm. Sapphiron can be found in Northrend.", "ReplaceableTextures\\CommandButtons\\BTNFrostWyrm.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_ubdr_0668));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_KELTHUZAD, false));
      ;;
    }


}
