library QuestZandalar requires QuestData, TrollSetup

  globals
    private constant integer QUEST_RESEARCH_ID = 'R04W'   //This research is given when the quest is completed
  endglobals

  struct QuestZandalar extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The City of Gold is now yours to command and has joined the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Zandalar and enables the Golden Fleet to be built"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_ZandalarUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_ZandalarUnlock, this.Holder.Player)
      if GetLocalPlayer() == this.Holder.Player then
        call PlayThematicMusicBJ( "war3mapImported\\ZandalarTheme.mp3" )
      endif
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("City of Gold", "The Blood Trolls rebellion has to be put down.", "ReplaceableTextures\\CommandButtons\\BTNBloodTrollMage.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_ndtw_2405)) //Dark Troll Warchief
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n0A8')))
      call this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_PRIEST, gg_rct_ZandalarUnlock, "Dazar'alor"))
      call this.AddQuestItem(QuestItemExpire.create(1420))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary