using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Goblin
{
  public class QuestGadgetzan{

  
    private const int QUEST_RESEARCH_ID = FourCC(R07E)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "We can train Noggenfogger && Gadgetzan is now under our influence && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    private string operator CompletionDescription( ){
      return "Control of all buildings in Gadgetzan && enables Noggenfogger to be built at the altar";
    }

    private void GrantGadetzan(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Gadetzan
      GroupEnumUnitsInRect(tempGroup, gg_rct_GadgetUnlock, null);
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
      GrantGadetzan(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      GrantGadetzan(this.Holder.Player);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Gadgetzan", "The city of Gadgetzan is a perfect foothold into Kalimdor.", "ReplaceableTextures\\CommandButtons\\BTNHeroAlchemist.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n05C))));
      this.AddQuestItem(QuestItemExpire.create(1522));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
