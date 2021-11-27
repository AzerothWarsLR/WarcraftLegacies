library QuestFountainOfBlood requires QuestData, WarsongSetup, LegendNeutral

  globals
    private constant integer RESEARCH_ID = 'R00X'
  endglobals

  struct QuestFountainOfBlood extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Fountain of Blood is under Warsong control. As the orcs drink from it, they feel a a familiar fury awake within them."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Allows Orcish units to increase their attack rate and movement speed temporarily"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Blood of Mannoroth", "Long ago, the orcs drank the blood of Mannoroth and were infused with demonic fury. A mere taste of his blood would reignite those powers.", "ReplaceableTextures\\CommandButtons\\BTNFountainOfLifeBlood.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_FOUNTAINOFBLOOD, false))
      return this
    endmethod
  endstruct

endlibrary