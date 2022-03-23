using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Frostwolf
{
  public sealed class QuestStonemaul : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R03S")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "Stonemaul has been liberated, && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Stonemaul && 3000 lumber";

    private void GrantStonemaul(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Stonemaul
      GroupEnumUnitsInRect(tempGroup, Regions.StonemaulKeep.Rect, null);
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
      GrantStonemaul(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantStonemaul(Holder.Player);
      AdjustPlayerStateBJ(3000, FACTION_FROSTWOLF.Player, PLAYER_STATE_RESOURCE_LUMBER);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The ChieftainFourCC("s Challenge", "The Ogres of Stonemaul follow the strongest, slay the Chieftain to gain control of the base.", "ReplaceableTextures\\CommandButtons\\BTNOneHeadedOgre.blp"");
      AddQuestItem(QuestItemKillUnit.create(gg_unit_noga_1228)) ;//Korgall
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n022"))));
      AddQuestItem(new QuestItemExpire(1505));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
