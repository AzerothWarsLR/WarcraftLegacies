using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Naga
{
  public class QuestMadnessPath{

  
    private const int RESEARCH_ID = FourCC(R065)         ;//This research is required to complete the quest
    private const int QUEST_RESEARCH_ID = FourCC(R033)   ;//This research is given when the quest is completed
  


    bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "Nazjatar is now under the influence of the Old Gods && the portal is opened to NyFourCC(alotha.";
    }

    protected override string CompletionDescription => 
      return "A portal is opened to NyFourCC(alotha, Illidan turns Hostile, Aszhara appears && you join the Old Gods team";
    }

    private void GrantNazjatar( ){
      SetUnitOwner(gg_unit_n07E_0958, Player(PLAYER_NEUTRAL_AGGRESSIVE), true);
      ShowUnit(gg_unit_n07E_0958, true);
    }

    private void RenameIllidanFaction( ){
      this.Holder.Team = TEAM_OLDGOD;
      this.Holder.Name = "Nazjatar";
      this.Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNNagaSummoner.blp";
    }

    private void FailQuests( ){
      REDEMPTION_PATH.Progress = QUEST_PROGRESS_FAILED;
      EXILE_PATH.Progress = QUEST_PROGRESS_FAILED;
    }

    private void TransferHeroes( ){
      SetUnitOwner(LEGEND_NZOTH.Unit, this.Holder.Player, true);
      LEGEND_AZSHARA.Spawn(Holder.Player, GetRectCenterX(gg_rct_InstanceNazjatar), GetRectCenterY(gg_rct_InstanceNazjatar), 270);
      SetHeroLevel(LEGEND_AZSHARA.Unit, 7, false);
      SetUnitOwner(LEGEND_ILLIDAN.Unit, Player(PLAYER_NEUTRAL_AGGRESSIVE), true);
    }

    private void AdjustTechtree( ){
      FACTION_NAGA.ModObjectLimit(FourCC(n08V), UNLIMITED) ;//Depth Void Portal
      FACTION_NAGA.ModObjectLimit(FourCC(h01Q), 4) ;//Immortal Guardian
      FACTION_NAGA.ModObjectLimit(FourCC(H08U), 1) ;//Azshara
    }

    protected override void OnComplete(){
      GrantNazjatar();
      AdjustTechtree();
      FailQuests();
      TransferHeroes();
      FACTION_NAGA.ModObjectLimit(FourCC(Eevi), -UNLIMITED)  	    ;//Illidan
      BLACKEMPIREPORTAL_ILLIDAN.PortalState = BLACKEMPIREPORTALSTATE_OPEN;
      RenameIllidanFaction();
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
      thistype this = thistype.allocate("Voices in the Void", "Azshara takes command of the Naga in the name of NFourCC(zoth. Illidan)s reign is no more.", "ReplaceableTextures\\CommandButtons\\BTNGuardianofTheSea.blp");
      this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, FourCC(n055)));
      this.AddQuestItem(QuestItemLegendNotDead.create(LEGEND_ILLIDAN));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_NazjatarHidden, "Nazjatar"));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
