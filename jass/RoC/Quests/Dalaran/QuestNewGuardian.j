library QuestNewGuardian requires LegendDalaran, Display, GeneralHelpers

  struct QuestNewGuardian extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "Dalaran has empowered Jaina to be the new Guardian of Tirisfal, endowing her with a portion of the Council of Tirisfal's power."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Grant Jaina Chaos Damage, 20 additional Intelligence, Teleport, and Mana Shield"
    endmethod

    private method OnComplete takes nothing returns nothing
      local unit whichUnit = LEGEND_JAINA.Unit
      call UnitRemoveAbilityBJ( 'A0RB', LEGEND_JAINA.Unit)
      call AddSpecialEffectTarget("war3mapImported\\Soul Armor Cosmic.mdx", whichUnit, "chest")
      call BlzSetUnitName(whichUnit, "Guardian of Tirisfal")
      call UnitAddAbility(whichUnit, 'A0BX') //Guardian of Tirisfal Spellbook
      call BlzSetUnitWeaponIntegerField(whichUnit, UNIT_WEAPON_IF_ATTACK_ATTACK_TYPE, 0, 5) //Chaos
      call AddHeroAttributes(whichUnit, 0, 0, 20)
      call LEGEND_JAINA.ClearUnitDependencies()
      set LEGEND_JAINA.PermaDies = false
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Guardian of Tirisfal", "Medivh's death left Azeroth without a Guardian. The spell book he left behind could be used to empower a new one.", "ReplaceableTextures\\CommandButtons\\BTNAstral Blessing.blp")
      call this.AddQuestItem(QuestItemLegendLevel.create(LEGEND_JAINA, 12))
      call this.AddQuestItem(QuestItemLegendHasArtifact.create(LEGEND_JAINA, ARTIFACT_BOOKOFMEDIVH))
      return this
    endmethod
  endstruct

endlibrary