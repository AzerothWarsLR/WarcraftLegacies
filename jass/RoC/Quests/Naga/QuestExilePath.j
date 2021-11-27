library QuestExilePath requires QuestData, NagaSetup

  globals
    private constant integer RESEARCH_ID = 'R063'         //This research is required to complete the quest
    private constant integer QUEST_RESEARCH_ID = 'R008'   //This research is given when the quest is completed
  endglobals

  struct QuestExilePath extends QuestData

    method operator Global takes nothing returns boolean
      return true
    endmethod
    
    private method operator CompletionPopup takes nothing returns string
      return "Nazjatar is now under the influence of the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Nazjatar"
    endmethod

    private method OnComplete takes nothing returns nothing
      call FACTION_NAGA.ModObjectLimit('n08W', UNLIMITED)   //Lost One Den
      call FACTION_NAGA.ModObjectLimit('ndrn', UNLIMITED)   //Vindicator
      call FACTION_NAGA.ModObjectLimit('ndrs', 6)   //Seer
      call SetUnitOwner(LEGEND_NZOTH.Unit, Player(PLAYER_NEUTRAL_AGGRESSIVE), true)
      set REDEMPTION_PATH.Progress = QUEST_PROGRESS_FAILED
      set MADNESS_PATH.Progress = QUEST_PROGRESS_FAILED
      call RescueNeutralUnitsInRect(gg_rct_NagaUnlock2, this.Holder.Player)
      call WaygateActivateBJ( true, gg_unit_n07E_1491 )
      call WaygateActivateBJ( true, gg_unit_n07E_0958 )
      call ShowUnitShow( gg_unit_n07E_1491  )
      call ShowUnitShow( gg_unit_n07E_0958 )
      call WaygateSetDestinationLocBJ( gg_unit_n07E_1491, GetRectCenter(gg_rct_NazjatarExit3) )
      call WaygateSetDestinationLocBJ( gg_unit_n07E_0958 , GetRectCenter(gg_rct_IllidanOutlandEntrance) )
      call SetPlayerTechResearched(FACTION_SENTINELS.Player, 'R06D', 1)
      set this.Holder.Name = "Illidari"
      call WaygateActivateBJ( true, gg_unit_h01D_3378 )
      call ShowUnitShow( gg_unit_h01D_3378 )
      call WaygateSetDestinationLocBJ( gg_unit_h01D_3378, GetRectCenter(gg_rct_NazjatarExit2) )
      call WaygateActivateBJ( true, gg_unit_h01A_0402 )
      call ShowUnitShow( gg_unit_h01A_0402 )
      call WaygateSetDestinationLocBJ( gg_unit_h01A_0402, GetRectCenter(gg_rct_NazjatarExit1) )
      call WaygateActivateBJ( true, gg_unit_h01D_3381 )
      call ShowUnitShow( gg_unit_h01D_3381 )
      call WaygateSetDestinationLocBJ( gg_unit_h01D_3381, GetRectCenter(gg_rct_NazjatarEntrance1) )
      call WaygateActivateBJ( true, gg_unit_h01D_3384 )
      call ShowUnitShow( gg_unit_h01D_3384 )
      call WaygateSetDestinationLocBJ( gg_unit_h01D_3384, GetRectCenter(gg_rct_NazjatarEntrance2) )
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("A Parting of Ways", "Illidan has to go his own way to find the power and Outland is the perfect place to acquire it.", "ReplaceableTextures\\CommandButtons\\BTNIllidanDemonicPower.blp")
      call this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, 'n055'))
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ILLIDAN, true))
      call this.AddQuestItem(QuestItemSelfExists.create())
      call this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_NazjatarHidden, "Nazjatar"))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary