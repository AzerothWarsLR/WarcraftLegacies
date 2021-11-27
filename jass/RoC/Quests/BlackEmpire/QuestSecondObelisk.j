library QuestSecondObelisk requires QuestData, GeneralHelpers, BlackEmpirePortal, Herald

  struct QuestSecondObelisk extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The second Obelisk has been set. Ny'alotha's connection to Azeroth grows stronger."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Unlock the southern zone of Nya'lotha, and the next Herald you train will open a temporary portal to Tanaris."
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueUnitsInGroup(udg_NyalothaGroup2, this.Holder.Player)
      call RescueUnitsInGroup(udg_NyalothaGroup3, this.Holder.Player)
      call RemoveDestructable(gg_dest_ATg2_35871)
      call RemoveDestructable(gg_dest_ATg3_35869)
      call RemoveUnit(Herald.Instance.unit)
      call BlackEmpirePortal.GoToNext()
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("Second Obelisk", "The convergence of realities grows ever closer. An Obelisk must be established in the Twilight Highlands, near the Maw of Madness.", "ReplaceableTextures\\CommandButtons\\BTNIceCrownObelisk.blp")
      call this.AddQuestItem(QuestItemObelisk.create(ControlPoint.ByUnitType('n04V')))
      return this
    endmethod
  endstruct

endlibrary