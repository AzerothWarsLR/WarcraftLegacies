using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Forsaken
{
  public sealed class QuestUndercity : QuestData{

  
    private const int RESEARCH_ID = FourCC("R050")         ;//This research is required to complete the quest
    private const int QUEST_RESEARCH_ID = FourCC("R04X")   ;//This research is given when the quest is completed
  



    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => "Undercity is now under the " + Holder.Team.Name + " && they have declared independance.";

    protected override string CompletionDescription => "Control of all units in Undercity, unlock Nathanos && unally the Legion team";

    protected override void OnFail( ){
      RescueNeutralUnitsInRect(Regions.UndercityUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(Regions.UndercityUnlock.Rect, Holder.Player);
      SetPlayerTechResearched(FACTION_LORDAERON.Player, FourCC("R08G"), 1);
      SetPlayerTechResearched(FACTION_LEGION.Player, FourCC("R08G"), 1);
      WaygateActivateBJ( true, gg_unit_n08F_1739 );
      WaygateActivateBJ( true, gg_unit_n08F_1798 );
      ShowUnitShow( gg_unit_n08F_1739 );
      ShowUnitShow( gg_unit_n08F_1798 );
      WaygateSetDestinationLocBJ( gg_unit_n08F_1739, GetRectCenter(gg_rct_Undercity_Interior_2) );
      WaygateSetDestinationLocBJ( gg_unit_n08F_1798, GetRectCenter(gg_rct_Undercity_Interior_1) );
      Holder.Team = TEAM_FORSAKEN;
      Holder.Name = "Forsaken";
      Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNBansheeRanger.blp";
      SetPlayerStateBJ( Holder.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300 );
      PlayThematicMusicBJ( "war3mapImported\\ForsakenTheme.mp3" );
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  QuestUndercity ( ){
      thistype this = thistype.allocate("Forsaken Independance", "The Forsaken had enough of living under the tyranny of the Lich King. Sylvanas has vowed to give them their freedom back && a home", "ReplaceableTextures\\CommandButtons\\BTNForsakenArrows.blp");
      AddQuestItem(new QuestItemResearch(RESEARCH_ID, FourCC("h08B")));
      AddQuestItem(new QuestItemLegendInRect(LEGEND_SYLVANASV, Regions.Terenas.Rect, "Capital City"));
      AddQuestItem(new QuestItemLegendDead(LEGEND_CAPITALPALACE));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
