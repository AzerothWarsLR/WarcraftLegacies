using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Fel_Horde
{
  public class QuestKilsorrow{


    protected override string CompletionPopup => 
      return "KilFourCC(sorrow is now established, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    protected override string CompletionDescription => 
      return "Control of all units in KilFourCC(sorrow && 3 new Demon Gates";
    }

    private void OnFail( ){
      RescueNeutralUnitsInRect(gg_rct_KilsorrowUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(gg_rct_KilsorrowUnlock, this.Holder.Player);
      UnitRescue(gg_unit_n081_4142, FACTION_FEL_HORDE.Player);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("KilFourCC(sorrow Fortress", "This sinister fortress will serve the Fel Horde well, clear the surrounding lands to establish it", "ReplaceableTextures\\CommandButtons\\BTNFelOrcWatchTower.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n09X))));
      this.AddQuestItem(QuestItemExpire.create(1452));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
