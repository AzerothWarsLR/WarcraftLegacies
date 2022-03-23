using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestKilsorrow : QuestData{


    protected override string CompletionPopup => "KilFourCC(sorrow is now established, && its military is now free to assist the " + this.Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in KilFourCC(sorrow && 3 new Demon Gates";

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.KilsorrowUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.KilsorrowUnlock.Rect, this.Holder.Player);
      GeneralHelpers.UnitRescue(gg_unit_n081_4142, FACTION_FEL_HORDE.Player);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("KilFourCC("sorrow Fortress", "This sinister fortress will serve the Fel Horde well, clear the surrounding lands to establish it", "ReplaceableTextures\\CommandButtons\\BTNFelOrcWatchTower.blp"");
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n09X"))));
      this.AddQuestItem(new QuestItemExpire(1452));
      this.AddQuestItem(QuestItemSelfExists);
      ;;
    }


  }
}
