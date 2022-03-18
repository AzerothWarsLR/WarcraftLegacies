using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Stormwind
{
  public class QuestStormwindCity{

  
    private const int QUEST_RESEARCH_ID = FourCC(R02S);
  


    private string operator CompletionPopup( ){
      return "Stormwind has been liberated, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in Stormwind && enable Varian to be trained at the altar";
    }

    private void GrantStormwind(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Stormwind
      GroupEnumUnitsInRect(tempGroup, gg_rct_StormwindUnlock, null);
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

    private void OnComplete( ){
      SetPlayerTechResearched(Holder.Player, FourCC(R02S), 1);
      GrantStormwind(this.Holder.Player);
      if (GetLocalPlayer() == this.Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\StormwindTheme.mp3" );
      }
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Clear the Outskirts", "The outskirts of Stormwind are infested by evil creatures. Kill their leaders && regain control of the Towns.", "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionCastle.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n00V))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n00Z))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n011))));
      this.AddQuestItem(QuestItemUpgrade.create(FourCC(h06N), )h06K)));
      this.AddQuestItem(QuestItemExpire.create(1020));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
