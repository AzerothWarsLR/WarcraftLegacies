public class QuestShipArgus{



    boolean operator Global( ){
      return true;
    }

    private string operator CompletionPopup( ){
      return "Velen has opened the portal to Argus";
    }

    private string operator CompletionDescription( ){
      return "Open a Portal between Tempest Keep && Argus";
    }

    private void OnComplete( ){
      WaygateActivateBJ( true, gg_unit_h03V_3538 );
      ShowUnitShow( gg_unit_h03V_3538 );
      WaygateSetDestinationLocBJ( gg_unit_h03V_3538, GetRectCenter(gg_rct_OutlandToArgus) );
      WaygateActivateBJ( true, gg_unit_h03V_3539 );
      ShowUnitShow( gg_unit_h03V_3539 );
      WaygateSetDestinationLocBJ( gg_unit_h03V_3539, GetRectCenter(gg_rct_TempestKeepSpawn) );
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Reconquering Tempest Keep", "Tempest Keep still has the power to open a portal Argus, but Velen needs to channel it", "ReplaceableTextures\\CommandButtons\\BTNArcaneCastle.blp");
      this.AddQuestItem(QuestItemChannelRect.create(gg_rct_TempestKeepSpawn, "Tempest Keep", LEGEND_VELEN, 180, 0));
      ;;
    }


}
