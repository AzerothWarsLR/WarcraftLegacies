library QuestZulgurub requires LegendNeutral

  globals
    private constant integer ZULGURUB_RESEARCH = 'R02M'
    private constant integer TROLL_SHRINE_ID = 'o04X'
    private constant integer RAVAGER_ID = 'o021'
  endglobals

  struct QuestZulgurub extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Zul'Gurub has fallen. The Gurubashi trolls lend their might to the " + this.Holder.Team.Name  + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of Zul'Gurub and the ability to train " + GetObjectName(RAVAGER_ID) + "s from the " + GetObjectName(TROLL_SHRINE_ID)
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(Holder.Player, ZULGURUB_RESEARCH, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(ZULGURUB_RESEARCH, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Heart of Hakkar", "The Gurubashi trolls of Zul'Gurub follow the sacred Heart of Hakkar, hidden within their shrine. Capture it to gain their loyalty.", "ReplaceableTextures\\CommandButtons\\BTNTrollRavager.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ZULGURUB, false))
      return this
    endmethod
  endstruct

endlibrary