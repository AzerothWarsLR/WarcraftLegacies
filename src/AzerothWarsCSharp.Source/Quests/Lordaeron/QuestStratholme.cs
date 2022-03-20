using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public class QuestStratholme{



    protected override string CompletionPopup => 
      return "Stratholme has been liberated, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    protected override string CompletionDescription => 
      return "Control of all units in Stratholme";
    }

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_StratholmeUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_StratholmeUnlock, this.Holder.Player);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Blackrock && Roll", "The Blackrock clan has taken over Alterac, they must be eliminated for the safety of Lordaeron", "ReplaceableTextures\\CommandButtons\\BTNChaosBlademaster.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_o00B_1316)) ;//Jubei
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n019))));
      this.AddQuestItem(QuestItemUpgrade.create(FourCC(hcas), )htow)));
      this.AddQuestItem(QuestItemExpire.create(1470));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
