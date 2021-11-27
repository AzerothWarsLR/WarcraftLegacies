library QuestLichKingArthas requires QuestData, ScourgeSetup, Artifact, GeneralHelpers

  struct QuestLichKingArthas extends QuestData
    method operator Global takes nothing returns boolean
      return true
    endmethod

    private method operator CompletionPopup takes nothing returns string
      return "Arthas has ascended the Frozen Throne itself and shattered Ner'zhul's frozen prison. Ner'zhul and Arthas are now joined, body and soul, into one being: the god-like Lich King."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Arthas becomes the Lich King, but the Frozen Throne loses its abilities"
    endmethod

    private method OnComplete takes nothing returns nothing
      call PlayThematicMusicBJ( "Sound\\Music\\mp3Music\\LichKingTheme.mp3" )
      set LEGEND_LICHKING.DeathMessage = "Icecrown Citadel been razed. Unfortunately, the Lich King has already vacated his unholy throne."
      set LEGEND_LICHKING.PermaDies = false
      set LEGEND_LICHKING.Hivemind = false
      call UnitRemoveAbility(LEGEND_LICHKING.Unit, 'A0W8')
      call UnitRemoveAbility(LEGEND_LICHKING.Unit, 'A0L3')
      call UnitRemoveAbility(LEGEND_LICHKING.Unit, 'A002')
      call UnitRemoveAbility(LEGEND_LICHKING.Unit, 'A001')
      call BlzSetUnitMaxMana(LEGEND_LICHKING.Unit, 0)
      call BlzSetUnitName(LEGEND_LICHKING.Unit, "Icecrown Citadel")
      set LEGEND_ARTHAS.UnitType = 'N023'
      set LEGEND_ARTHAS.PermaDies = true
      set LEGEND_ARTHAS.Hivemind = true
      set LEGEND_ARTHAS.DeathMessage = "The great Lich King has been destroyed. With no central mind to command them, the forces of the Undead have gone rogue."
      call SetUnitState(LEGEND_ARTHAS.Unit, UNIT_STATE_LIFE, GetUnitState(LEGEND_ARTHAS.Unit, UNIT_STATE_MAX_LIFE))
      call SetUnitState(LEGEND_ARTHAS.Unit, UNIT_STATE_MANA, GetUnitState(LEGEND_ARTHAS.Unit, UNIT_STATE_MAX_MANA))
      call UnitAddItemSafe(LEGEND_ARTHAS.Unit, ARTIFACT_HELMOFDOMINATION.item)
      set this.Holder.Team = TEAM_SCOURGE
      call UnitRescue(gg_unit_h00O_2516, FACTION_SCOURGE.Player)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The Ascension", "From within the depths of the Frozen Throne, the Lich King Ner'zhul cries out for his champion. Release the Helm of Domination from its confines and merge its power with that of the Scourge's greatest Death Knight.", "ReplaceableTextures\\CommandButtons\\BTNRevenant.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_ARTHAS, false))
      call this.AddQuestItem(QuestItemLegendLevel.create(LEGEND_ARTHAS, 12))
      call this.AddQuestItem(QuestItemResearch.create('R07X', 'u000'))
      call this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_ARTHAS, gg_rct_LichKing, "Icecrown Citadel"))
      return this
    endmethod
  endstruct

endlibrary