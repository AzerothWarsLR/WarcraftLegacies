library QuestGoblinEmpire requires QuestData, KultirasSetup

  globals 
    private constant integer QUEST_RESEARCH_ID = 'R07F'   //This research is given when the quest is completed
  endglobals

  struct QuestGoblinEmpire extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "With all the Goblin towns united, a new empire rises!"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Unlock the Intercontinental Artillery"
    endmethod

    private method OnComplete takes nothing returns nothing
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Goblin Empire", "All the Goblin syndicates towns must be reunited under one banner", "ReplaceableTextures\\CommandButtons\\BTNGoblinWarZeppelin.blp")
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01X')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n00L')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n07Y')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n01E')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n04Z')))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n05C')))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary