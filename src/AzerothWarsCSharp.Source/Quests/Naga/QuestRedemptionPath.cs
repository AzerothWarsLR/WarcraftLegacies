using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public class QuestRedemptionPath{

  
    private const int RESEARCH_ID = FourCC(R062)         ;//This research is required to complete the quest
    private const int QUEST_RESEARCH_ID = FourCC(R06S)   ;//This research is given when the quest is completed
  



    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "Nazjatar && the Aetheneum is now under the influence of the Night Elves.";
    }

    protected override string CompletionDescription => 
      return "Control of all units in the Aetheneum. Join the Night Elves && enable to train Altruis.";
    }

    protected override void OnComplete(){
      FACTION_NAGA.ModObjectLimit(FourCC(n08H), UNLIMITED)   ;//Demon Hunter grounds
      FACTION_NAGA.ModObjectLimit(FourCC(e00S), UNLIMITED)   ;//Glaive Warrior
      FACTION_NAGA.ModObjectLimit(FourCC(h08W), 6)   ;//Demon Hunter
      SetUnitOwner(LEGEND_NZOTH.Unit, Player(PLAYER_NEUTRAL_AGGRESSIVE), true);
      EXILE_PATH.Progress = QUEST_PROGRESS_FAILED;
      MADNESS_PATH.Progress = QUEST_PROGRESS_FAILED;
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_AethneumCatacombs, this.Holder.Player);
      WaygateActivateBJ( true, gg_unit_h01D_3387 );
      WaygateActivateBJ( true, gg_unit_h01D_3385 );
      WaygateActivateBJ( true, gg_unit_h01D_3379 );
      WaygateActivateBJ( true, gg_unit_h01D_3380 );
      ShowUnitShow( gg_unit_h01D_3387 );
      ShowUnitShow( gg_unit_h01D_3385 );
      ShowUnitShow( gg_unit_h01D_3380 );
      ShowUnitShow( gg_unit_h01D_3379 );
      WaygateSetDestinationLocBJ( gg_unit_h01D_3387, GetRectCenter(gg_rct_AetheneumTombExit2) );
      WaygateSetDestinationLocBJ( gg_unit_h01D_3385 , GetRectCenter(gg_rct_AethneumTombExit) );
      WaygateSetDestinationLocBJ( gg_unit_h01D_3380 , GetRectCenter(gg_rct_AetheneumTombEntrance2) );
      WaygateSetDestinationLocBJ( gg_unit_h01D_3379 , GetRectCenter(gg_rct_AethneumLibraryEntrance) );
      WaygateActivateBJ( true, gg_unit_n07E_0958 );
      ShowUnitShow( gg_unit_n07E_0958  );
      WaygateSetDestinationLocBJ( gg_unit_n07E_0958, GetRectCenter(gg_rct_AetheneumtoNazjatar) );
      WaygateActivateBJ( true, gg_unit_n07E_1154 );
      ShowUnitShow( gg_unit_n07E_1154  );
      WaygateSetDestinationLocBJ( gg_unit_n07E_1154, GetRectCenter(gg_rct_NazjatarExit3) );
      this.Holder.Team = TEAM_NIGHT_ELVES;

      WaygateActivateBJ( true, gg_unit_h01D_3378 );
      ShowUnitShow( gg_unit_h01D_3378 );
      WaygateSetDestinationLocBJ( gg_unit_h01D_3378, GetRectCenter(gg_rct_NazjatarExit2) );
      WaygateActivateBJ( true, gg_unit_h01A_0402 );
      ShowUnitShow( gg_unit_h01A_0402 );
      WaygateSetDestinationLocBJ( gg_unit_h01A_0402, GetRectCenter(gg_rct_NazjatarExit1) );
      WaygateActivateBJ( true, gg_unit_h01D_3381 );
      ShowUnitShow( gg_unit_h01D_3381 );
      WaygateSetDestinationLocBJ( gg_unit_h01D_3381, GetRectCenter(gg_rct_NazjatarEntrance1) );
      WaygateActivateBJ( true, gg_unit_h01D_3384 );
      ShowUnitShow( gg_unit_h01D_3384 );
      WaygateSetDestinationLocBJ( gg_unit_h01D_3384, GetRectCenter(gg_rct_NazjatarEntrance2) );
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Brothers Stormrage", "Illidan follows his heart && seeks forgivness from Malfurion. United by their brotherly bond && their desire to protect Tyrande, they decide to unite their forces once again.", "ReplaceableTextures\\CommandButtons\\BTNDemonHunter2blp");
      this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, FourCC(n055)));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ILLIDAN, true));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_NazjatarHidden, "Nazjatar"));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
