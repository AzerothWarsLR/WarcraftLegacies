using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestStormwindCity : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R02S");
  


    protected override string CompletionPopup => "Stormwind has been liberated, && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Stormwind && enable Varian to be trained at the altar";

    private void GrantStormwind(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Stormwind
      GroupEnumUnitsInRect(tempGroup, Regions.StormwindUnlock.Rect, null);
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
      GrantStormwind(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, FourCC("R02S"), 1);
      GrantStormwind(Holder.Player);
      if (GetLocalPlayer() == Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\StormwindTheme.mp3" );
      }
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Clear the Outskirts", "The outskirts of Stormwind are infested by evil creatures. Kill their leaders && regain control of the Towns.", "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionCastle.blp");
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00V"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00Z"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n011"))));
      this.AddQuestItem(new QuestItemUpgrade(FourCC("h06N"), )h06K)));
      AddQuestItem(new QuestItemExpire(1020));
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
