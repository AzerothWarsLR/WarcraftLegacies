using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Ironforge
{
  public class QuestThelsamar{


    private string operator CompletionPopup( ){
      return "The Murlocs have been defeated, Thelsamar will join your cause.";
    }

    private string operator CompletionDescription( ){
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
          UnitRescue(u, whichPlayer);
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

    private void OnComplete( ){
      GrantThelsamar(this.Holder.Player);
    }


    public  thistype ( ){
      thistype this = thistype.allocate("Murloc Menace", "A vile group of Murloc is terrorizing Thelsamar. Destroy them!", "ReplaceableTextures\\CommandButtons\\BTNMurlocNightCrawler.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_N089_1494)) ;//Murloc
      this.AddQuestItem(QuestItemExpire.create(1435));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
