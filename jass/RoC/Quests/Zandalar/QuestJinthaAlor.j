library QuestJinthaAlor requires LegendNeutral

  globals
    private constant integer JINTHAALOR_RESEARCH = 'R02N'
    private constant integer BEAR_RIDER_ID = 'o02K'
    private constant integer TROLL_SHRINE_ID = 'o04X'
  endglobals

  struct QuestJinthaAlor extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Jintha'Alor has fallen. The Vilebranch trolls lend their might to the " + this.Holder.Team.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of Jintha'Alor and the ability to train " + GetObjectName(BEAR_RIDER_ID) + "s from the " + GetObjectName(TROLL_SHRINE_ID)
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(Holder.Player, JINTHAALOR_RESEARCH, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(JINTHAALOR_RESEARCH, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Ancient Egg", "The Vilebranch trolls of Jintha'Alor are controlled by their fear of the Soulflayer's egg, hidden within their shrine. Smash it to gain their loyalty.", "ReplaceableTextures\\CommandButtons\\BTNForestTrollShadowPriest.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_JINTHAALOR, false))
      return this
    endmethod
  endstruct

endlibrary