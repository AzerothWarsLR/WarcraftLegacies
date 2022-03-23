using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public class QuestKilsorrow : QuestData{


    protected override string CompletionPopup => 
      return "KilFourCC(sorrow is now established, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    protected override string CompletionDescription => 
      return "Control of all units in KilFourCC(sorrow && 3 new Demon Gates";
    }

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_KilsorrowUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_KilsorrowUnlock, this.Holder.Player);
      GeneralHelpers.UnitRescue(gg_unit_n081_4142, FACTION_FEL_HORDE.Player);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("KilFourCC("sorrow Fortress", "This sinister fortress will serve the Fel Horde well, clear the surrounding lands to establish it", "ReplaceableTextures\\CommandButtons\\BTNFelOrcWatchTower.blp"");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC("n09X"))));
      this.AddQuestItem(QuestItemExpire.create(1452));
      this.AddQuestItem(QuestItemSelfExists);
      ;;
    }


  }
}
