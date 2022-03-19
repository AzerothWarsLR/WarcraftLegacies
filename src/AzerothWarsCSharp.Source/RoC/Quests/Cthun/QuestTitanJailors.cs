using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Cthun
{
  public class QuestTitanJailors{

  
    private const int QUEST_RESEARCH_ID = FourCC(R07B)   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => 
      return "THe titan jailors guarding CFourCC(thun)s resting place have been destroyed. Now nothing stands between the Qiraji && their master.";
    }

    protected override string CompletionDescription => 
      return "Gain control of all units in Ahn'qiraj)s inner temple && unlock the awakening spell for C'thunn";
    }

    private void OnFail( ){
      RescueNeutralUnitsInRect(gg_rct_TunnelUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
      WaygateActivateBJ( true, gg_unit_h03V_0591 );
      WaygateSetDestinationLocBJ( gg_unit_h03V_0591, GetRectCenter(gg_rct_Silithus_Stone_Interior) );
    }

    protected override void OnComplete(){
      WaygateActivateBJ( true, gg_unit_h03V_0591 );
      WaygateSetDestinationLocBJ( gg_unit_h03V_0591, GetRectCenter(gg_rct_Silithus_Stone_Interior) );
      RescueNeutralUnitsInRect(gg_rct_TunnelUnlock, this.Holder.Player);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Jailors of the Old God", "The Old God CFourCC(thun is imprisoned deep within the temple of Ahn)qiraj, defended by mechanical wardens left behind by the Titans.", "ReplaceableTextures\\CommandButtons\\BTNArmorGolem.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_nsgg_1490)) ;//Golem
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n02K))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n078))));
      this.AddQuestItem(QuestItemExpire.create(1428));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
