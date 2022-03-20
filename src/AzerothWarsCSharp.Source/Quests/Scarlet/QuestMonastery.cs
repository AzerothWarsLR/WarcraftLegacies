using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scarlet
{
  public class QuestMonastery{

  
    private const int RESEARCH_ID = FourCC(R03P)         ;//This research is required to complete the quest
    private const int QUEST_RESEARCH_ID = FourCC(R03F)   ;//This research is given when the quest is completed
  



    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "The Scarlet Monastery Hand is complete && ready to join the " + this.Holder.Team.Name + ".";
    }

    protected override string CompletionDescription => 
      return "Control of all units in the Scarlet Monastery && you will unally the alliance";
    }

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_ScarletAmbient, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(FACTION_KULTIRAS.Player, FourCC(R06V), 1);
      SetPlayerTechResearched(FACTION_LORDAERON.Player, FourCC(R06V), 1);
      SetPlayerTechResearched(FACTION_SCARLET.Player, FourCC(R086), 1);
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_ScarletAmbient, this.Holder.Player);
      WaygateActivateBJ( true, gg_unit_h00T_0786 );
      WaygateSetDestinationLocBJ( gg_unit_h00T_0786, GetRectCenter(gg_rct_Scarlet_Monastery_Interior) );
      this.Holder.Team = TEAM_SCARLET;
      this.Holder.Name = "Scarlet";
      this.Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNSaidan Dathrohan.blp";
      PlayThematicMusicBJ( "war3mapImported\\ScarletTheme.mp3" );
      SetPlayerStateBJ( this.Holder.Player, PLAYER_STATE_FOOD_CAP_CEILING, 300 );
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(RESEARCH_ID, 1);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Secret Cloister", "The Scarlet Monastery is the perfect place for the secret base of the Scarlet Crusade.", "ReplaceableTextures\\CommandButtons\\BTNDivine_Reckoning_Icon.blp");
      this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, FourCC(h00T)));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
