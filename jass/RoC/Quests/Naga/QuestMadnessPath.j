library QuestMadnessPath requires QuestData, NagaSetup, GeneralHelpers

  globals
    private constant integer RESEARCH_ID = 'R065'         //This research is required to complete the quest
    private constant integer QUEST_RESEARCH_ID = 'R033'   //This research is given when the quest is completed
  endglobals

  struct QuestMadnessPath extends QuestData
    method operator Global takes nothing returns boolean
      return true
    endmethod
    
    private method operator CompletionPopup takes nothing returns string
      return "Nazjatar is now under the influence of the Old Gods and the portal is opened to Ny'alotha."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You gain control of all units in Nazjatar, a portal is opened to Ny'alotha, and you join the Old Gods team"
    endmethod

    private method GrantNazjatar takes nothing returns nothing
      call SetUnitOwner(gg_unit_n07E_0958, Player(PLAYER_NEUTRAL_AGGRESSIVE), true)
      call ShowUnit(gg_unit_n07E_0958, true)
      call RescueNeutralUnitsInRect(gg_rct_NagaUnlock2, this.Holder.Player)
    endmethod

    private method RenameIllidanFaction takes nothing returns nothing
      set this.Holder.Team = TEAM_OLDGOD
      set this.Holder.Name = "Nazjatar"
      set this.Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNNagaSummoner.blp"
    endmethod

    private method FailQuests takes nothing returns nothing
      set REDEMPTION_PATH.Progress = QUEST_PROGRESS_FAILED
      set EXILE_PATH.Progress = QUEST_PROGRESS_FAILED
    endmethod

    private method TransferHeroes takes nothing returns nothing
      call SetUnitOwner(LEGEND_NZOTH.Unit, this.Holder.Player, true)
      call LEGEND_AZSHARA.Spawn(Holder.Player, GetRectCenterX(gg_rct_InstanceNazjatar), GetRectCenterY(gg_rct_InstanceNazjatar), 270)
      call SetHeroLevel(LEGEND_AZSHARA.Unit, 9, false)
      call SetUnitOwner(LEGEND_ILLIDAN.Unit, Player(PLAYER_NEUTRAL_AGGRESSIVE), true)
    endmethod

    private method AdjustTechtree takes nothing returns nothing
      call FACTION_NAGA.ModObjectLimit('n08V', UNLIMITED) //Depth Void Portal
      call FACTION_NAGA.ModObjectLimit('h01Q', 4) //Immortal Guardian
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GrantNazjatar()
      call this.AdjustTechtree()
      call this.FailQuests()
      call this.TransferHeroes()
      set BLACKEMPIREPORTAL_ILLIDAN.PortalState = BLACKEMPIREPORTALSTATE_OPEN
      call this.RenameIllidanFaction()
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
      local thistype this = thistype.allocate("Voices in the Void", "Azshara takes command of the Naga in the name of N'zoth. Illidan reign is no more.", "ReplaceableTextures\\CommandButtons\\BTNGuardianofTheSea.blp")
      call this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, 'n055'))
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ILLIDAN, true))
      call this.AddQuestItem(QuestItemSelfExists.create())
      call this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_NazjatarHidden, "Nazjatar"))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary