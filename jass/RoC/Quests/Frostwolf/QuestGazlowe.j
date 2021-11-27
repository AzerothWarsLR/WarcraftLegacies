library QuestGazlowe requires QuestData, ControlPoint, FrostwolfSetup, LegendFrostwolf

  globals
    private constant integer RESEARCH_ID = 'R01F'
    private constant integer HERO_ID = 'Ntin'
  endglobals

  struct QuestGazlowe extends QuestData

    private method operator CompletionPopup takes nothing returns string
      return "With the Goblin homeland of Kezan now under " + this.Holder.Name + " control, the goblin Gazlowe offers his services as an expert engineer, upgrading your Shredders with new weaponry."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You can summon Gazlowe from the Altar of Storms, and Shredders learn to cast Pocket Factory, Saw Bombardment, and Emergency Repairs"
    endmethod

    private method OnComplete takes nothing returns nothing
      call SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit(HERO_ID, 1)
      call Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Explosive Engineering", "The Horde needs engineering skills if it is to thrive. The Goblins of Kezan could provide such expertise.", "ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp")
      call this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType('n04Z')))
      return this
    endmethod
  endstruct

endlibrary