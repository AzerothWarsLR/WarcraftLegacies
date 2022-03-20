using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public class QuestShadowfang{



    protected override string CompletionPopup => 
      return "Shadowfang has been liberated, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    protected override string CompletionDescription => 
      return "Control of all units in Shadowfang";
    }

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_ShadowfangUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_ShadowfangUnlock, this.Holder.Player);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Shadows of Silverspine Forest", "The woods of Silverspine are unsafe for travellers, they need to be investigated", "ReplaceableTextures\\CommandButtons\\BTNworgen.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_o02J_0984)) ;//Worgen
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n01D))));
      this.AddQuestItem(QuestItemExpire.create(1444));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
