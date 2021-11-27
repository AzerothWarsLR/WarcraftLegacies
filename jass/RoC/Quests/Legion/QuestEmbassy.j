library QuestEmbassy requires QuestData, LegionSetup

  globals
    private constant integer OBJECT_ID = 'u00U'
    private constant integer HERO_ID = 'U00L'
    private constant integer ALTAR_ID = 'u01N'
  endglobals

  struct QuestEmbassy extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The Legion has secured a foothold on Azeroth."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You can build the Infernal Machine Factory and summon Anetheron from the " + GetObjectName(ALTAR_ID)
    endmethod

    private method OnAdd takes nothing returns nothing
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Infernal Foothold", "A stronger foothold in this world will be required to field the Burning Legion's war machines and to call in more of its lieutenants.", "ReplaceableTextures\\CommandButtons\\BTNDemonBlackCitadel.blp")
      call this.AddQuestItem(QuestItemUpgrade.create(OBJECT_ID, 'u00N'))
      set this.ResearchId = 'R042'
      return this
    endmethod
  endstruct

endlibrary