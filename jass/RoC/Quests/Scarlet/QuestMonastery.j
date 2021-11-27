library QuestMonastery requires QuestData, ScarletSetup, QuestItemResearch, QuestItemSelfExists, GeneralHelpers

  globals
    private constant integer RESEARCH_ID = 'R03P'         //This research is required to complete the quest
    private constant integer QUEST_RESEARCH_ID = 'R03F'   //This research is given when the quest is completed
  endglobals

  struct QuestMonastery extends QuestData

    method operator Global takes nothing returns boolean
      return true
    endmethod

    private method operator CompletionPopup takes nothing returns string
      return "The Scarlet Monastery Hand is complete and ready to join the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in the Scarlet Monastery and you will unally the alliance"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_ScarletAmbient, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(FACTION_KULTIRAS.Player, 'R06V', 1)
      call RescueNeutralUnitsInRect(gg_rct_ScarletAmbient, this.Holder.Player)
      call WaygateActivateBJ( true, gg_unit_h00T_0786 )
      call WaygateSetDestinationLocBJ( gg_unit_h00T_0786, GetRectCenter(gg_rct_Scarlet_Monastery_Interior) )
      set this.Holder.Team = TEAM_SCARLET
      set this.Holder.Name = "Scarlet"
      set this.Holder.Icon = "ReplaceableTextures\\CommandButtons\\BTNSaidan Dathrohan.blp"
      call PlayThematicMusicBJ( "war3mapImported\\ScarletTheme.mp3" )
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Secret Cloister", "The Scarlet Monastery is the perfect place for the secret base of the Scarlet Crusade ", "ReplaceableTextures\\CommandButtons\\BTNDivine_Reckoning_Icon.blp")
      call this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, 'h00T'))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary