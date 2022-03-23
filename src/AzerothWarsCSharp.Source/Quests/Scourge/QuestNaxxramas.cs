using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestNaxxramas : QuestData{


    protected override string CompletionPopup => "The Naxxramas has now been raised && under the control of the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Naxxramas";

    private void GrantNaxxramas(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Naxxramas
      GroupEnumUnitsInRect(tempGroup, Regions.NaxAmbient.Rect, null);
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

    protected override void OnComplete(){
      GrantNaxxramas(Holder.Player);
      SetUnitOwner( gg_unit_e013_1815, Holder.Player, true );
      SetUnitInvulnerable( gg_unit_e013_1815, false );
      SetPlayerAbilityAvailableBJ( false, FourCC("A0O2"), Holder.Player);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Dread Citadel", "This fallen necropolis can be transformed into a potent war machine by the Lich KelFourCC("tuzad", "ReplaceableTextures\\CommandButtons\\BTNBlackCitadel.blp"");
      QuestItemChannelRect questItemChannelRect = AddQuestItem(new QuestItemChannelRect(Regions.NaxUnlock, "Naxxramas", LEGEND_KELTHUZAD, 60.Rect, 270));
      questItemChannelRect.RequiredUnitTypeId = UNITTYPE_KELTHUZAD_LICH;
      
    }


  }
}
