library QuestCapitalCity requires QuestData, LordaeronSetup, QuestItemControlPoint, QuestItemExpire, QuestItemSelfExists, GeneralHelpers

  globals
    private constant integer RESEARCH_ID = 'R04Y'   //This research is given when the quest is completed
  endglobals

  struct QuestCapitalCity extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Capital City has been liberated, and its military is now free to assist the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Capital City"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_Terenas, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_Terenas, this.Holder.Player)
      call SetUnitInvulnerable(gg_unit_nemi_0019, true)
      if GetLocalPlayer() == this.Holder.Player then
        call PlayThematicMusicBJ("war3mapImported\\CapitalCity.mp3")
      endif
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Hearthlands", "The territories of Lordaeron are fragmented. Regain control of the old Alliance's hold to secure the kingdom.", "ReplaceableTextures\\CommandButtons\\BTNCastle.blp")
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01M')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01C')))
      call this.AddQuestItem(QuestItemExpire.create(1472))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary