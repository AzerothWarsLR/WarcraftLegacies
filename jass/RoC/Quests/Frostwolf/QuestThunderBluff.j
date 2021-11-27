//If the Centaur Khan dies, OR a time elapses, give Thunder Bluff to a Horde player.
library QuestThunderBluff initializer OnInit requires Persons, FrostwolfSetup, WarsongSetup, GeneralHelpers

  globals
    private group ThunderBluffUnits
    private constant integer QUEST_RESEARCH_ID = 'R05I' 
  endglobals

  struct QuestThunderBluff extends QuestData

    private method operator CompletionPopup takes nothing returns string
      return "The Crossroads have been constructed."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of Thunder Bluff"
    endmethod    

    private method OnFail takes nothing returns nothing
        call RescueNeutralUnitsInRect(gg_rct_ThunderBluff, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_ThunderBluff, this.Holder.Player)
      if GetLocalPlayer() == this.Holder.Player then
        call PlayThematicMusicBJ( "war3mapImported\\TaurenTheme.mp3" )
      endif
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Long March", "The Tauren have been wandering for too long. The plains of Mulgore would offer respite from this endless journey.", "ReplaceableTextures\\CommandButtons\\BTNCentaurKhan.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_CENTAURKHAN))
      call this.AddQuestItem(QuestItemAnyUnitInRect.create(gg_rct_ThunderBluff, "Thunder Bluff", true))
      call this.AddQuestItem(QuestItemExpire.create(1455))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

  private function OnInit takes nothing returns nothing
    //Setup initially invulnerable and hidden group at Thunder Bluff
    local group tempGroup = CreateGroup()
    local unit u
    local integer i = 0
    set ThunderBluffUnits = CreateGroup()
    call GroupEnumUnitsInRect(tempGroup, gg_rct_ThunderBluff, null)
    loop
      set u = FirstOfGroup(tempGroup)
      exitwhen u == null
      if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) then
        call SetUnitInvulnerable(u, true)
        call GroupAddUnit(ThunderBluffUnits, u)
      endif
      call GroupRemoveUnit(tempGroup, u)
      set i = i + 1
    endloop
    call DestroyGroup(tempGroup)
    set tempGroup = null
    
  endfunction

endlibrary