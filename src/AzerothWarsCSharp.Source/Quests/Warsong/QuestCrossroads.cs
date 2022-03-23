//If any Horde unit enters the Crossroads area, OR a time elapses, OR someone becomes a solo Horde Path, give the Crossroads to a Horde player.

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestCrossroads : QuestData{



    protected override string CompletionPopup => 

    }

    protected override string CompletionDescription => 
      return "Control of the Crossroads";
    }

    private void GiveCrossroads(player whichPlayer ){
      unit u;

      //Transfer all Neutral Passive units in Crossroads to one of the above factions
      u = FirstOfGroup(udg_Crossroad);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          GeneralHelpers.UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(udg_Crossroad, u);
        u = FirstOfGroup(udg_Crossroad);
      }
      //Give resources and display message
      CreateUnit(whichPlayer, FourCC("oeye"), -12844, -1975, 0);
      CreateUnit(whichPlayer, FourCC("oeye"), -10876, -2066, 0);
      CreateUnit(whichPlayer, FourCC("oeye"), -11922, -824, 0);

      //Cleanup
      DestroyGroup(udg_Crossroad);
      AdjustPlayerStateBJ( 2000, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
    }

    private void OnFail( ){
      GiveCrossroads(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GiveCrossroads(this.Holder.Player);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Crossroads", "The Horde still needs to establish a strong strategic foothold into Kalimdor. There is an opportune crossroads nearby.", "ReplaceableTextures\\CommandButtons\\BTNBarracks.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_nrzm_0113)) ;//Razorman Medicine Man
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01T"))));
      this.AddQuestItem(new QuestItemExpire(1460));
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
