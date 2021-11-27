library QuestTheramore requires QuestData

  globals
    private constant integer RESEARCH_ID = 'R06K'
  endglobals

  struct QuestTheramore extends QuestData
    private static group theramoreUnits = CreateGroup()

    private method operator CompletionPopup takes nothing returns string
      return "A sizeable isle off the coast of Dustwallow Marsh has been colonized and dubbed Theramore, marking the first human settlement to be established on Kalimdor."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units at Theramore"
    endmethod

    private static method GrantToPlayer takes player whichPlayer returns nothing
      local unit u
      loop
        set u = FirstOfGroup(theramoreUnits)
        exitwhen u == null
        call UnitRescue(u, whichPlayer)
        call GroupRemoveUnit(theramoreUnits, u)
      endloop
      call DestroyGroup(theramoreUnits)
      set u = null
      set theramoreUnits = null
    endmethod

    private method OnFail takes nothing returns nothing
      call thistype.GrantToPlayer(Player(PLAYER_NEUTRAL_AGGRESSIVE))
      call this.Holder.ModObjectLimit(RESEARCH_ID, -UNLIMITED)
    endmethod

    private method OnComplete takes nothing returns nothing
      call thistype.GrantToPlayer(this.Holder.Player)
      call this.Holder.ModObjectLimit(RESEARCH_ID, -UNLIMITED)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)  
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Theramore", "The distant lands of Kalimdor remain untouched by human civilization. If the Third War proceeds poorly, it may become necessary to establish a forward base there.", "ReplaceableTextures\\CommandButtons\\BTNHumanArcaneTower.blp")
      call this.AddQuestItem(QuestItemResearch.create(RESEARCH_ID, 'h076'))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod

    private static method onInit takes nothing returns nothing
      local group tempGroup
      local unit u
      set tempGroup = CreateGroup()
      set theramoreUnits = CreateGroup()
      call GroupEnumUnitsInRect(tempGroup, gg_rct_Theramore, null)
      loop
        set u = FirstOfGroup(tempGroup)
        exitwhen u == null
        call SetUnitInvulnerable(u, true)
        call SetUnitOwner(u, Player(PLAYER_NEUTRAL_PASSIVE), true)
        call GroupAddUnit(theramoreUnits, u)
        call GroupRemoveUnit(tempGroup, u)
      endloop
      call DestroyGroup(tempGroup)
    endmethod
  endstruct

endlibrary