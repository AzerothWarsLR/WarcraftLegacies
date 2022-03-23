using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public sealed class QuestShipArgus : QuestData{



    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => "Velen has opened the portal to Argus";

    protected override string CompletionDescription => "Open a Portal between Tempest Keep && Argus";

    protected override void OnComplete(){
      WaygateActivateBJ( true, gg_unit_h03V_3538 );
      ShowUnitShow( gg_unit_h03V_3538 );
      WaygateSetDestinationLocBJ( gg_unit_h03V_3538, GetRectCenter(gg_rct_OutlandToArgus) );
      WaygateActivateBJ( true, gg_unit_h03V_3539 );
      ShowUnitShow( gg_unit_h03V_3539 );
      WaygateSetDestinationLocBJ( gg_unit_h03V_3539, GetRectCenter(gg_rct_TempestKeepSpawn) );
    }

    public  QuestShipArgus ( ){
      thistype this = thistype.allocate("Reconquering Tempest Keep", "Tempest Keep still has the power to open a portal Argus, but Velen needs to channel it", "ReplaceableTextures\\CommandButtons\\BTNArcaneCastle.blp");
      AddQuestItem(new QuestItemChannelRect(Regions.TempestKeepSpawn, "Tempest Keep", LEGEND_VELEN, 180.Rect, 0));
      ;;
    }


  }
}
