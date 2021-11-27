library QuestBoralus requires QuestData, ScarletSetup, GeneralHelpers

  globals
    private constant integer QUEST_RESEARCH_ID = 'R00L'   //This research is given when the quest is completed
  endglobals

  struct QuestBoralus extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Kul'Tiras has joined the war and its military is now free to assist the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Kul'Tiras and enables Katherine Proodmoure to be trained at the altar"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_Kultiras, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_Kultiras, this.Holder.Player)
      if GetLocalPlayer() == this.Holder.Player then
        call PlayThematicMusicBJ( "war3mapImported\\KultirasTheme.mp3" )
      endif
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(QUEST_RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The City at Sea", "Proudmoore is stranded at sea. Rejoin Boralus to take control of the city.", "ReplaceableTextures\\CommandButtons\\BTNHumanShipyard.blp")
      call this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_ADMIRAL, gg_rct_Kultiras, "Kul'tiras"))
      call this.AddQuestItem(QuestItemUpgrade.create('h06I', 'h062'))
      call this.AddQuestItem(QuestItemExpire.create(1465))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary