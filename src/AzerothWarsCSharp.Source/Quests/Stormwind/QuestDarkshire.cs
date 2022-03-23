using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestDarkshire : QuestData{


    protected override string CompletionPopup => 
      return "Darkshire has been liberated, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    protected override string CompletionDescription => 
      return "Control of all units in Darkshire";
    }

    private void GrantDarkshire(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Darkshire
      GroupEnumUnitsInRect(tempGroup, gg_rct_DarkshireUnlock, null);
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
      GrantDarkshire(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantDarkshire(this.Holder.Player);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Gnoll troubles", "The town of Darkshire is under attack by GnollFourCC("s, clear them out!", "ReplaceableTextures\\CommandButtons\\BTNGnollArcher.blp"");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_ngnv_0586)) ;//Gnoll Overseer
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00V"))));
      this.AddQuestItem(new QuestItemExpire(1425));
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
