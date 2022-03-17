using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Dalaran
{
  public class QuestShadowfang{



    private string operator CompletionPopup( ){
      return "Shadowfang has been liberated, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in Shadowfang";
    }

    private void OnFail( ){
      RescueNeutralUnitsInRect(gg_rct_ShadowfangUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      RescueNeutralUnitsInRect(gg_rct_ShadowfangUnlock, this.Holder.Player);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Shadows of Silverspine Forest", "The woods of Silverspine are unsafe for travellers, they need to be investigated", "ReplaceableTextures\\CommandButtons\\BTNworgen.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_o02J_0984)) ;//Worgen
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n01D))));
      this.AddQuestItem(QuestItemExpire.create(1444));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
