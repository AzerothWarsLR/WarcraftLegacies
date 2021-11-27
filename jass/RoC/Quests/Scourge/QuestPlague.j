library QuestPlague requires QuestData, ScourgeSetup

  globals
    private constant integer RESEARCH_ID = 'R06I'
  endglobals

  struct QuestPlague extends QuestData
    private method Global takes nothing returns boolean
      return true
    endmethod

    private method operator CompletionPopup takes nothing returns string
      return "The plague has been unleashed! The citizens of Lordaeron are quickly transforming into mindless zombies."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "A plague is unleashed upon the lands of Lordaeron"
    endmethod

    private method OnComplete takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, -UNLIMITED)
      call TriggerExecute( gg_trg_Plague_Actions )
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Plague of Undeath", "You can unleash a devastating zombifying plague across the lands of Lordaeron. Once it's started, you can type -off to deactivate Cauldron Zombie spawns. Type -end to stop citizens from turning into zombies.", "ReplaceableTextures\\CommandButtons\\BTNPlagueBarrel.blp")
      call this.AddQuestItem(QuestItemEitherOf.create(QuestItemResearch.create(RESEARCH_ID, 'u000'), QuestItemTime.create(960)))
      call this.AddQuestItem(QuestItemTime.create(360))
      return this
    endmethod
  endstruct

endlibrary