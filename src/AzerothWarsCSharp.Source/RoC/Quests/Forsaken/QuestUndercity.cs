using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Forsaken
{
  public class QuestUndercity{

  
    private const int RESEARCH_ID = FourCC(R050)         ;//This research is required to complete the quest
    private const int QUEST_RESEARCH_ID = FourCC(R04X)   ;//This research is given when the quest is completed
  



    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "Undercity is now under the " + this.Holder.Team.Name + " && they have declared independance.";
    }

    protected override string CompletionDescription => 
      return "Control of all units in Undercity, unlock Nathanos && unally the Legion team";
    }

    private void OnFail( ){
      RescueNeutralUnitsInRect(gg_rct_UndercityUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(gg_rct_UndercityUnlock, this.Holder.Player);
      SetPlayerTechResearched(FACTION_LORDAERON.Player, FourCC(R08G), 1);
      SetPlayerTechResearched(FACTION_LEGION.Player, FourCC(R08G), 1);
      WaygateActivateBJ( true, gg_unit_n08F_1739 );
      WaygateActivateBJ( true, gg_unit_n08F_1798 );
      ShowUnitShow( gg_unit_n08F_1739 );
      ShowUnitShow( gg_unit_n08F_1798 );
      WaygateSetDestinationLocBJ( gg_unit_n08F_1739, GetRectCenter(gg_rct_Undercity_Interior_2) );
      WaygateSetDestinationLocBJ( gg_unit_n08F_1798, GetRectCenter(gg_rct_Undercity_Interior_1) );
      this.Holder.Team = TEAM_FORSAKEN;
      this.Holder.Name = "Forsaken";
      this.Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNBansheeRanger.blp";
      SetPlayerStateBJ( this.Holder.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300 );
      PlayThematicMusicBJ( "war3mapImported\\ForsakenTheme.mp3" );
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Forsaken Independance", "The Forsaken had enough of living under the tyranny of the Lich King. Sylvanas has vowed to give them their freedom back && a home", "ReplaceableTextures\\CommandButtons\\BTNForsakenArrows.blp");
      this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, FourCC(h08B)));
      this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_SYLVANASV, gg_rct_Terenas, "Capital City"));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_CAPITALPALACE));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
