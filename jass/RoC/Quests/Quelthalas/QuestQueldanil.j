library QuestQueldanil requires QuestData, QuelthalasSetup, LegendNeutral

  globals
    private constant integer QUEST_RESEARCH_ID = 'R074'   //This research is given when the quest is completed
  endglobals

  struct QuestQueldanil extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Quel'thalas has finally reunited with its lost rangers in the Hinterlands."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of Quel'danil Lodge"
    endmethod

    private method OnComplete takes nothing returns nothing
      local unit u
      loop
        set u = FirstOfGroup(udg_QuelDanilLodge)
        exitwhen u == null
        call UnitRescue(u, this.Holder.Player)
        call GroupRemoveUnit(udg_QuelDanilLodge, u)
      endloop
      call DestroyGroup(udg_QuelDanilLodge)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Quel'danil Lodge", "Quel'danil Lodge is a High Elven outpost situated in the Hinterlands. It's been some time since the rangers there have been in contact with Quel'thalas.", "ReplaceableTextures\\CommandButtons\\BTNBearDen.blp")
      call this.AddQuestItem(QuestItemAnyUnitInRect.create(gg_rct_QuelDanil_Lodge, "Quel'danil Lodge", true))
      call this.AddQuestItem(QuestItemTime.create(1200))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary