using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public sealed class QuestExiled : QuestData{

  
    private static readonly int QuestResearchId = FourCC("R081")   ;//This research is given when the quest is completed
    private const int RESEARCH_ID = FourCC("R080")   ;//This research is required to complete
  



    private bool Global( ){
      return true;
    }

    protected override string CompletionPopup => "The Draenei have landed on Azuremyst after escaping Outland";

    protected override string CompletionDescription => "Control of all units in Azuremyst, gain 200 gold, 500 lumber && teleports all your units away from Outland";

    private void GrantExiled(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Exiled
      GroupEnumUnitsInRect(tempGroup, Regions.DraeneiEvacuation.Rect, null);
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

    private void EscapeOutland(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Exiled
      GroupEnumUnitsInRect(tempGroup, Regions.InstanceOutland.Rect, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Holder.Player){
          if (IsUnitType(u, UNIT_TYPE_STRUCTURE) && !IsUnitType(u, UNIT_TYPE_ANCIENT)){
            KillUnit(u);
          }else if (!IsUnitType(u, UNIT_TYPE_ANCIENT)){
            SetUnitPosition(u, -21185, 8000);
          }
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    protected override void OnFail( ){
      group tempGroup = CreateGroup();
      unit u;

      GrantExiled(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      KillUnit(gg_unit_o02P_2291);
      KillUnit(gg_unit_o02P_2291);
      KillUnit(LEGEND_VELEN.Unit );

      GroupEnumUnitsInRect(tempGroup, Regions.InstanceOutland.Rect, null);
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

    protected override void OnComplete(){
      AdjustPlayerStateBJ( 200, Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
      AdjustPlayerStateBJ( ( 2000 - GetResourceAmount(gg_unit_ngol_3272) ), Player(13), PLAYER_STATE_RESOURCE_GOLD );
      AdjustPlayerStateBJ( 500, Holder.Player, PLAYER_STATE_RESOURCE_LUMBER );
      FACTION_DRAENEI.AddQuest(SHIP_ARGUS);
      SHIP_ARGUS.Progress = QUEST_PROGRESS_INCOMPLETE;
      UnitRemoveAbilityBJ( FourCC("ACm2"), LEGEND_VELEN.Unit);
      GrantExiled(Holder.Player);
      EscapeOutland(Holder.Player);
      RemoveUnit(gg_unit_h09W_3303);
      KillUnit(gg_unit_o02P_2291);
      if (GetLocalPlayer() == Holder.Player){
        PlayThematicMusicBJ( "war3mapImported\\DraeneiTheme.mp3" );
      }
    }

    public  QuestExiled ( ){
      thistype this = thistype.allocate("The Exile from Outland", "The Draenei need to escape Outland through the Exodar ship. We will need to power it up with a Divine Citadel first. The longer you hold out, the better the rewards will be", "ReplaceableTextures\\CommandButtons\\BTNUndeadAirBarge.blp");
      this.AddQuestItem(new QuestItemEitherOf.create(QuestItemResearch.create(RESEARCH_ID, FourCC("h09W")), QuestItemTime(782)));
      this.AddQuestItem(new QuestItemLegendNotPermanentlyDead(LEGEND_EXODARSHIP));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QuestResearchId;
      ;;
    }


  }
}
