library QuestBlademaster requires QuestData, ScarletSetup, GeneralHelpers

 globals
    private constant integer QUEST_RESEARCH_ID = 'R04U'   //This research is given when the quest is completed
  endglobals

  struct QuestBlademaster extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "We have recaptured the capital ship."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "The capital ship and the end of the orc attacks"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_BlademasterUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_BlademasterUnlock, this.Holder.Player)
      call RescueNeutralUnitsInRect(gg_rct_ShipAmbient, this.Holder.Player)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Remnants of the Second War", "This island is infested by orcs, they have captured our Flagship. Kill them all", "ReplaceableTextures\\CommandButtons\\BTNHeroBlademaster.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_o00G_1521)) //Blademaster
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary