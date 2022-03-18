using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Fel_Horde
{
  public class QuestBlackrock{

  
    private const int QUEST_RESEARCH_ID = FourCC(R03C);
  


    private string operator CompletionPopup( ){
      return "Blackrock Citadel has been subjugated, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Control of all units in Blackrock Citadel && enable DalFourCC(rend Blackhand to be trained at the altar";
    }

    private void GrantBlackrock(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Blackrock
      GroupEnumUnitsInRect(tempGroup, gg_rct_BlackrockUnlock, null);
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
      GrantBlackrock(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      SetPlayerTechResearched(Holder.Player, FourCC(R03C), 1);
      GrantBlackrock(this.Holder.Player);
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Blackrock Unification", "Make contact with the Blackrock clan && convince them to join Magtheridon", "ReplaceableTextures\\CommandButtons\\BTNBlackhand.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n00S))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n09Y))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n0A9))));
      this.AddQuestItem(QuestItemExpire.create(1451));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
