library QuestEndlessRanks requires QuestData, QuestItemKillUnit

  globals
    private constant integer QUEST_RESEARCH_ID = 'R07D'   //This research is given when the quest is completed
  endglobals

  struct QuestEndlessRanks extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Gates of Ahn'Qiraj can now be opened"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Enable the Gates of Ahn'Qiraj to be opened"
    endmethod


    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Endless Army", "Before opening the Gates of Ahn'Qiraj, the armies of C'thun need to darken the sky and shake the earth itself.", "ReplaceableTextures\\CommandButtons\\BTNSwarm.blp")
      call this.AddQuestItem(QuestItemTrain.create('n06I','o00R', 24))
      call this.AddQuestItem(QuestItemTrain.create('u013','o00R', 6))
      call this.AddQuestItem(QuestItemTrain.create('o02N', 'u01H', 24))
      call this.AddQuestItem(QuestItemTrain.create('h01K','u01H', 8))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary