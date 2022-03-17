using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Cthun
{
  public class QuestGatesofAhnqiraj{



    boolean operator Global( ){
      return true;
    }

    private string operator CompletionPopup( ){
      return "The Old God CFourCC(thun has awaken && is now ready to unleash the Qiraji on the world of Azeorth.";
    }

    private string operator CompletionDescription( ){
      return "Gain control of CFourCC(thun && enable you to open the Gates of Ahn)qiraj";
    }

    private void OnComplete( ){
      WaygateActivateBJ(true, gg_unit_h03V_3441);
      ShowUnitShow(gg_unit_h03V_3441);
      WaygateSetDestinationLocBJ(gg_unit_h03V_3441, GetRectCenter(gg_rct_WorldTunnelEntrance));
      WaygateActivateBJ(true, gg_unit_h03V_3449);
      ShowUnitShow(gg_unit_h03V_3449);
      WaygateSetDestinationLocBJ(gg_unit_h03V_3449, GetRectCenter(gg_rct_WorldTunnelExit));
      SetUnitInvulnerable(gg_unit_h02U_2413, false);
      PlayThematicMusicBJ("war3mapImported\\CthunTheme.mp3");
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Gates of AhnFourCC(Qiraj", "At the conclusion of the War of the Shifting Sands, the Dragonflights sealed the Qiraji behind the Scarab Wall. Now centuries later, C)thun is once again ready to open the gates to his ancient empire.", "ReplaceableTextures\\CommandButtons\\BTNScarabMedal.blp");
      this.AddQuestItem(QuestItemCastSpell.create(FourCC(A0O1), true));
      ;;
    }


  }
}
