library QuestStonemaul requires QuestData, WarsongSetup, QuestItemKillUnit

  globals
    private constant integer QUEST_RESEARCH_ID = 'R03S'   //This research is given when the quest is completed
  endglobals

  struct QuestStonemaul extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Stonemaul has been liberated, and its military is now free to assist the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Stonemaul and 3000 lumber"
    endmethod

    private method GrantStonemaul takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u

      //Transfer all Neutral Passive units in Stonemaul
      call GroupEnumUnitsInRect(tempGroup, gg_rct_StonemaulKeep, null)
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
      call this.GrantStonemaul(Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GrantStonemaul(this.Holder.Player)
    endmethod

    private method OnAdd takes nothing returns nothing
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Chieftain's Challenge", "The Ogres of Stonemaul follow the strongest, slay the Chieftain to gain control of the base.", "ReplaceableTextures\\CommandButtons\\BTNOneHeadedOgre.blp")
      call this.AddQuestItem(QuestItemKillUnit.create(gg_unit_noga_1228)) //Korgall
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n022')))
      call this.AddQuestItem(QuestItemExpire.create(1505))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary