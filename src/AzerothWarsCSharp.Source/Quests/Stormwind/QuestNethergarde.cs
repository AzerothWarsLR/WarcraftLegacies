using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestNethergarde : QuestData{


    protected override string CompletionPopup => "Varian has come to relieve the Nethergarde garrison.";

    protected override string CompletionDescription => "You gain control of the Nethergarde base";

    private void GrantNethergarde(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Nethergarde
      GroupEnumUnitsInRect(tempGroup, Regions.NethergardeUnlock.Rect, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          GeneralHelpers.UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void OnFail( ){
      GrantNethergarde(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantNethergarde(this.Holder.Player);
      FACTION_STORMWIND.ModObjectLimit(FourCC("h03F"),1)               ;//Reginald windsor
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Nethergarde relief", "The nethergarde fort is holding down the Dark Portal, they will need to be reinforced soon!", "ReplaceableTextures\\CommandButtons\\BTNNobbyMansionBarracks.blp");
      this.AddQuestItem(new QuestItemLegendInRect(LEGEND_VARIAN, Regions.NethergardeUnlock.Rect, "Nethergarde"));
      this.AddQuestItem(new QuestItemExpire(1440));
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
