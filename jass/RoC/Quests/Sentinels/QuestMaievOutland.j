library QuestMaievOutland requires Persons, QuelthalasSetup, GeneralHelpers

  struct QuestMaievOutland extends QuestData

    private method operator CompletionPopup takes nothing returns string
      return "Maiev's Outland outpost have been constructed."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Control of Maiev's Outland outpost and moves Maiev to Outland"
    endmethod    

    private method OnComplete takes nothing returns nothing
      call SetUnitPosition(LEGEND_MAIEV.Unit, -5252, -27597)
      call UnitRemoveAbilityBJ( 'A0J5', LEGEND_MAIEV.Unit)
      call RescueUnitsInGroup(udg_MaievUnlockOutland, this.Holder.Player)
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Driven by Vengeance", "Maiev drive for vengeance leads her to chase Illidan all the way to other worlds.", "ReplaceableTextures\\CommandButtons\\BTNMaievArmor.blp")
      call this.AddQuestItem(QuestItemCastSpell.create('A0J5', true))
      call this.AddQuestItem(QuestItemControlLegend.create(LEGEND_MAIEV, true))
      return this
    endmethod
  endstruct

endlibrary