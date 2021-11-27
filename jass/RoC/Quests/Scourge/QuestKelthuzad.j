library QuestKelthuzad requires QuestData, ScourgeSetup, LegendScourge, LegendQuelthalas

  struct QuestKelthuzad extends QuestData
    private method operator CompletionPopup takes nothing returns string
      local string completionPopup = "Kel'thuzad has been reanimated and empowered through the unlimited magical energies of the Sunwell."
      if FACTION_LEGION != 0 then
        set completionPopup = completionPopup + " He now has the ability to summon the Burning Legion."
      endif
      return completionPopup
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Kel'thuzad becomes a Lich"
    endmethod

    private method OnComplete takes nothing returns nothing
      set LEGEND_KELTHUZAD.UnitType = UNITTYPE_KELTHUZAD_LICH
      set LEGEND_KELTHUZAD.PermaDies = false
      call SetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_LIFE, GetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_MAX_LIFE))
      call SetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_MANA, GetUnitState(LEGEND_KELTHUZAD.Unit, UNIT_STATE_MAX_MANA))
      call DestroyEffect(AddSpecialEffect("war3mapImported\\Soul Beam Blue.mdx", GetUnitX(LEGEND_KELTHUZAD.Unit), GetUnitY(LEGEND_KELTHUZAD.Unit)))
      call DestroyEffect(AddSpecialEffect("Abilities\\Spells\\Undead\\FrostNova\\FrostNovaTarget.mdl", GetUnitX(LEGEND_KELTHUZAD.Unit), GetUnitY(LEGEND_KELTHUZAD.Unit)))
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Life Beyond Death", "Kel'thuzad is the leader of the Cult of the Damned and an extraordinarily powerful necromancer. If he were to be brought to the Sunwell and submerged in its waters, he would be reanimated as an immortal Lich.", "ReplaceableTextures\\CommandButtons\\BTNLichVersion2.blp")
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_SUNWELL, false))
      call this.AddQuestItem(QuestItemLegendInRect.create(LEGEND_KELTHUZAD, gg_rct_Sunwell, "The Sunwell"))
      return this
    endmethod
  endstruct

endlibrary