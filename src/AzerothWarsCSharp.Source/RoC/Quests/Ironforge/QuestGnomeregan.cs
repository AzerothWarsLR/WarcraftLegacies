using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Ironforge
{
  public class QuestGnomeregan{

  
    private const int QUEST_RESEARCH_ID = FourCC(R05Q);
  


    private string operator CompletionPopup( ){
      return "Gnomeregan has been literated, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in Gnomeregan";
    }

    private void GrantGnomeregan(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Gnomeregan
      GroupEnumUnitsInRect(tempGroup, gg_rct_Gnomergan, null);
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
      GrantGnomeregan(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      SetPlayerTechResearched(Holder.Player, FourCC(R05Q), 1);
      GrantGnomeregan(this.Holder.Player);
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The City of Invention", "The people of Gnomeregan have long been unable to assist the Alliance in its wars due an infestation of troggs && Ice Trolls. Resolve their conflicts for them to gain their services.", "ReplaceableTextures\\CommandButtons\\BTNFlyingMachine.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_nitw_1513)) ;//Ice Troll Warlord
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
