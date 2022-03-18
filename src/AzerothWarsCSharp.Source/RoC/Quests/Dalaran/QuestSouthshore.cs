using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Dalaran
{
  public class QuestSouthshore{


    private string operator CompletionPopup( ){
      return "The Murlocs have been defeated, Southshore is safe.";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in Southshore";
    }

    private void GrantSouthshore(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Southshore
      GroupEnumUnitsInRect(tempGroup, gg_rct_SouthshoreUnlock, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void OnFail( ){
      GrantSouthshore(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      GrantSouthshore(this.Holder.Player);
    }


    public  thistype ( ){
      thistype this = thistype.allocate("Murloc Troubles", "A small murloc skirmish is attacking Southshore, push them back", "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_nmrm_0204)) ;//Murloc
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n08M))));
      this.AddQuestItem(QuestItemExpire.create(1135));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
