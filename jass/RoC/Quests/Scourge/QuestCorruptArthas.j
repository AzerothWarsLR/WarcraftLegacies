library QuestCorruptArthas requires GeneralHelpers, LegendLordaeron, LordaeronSetup, QuestItemLegendDead, QuestItemEitherOf, QuestItemFactionDefeated

  globals
    private constant integer HERO_ID = 'Uear'
    private constant integer RESEARCH_ID = 'R01K'
  endglobals

  struct QuestCorruptArthas extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Having failed to protect his people, Arthas seizes the cursed runeblade Frostmourne as the instrument of his vengeance. The malevolence of the blade overwhelms him. Arthas is now a loyal Death Knight of the Scourge, and will soon become its greatest champion."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "You can train Arthas Menethil from the Altar of Darkness"
    endmethod

    private method OnComplete takes nothing returns nothing
      call UnitDropAllItems(LEGEND_ARTHAS.Unit)
      call RemoveUnit(LEGEND_ARTHAS.Unit)
      set LEGEND_ARTHAS.Unit = null
      set LEGEND_ARTHAS.PlayerColor = PLAYER_COLOR_PURPLE
      set LEGEND_ARTHAS.StartingXp = 7000
      set LEGEND_ARTHAS.UnitType = 'Uear'
      call LEGEND_ARTHAS.ClearUnitDependencies()
      call SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1)
    endmethod

    private method OnAdd takes nothing returns nothing
      call Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED)
      call Holder.ModObjectLimit(HERO_ID, 1)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Culling", "When the city of Stratholme, Prince Arthas will abandon his people and join the Scourge as their champion.", "ReplaceableTextures\\CommandButtons\\BTNHeroDeathKnight.blp")
      call this.AddQuestItem(QuestItemLegendDead.create(LEGEND_STRATHOLME))
      call this.AddQuestItem(QuestItemEitherOf.create(QuestItemLegendDead.create(LEGEND_ARTHAS), QuestItemFactionDefeated.create(FACTION_LORDAERON)))
      call this.AddQuestItem(QuestItemSelfExists.create())
      return this
    endmethod
  endstruct

endlibrary