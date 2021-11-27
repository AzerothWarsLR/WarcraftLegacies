library QuestFeludius requires QuestData, TwilightSetup, QuestItemLegendDead

  globals
    private constant integer RESEARCH_ID = 'R07T'
  endglobals

  struct QuestFeludius extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The great Al'akir has gifted one of our followers with Ascendance"
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You can summon Feludius from the Altar"
    endmethod


    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Gift of the Windlord", "Bringing the Legendary Sword, Thunderfury, to Uldum will grant us the favors of Al'akir, the great Wind Elemental Lord", "ReplaceableTextures\\CommandButtons\\BTNfuryoftheair.blp")
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n0BD')))
      call this.AddQuestItem(QuestItemArtifactInRect.create(ARTIFACT_THUNDERFURY, gg_rct_UldumAmbiance, "Uldum"))
      set this.ResearchId = RESEARCH_ID
      return this
    endmethod
  endstruct

endlibrary