library QuestStromgarde requires QuestData, StormwindSetup, LegendNeutral, GeneralHelpers

  globals
    private constant integer HERO_ID = 'H00Z'
    private constant integer RESEARCH_ID = 'R01M'
  endglobals

  struct QuestStromgarde extends QuestData
    private QuestItemAnyUnitInRect questItemAnyUnitInRect = 0

    private method operator CompletionPopup takes nothing returns string
      return "Galen Trollbane has pledged his forces to Stormwind's cause."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units at Stromgarde, the artifact Trol'kalar, and you can summon the hero Galen Trollbane from the Altar of Kings"
    endmethod

    private method GiveStromgarde takes player whichPlayer returns nothing
      local group tempGroup = CreateGroup()
      local unit u
      //Transfer all Neutral Passive units in Stromgarde
      call GroupEnumUnitsInRect(tempGroup, gg_rct_Stromgarde, null)
      loop
        set u = FirstOfGroup(tempGroup)
        exitwhen u == null
        if GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) then
          call UnitRescue(u, whichPlayer)
        endif
        call GroupRemoveUnit(tempGroup, u)
      endloop
      //Cleanup
      call DestroyGroup(tempGroup)
      set tempGroup = null
    endmethod

    private method OnFail takes nothing returns nothing
      call this.GiveStromgarde(Player(PLAYER_NEUTRAL_AGGRESSIVE))
      call SetItemPosition(ARTIFACT_TROLKALAR.item, 14088.9, 1236.3)
      call ARTIFACT_TROLKALAR.setStatus(ARTIFACT_STATUS_GROUND)
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.GiveStromgarde(this.Holder.Player)
      call UnitAddItemSafe(this.questItemAnyUnitInRect.TriggerUnit, ARTIFACT_TROLKALAR.item)
      call SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
      call Holder.ModObjectLimit(HERO_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Stromgarde", "Although Stromgarde's strength has dwindled since the days of the Arathorian Empire, it remains a significant bastion of humanity. They could be convinced to mobilize their forces for Stormwind.", "ReplaceableTextures\\CommandButtons\\BTNTheCaptain.blp")
      set this.questItemAnyUnitInRect = QuestItemAnyUnitInRect.create(gg_rct_Stromgarde, "Stromgarde", true)
      call this.AddQuestItem(this.questItemAnyUnitInRect)
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary