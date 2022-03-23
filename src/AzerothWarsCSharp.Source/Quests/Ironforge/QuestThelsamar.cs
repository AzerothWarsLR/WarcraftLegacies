using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestThelsamar : QuestData{


    protected override string CompletionPopup => 
      return "The Murlocs have been defeated, Thelsamar will join your cause.";
    }

    protected override string CompletionDescription => 
      return "Control of all units in Thelsamar";
    }

    private void GrantThelsamar(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Thelsamar
      GroupEnumUnitsInRect(tempGroup, gg_rct_ThelUnlock, null);
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
      GrantThelsamar(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantThelsamar(this.Holder.Player);
    }


    public  thistype ( ){
      thistype this = thistype.allocate("Murloc Menace", "A vile group of Murloc is terrorizing Thelsamar. Destroy them!", "ReplaceableTextures\\CommandButtons\\BTNMurlocNightCrawler.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_N089_1494)) ;//Murloc
      this.AddQuestItem(new QuestItemExpire(1435));
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
