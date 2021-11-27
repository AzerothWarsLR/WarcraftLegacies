library QuestGadgetzan requires QuestData, GoblinSetup, QuestItemKillUnit

  globals
    private constant integer QUEST_RESEARCH_ID = 'R07E'   //This research is given when the quest is completed
  endglobals

  struct QuestGadgetzan extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "We can train Noggenfogger and Gadgetzan is now under our influence and its military is now free to assist the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all buildings in Gadgetzan and enables Noggenfogger to be built at the altar"
    endmethod

    private method GrantGadetzan takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in Gadetzan
      call GroupEnumUnitsInRect(tempGroup, gg_rct_GadgetUnlock, null)
      set u = FirstOfGroup(tempGroup)
      loop
      exitwhen u == null
        if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) then
          call UnitRescue(u, whichPlayer)
        endif
        call GroupRemoveUnit(tempGroup, u)
        set u = FirstOfGroup(tempGroup)
      endloop
      call DestroyGroup(tempGroup)
      set tempGroup = null      
    endmethod

    private method OnFail takes nothing returns nothing
      call this.GrantGadetzan(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GrantGadetzan(this.Holder.Player)
    endmethod

    private method OnAdd takes nothing returns nothing
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Gadgetzan", "The city of Gadgetzan is a perfect foothold into Kalimdor", "ReplaceableTextures\\CommandButtons\\BTNHeroAlchemist.blp")
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n05C')))
      call this.AddQuestItem(QuestItemExpire.create(1522))
      call this.AddQuestItem(QuestItemSelfExists.create())
         set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary