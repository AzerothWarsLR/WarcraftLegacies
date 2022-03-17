using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Frostwolf
{
  public class QuestStonemaul{

  
    private const int QUEST_RESEARCH_ID = FourCC(R03S)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "Stonemaul has been liberated, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in Stonemaul && 3000 lumber";
    }

    private void GrantStonemaul(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Stonemaul
      GroupEnumUnitsInRect(tempGroup, gg_rct_StonemaulKeep, null);
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
      this.GrantStonemaul(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      this.GrantStonemaul(this.Holder.Player);
      AdjustPlayerStateBJ(3000, FACTION_FROSTWOLF.Player, PLAYER_STATE_RESOURCE_LUMBER);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The ChieftainFourCC(s Challenge", "The Ogres of Stonemaul follow the strongest, slay the Chieftain to gain control of the base.", "ReplaceableTextures\\CommandButtons\\BTNOneHeadedOgre.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_noga_1228)) ;//Korgall
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n022))));
      this.AddQuestItem(QuestItemExpire.create(1505));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
