using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestShadowfang : QuestData{



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
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01D"))));
      this.AddQuestItem(new QuestItemExpire(1444));
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
