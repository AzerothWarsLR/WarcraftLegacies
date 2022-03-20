using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public class QuestLakeshire{


    protected override string CompletionPopup => 
      return "Lakeshire has been liberated, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    protected override string CompletionDescription => 
      return "Control of all units in Lakeshire";
    }

    private void GrantLakeshire(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Lakeshire
      GroupEnumUnitsInRect(tempGroup, gg_rct_LakeshireUnlock, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          GeneralHelpers.UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void OnFail( ){
      GrantLakeshire(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantLakeshire(this.Holder.Player);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Marauding Ogres", "The town of Lakeshire is invaded by Ogres, wipe them out!", "ReplaceableTextures\\CommandButtons\\BTNOgreLord.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_nogl_0621)) ;//Ogre Lord
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n011))));
      this.AddQuestItem(QuestItemExpire.create(1427));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
