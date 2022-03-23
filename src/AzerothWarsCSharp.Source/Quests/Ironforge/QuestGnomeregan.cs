using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestGnomeregan : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R05Q");
  


    protected override string CompletionPopup => "Gnomeregan has been literated, && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Gnomeregan";

    private void GrantGnomeregan(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Gnomeregan
      GroupEnumUnitsInRect(tempGroup, Regions.Gnomergan.Rect, null);
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

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, FourCC("R05Q"), 1);
      GrantGnomeregan(Holder.Player);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The City of Invention", "The people of Gnomeregan have long been unable to assist the Alliance in its wars due an infestation of troggs && Ice Trolls. Resolve their conflicts for them to gain their services.", "ReplaceableTextures\\CommandButtons\\BTNFlyingMachine.blp");
      AddQuestItem(QuestItemKillUnit.create(gg_unit_nitw_1513)) ;//Ice Troll Warlord
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
