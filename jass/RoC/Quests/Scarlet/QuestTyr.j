library QuestTyr requires QuestData, ScarletSetup

 globals
    private constant integer RESEARCH_ID = 'R03R'   //This research is given when the quest is completed
  endglobals

  struct QuestTyr extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Tyr Hand has joined the war and its military is now free to assist the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of all units in Tyr Hand"
    endmethod

    private method OnFail takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_TyrUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE))
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueNeutralUnitsInRect(gg_rct_TyrUnlock, this.Holder.Player)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Scarlet Enclave", "Tyr's Hand are neutral for the moment, but when the time is right, they will align themselves with the Scarlet Crusade", "ReplaceableTextures\\CommandButtons\\BTNCastle.blp")
      call this.AddQuestItem(QuestItemTime.create(1000))
      call this.AddQuestItem(QuestItemSelfExists.create())
      set this.ResearchId = RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary