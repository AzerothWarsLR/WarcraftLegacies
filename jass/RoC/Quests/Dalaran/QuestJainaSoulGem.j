//Jaina goes to Scholomance while Scholomance building is destroyed and retrieves the Soul Gem
library QuestJainaSoulGem requires QuestData, Artifact, LegendDalaran, LegendScourge, GeneralHelpers

  struct QuestJainaSoulGem extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Jaina Proudmoore has discovered the Soul Gem within the ruined vaults at Scholomance."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "The Soul Gem"
    endmethod

    private method OnComplete takes nothing returns nothing
      call UnitAddItemSafe(LEGEND_JAINA.Unit, ARTIFACT_SOULGEM.item) 
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Soul Gem", "Scholomance is home to a wide variety of profane artifacts. Bring Jaina there to see what might be discovered.", "ReplaceableTextures\\CommandButtons\\BTNSoulGem.blp")
      call this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_JAINA, gg_rct_Jaina_soul_gem, "Scholomance"))
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_SCHOLOMANCE))
      return this
    endmethod
  endstruct

endlibrary