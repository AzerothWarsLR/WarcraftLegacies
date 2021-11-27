library QuestBusinessExpansion requires QuestData

  globals
    private constant integer QUEST_RESEARCH_ID = 'R07G'   //This research is given when the quest is completed
  endglobals

  struct QuestBusinessExpansion extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Jastor Gallywix now trainable"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Jastor Gallywix is trainable at the altar"
    endmethod

    private method OnComplete takes nothing returns nothing
      if GetLocalPlayer() == this.Holder.Player then
        call PlayThematicMusicBJ( "war3mapImported\\GoblinTheme.mp3" )
      endif
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Business Expansion", "Trade Prince Gallywix will need a great amount of wealth to rule the future Goblin Empire, he needs to expand his business all over the world quickly", "ReplaceableTextures\\CommandButtons\\BTNGoblinPrince.blp")
      call this.AddQuestItem(QuestItemTrain.create('nzep','o04M', 16))
      call this.AddQuestItem(QuestItemTrain.create('o04S','o04M', 10))
      set this.ResearchId = QUEST_RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary