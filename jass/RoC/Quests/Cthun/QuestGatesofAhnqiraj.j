library QuestGatesofAhnqiraj requires QuestData, QuestItemKillUnit

  struct QuestGatesofAhnqiraj extends QuestData

    method operator Global takes nothing returns boolean
      return true
    endmethod

    private method operator CompletionPopup takes nothing returns string
      return "The Old God C'thun has awaken and is now ready to unleash the Qiraji on the world of Azeorth."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Gain control of C'thun and enable you to open the Gates of Ahn'qiraj"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetUnitInvulnerable(gg_unit_h02U_2413, false)
      call PlayThematicMusicBJ( "war3mapImported\\CthunTheme.mp3" )
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Gates of Ahn'Qiraj", "The Old God C'thun is still slumbering, Skeram will need to awaken him with an unholy ritual.", "ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp")
      call this.AddQuestItem(QuestItemCastSpell.create('A0O1', true))
      return this
    endmethod
  endstruct

endlibrary