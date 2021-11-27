library QuestThunderEagle requires QuestData, QuestItemControlPoint, LordaeronSetup, LegendLegion

  globals
    private constant integer RESEARCH_ID = 'R04L'
    private constant integer THUNDER_EAGLE_ID = 'nwe2'
  endglobals

  struct QuestThunderEagle extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Thunder Eagles, now in safe hands " + this.Holder.Name + "."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Learn to train " + GetObjectName(THUNDER_EAGLE_ID) + "s"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1)
      call DisplayUnitTypeAcquired(this.Holder.Player, THUNDER_EAGLE_ID, "You can now train Thunder Eagles from upgraded Town Halls and from your capitals.")
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("To the Skies!", "The Thunder Eagles of the Storm Peaks live in fear of the Legion. Wipe out the Legion Nexus to bring these great birds out into the open.", "ReplaceableTextures\\CommandButtons\\BTNWarEagle.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_LEGIONNEXUS))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n02S')))
      return this
    endmethod
  endstruct

endlibrary