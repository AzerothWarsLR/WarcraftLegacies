library QuestTownWatch requires QuestData

  struct QuestTownWatch extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Cultists have been eliminated, our towns are now safe"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Gain 4000 lumber and 500 gold"
    endmethod

    private method OnComplete takes nothing returns nothing
    call AdjustPlayerStateBJ( 500, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD )
    call AdjustPlayerStateBJ( 4000, this.Holder.Player, PLAYER_STATE_RESOURCE_LUMBER )
    endmethod

    private method OnAdd takes nothing returns nothing
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Cult of the Damned", "Heretic Cultists are spreading a deadly plague among the villages of Lordaeron, we must stop them, prevent the corruption and kill all the Cultists", "ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp")
      call this.AddQuestItem(QuestItemResearch.create('Rhse', 'h083'))
      call this.AddQuestItem(QuestItemBuild.create('h084', 8))
      call this.AddQuestItem(QuestItemKillXUnit.create('u01U', 3))
      return this
    endmethod
  endstruct

endlibrary