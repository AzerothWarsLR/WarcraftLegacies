//Anyone on the Night Elves team approaches Moonglade with a unit with the Horn of Cenarius,
//Causing Malfurion to spawn.
library QuestHakkar requires TrollSetup, LegendTroll


  struct QuestHakkar extends QuestData
    
    method operator Global takes nothing returns boolean
      return true
    endmethod
    
    private method operator CompletionPopup takes nothing returns string
      return "Hakkar has emerged from the Drowned Temple"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Gain the demigod hero Hakkar"
    endmethod

    private method OnComplete takes nothing returns nothing
      call LEGEND_HAKKAR.Spawn(Holder.Player, GetRectCenterX(gg_rct_DrownedTemple), GetRectCenterY(gg_rct_DrownedTemple), 270)
      call SetHeroLevel(LEGEND_HAKKAR.Unit, 8, false)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Binding of the Soulflayer", "Hakkar is the most dangerous and powerful of the Troll gods. Only by fusing the Demon Soul would the Zandalari be able to control Hakkar and bind him to their will.", "ReplaceableTextures\\CommandButtons\\BTNWindSerpent2.blp")
      call this.AddQuestItem(QuestItemAcquireArtifact.create(ARTIFACT_DEMONSOUL))
      call this.AddQuestItem(QuestItemArtifactInRect.create(ARTIFACT_DEMONSOUL, gg_rct_DrownedTemple, "The Drowned Temple"))
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n00U')))
      return this
    endmethod
  endstruct

endlibrary