using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestLakeshire : QuestData{


    protected override string CompletionPopup => "Lakeshire has been liberated, && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Lakeshire";

    private void GrantLakeshire(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Lakeshire
      GroupEnumUnitsInRect(tempGroup, Regions.LakeshireUnlock.Rect, null);
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

    protected override void OnFail( ){
      GrantLakeshire(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantLakeshire(Holder.Player);
    }

    protected override void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Marauding Ogres", "The town of Lakeshire is invaded by Ogres, wipe them out!", "ReplaceableTextures\\CommandButtons\\BTNOgreLord.blp");
      AddQuestItem(QuestItemKillUnit.create(gg_unit_nogl_0621)) ;//Ogre Lord
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n011"))));
      AddQuestItem(new QuestItemExpire(1427));
      AddQuestItem(new QuestItemSelfExists());
      
    }


  }
}
