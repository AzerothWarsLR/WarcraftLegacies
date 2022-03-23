using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestKillDraenei : QuestData : QuestData{


    protected override string CompletionPopup => 
      return "The Draenei have been eliminated from Outland && their gold mine is ours.";
    }

    protected override string CompletionDescription => 
      return "The Draenei rich gold mine in Tempest Keep, the faster we destroy them, the more gold will be left";
    }

    protected override void OnComplete(){
      group tempGroup = CreateGroup();
      unit u;

      AdjustPlayerStateBJ( 500, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
      AdjustPlayerStateBJ( 500, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );

      GroupEnumUnitsInRect(tempGroup, gg_rct_InstanceOutland, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == FACTION_DRAENEI.Player){
          if (IsUnitType(u, UNIT_TYPE_STRUCTURE) && !IsUnitType(u, UNIT_TYPE_ANCIENT)){
            KillUnit(u);
          }
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Shattrah Massacre", "The Draenei race existence insults the Fel Horde demon masters, slaughter them all ", "ReplaceableTextures\\CommandButtons\\BTNChaosWolfRider.blp");
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n09X"))));
      this.AddQuestItem(new QuestItemLegendDead(LEGEND_EXODARSHIP));
      this.AddQuestItem(QuestItemSelfExists);
      ;;
    }


  }
}
