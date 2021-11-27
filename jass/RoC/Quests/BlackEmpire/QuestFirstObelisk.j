library QuestFirstObelisk requires QuestData, GeneralHelpers, BlackEmpirePortal, Herald

  struct QuestFirstObelisk extends QuestData
    private method operator CompletionPopup takes nothing returns string
      return "The first Obelisk has been summoned, but Ny'alotha's connection to Azeroth is not yet stable. More Obelisks must be erected."
    endmethod

    private method operator CompletionDescription takes nothing returns string
      return "Unlock the northern zone of Nya'lotha, and the next Herald you train will open a temporary portal to Northern Highlands."
    endmethod

    private method OnComplete takes nothing returns nothing
      call RescueUnitsInGroup(udg_NyalothaGroup1, this.Holder.Player)
      call RemoveDestructable(gg_dest_ATg1_35873)
      call RemoveDestructable(gg_dest_ATg3_35872)
      call RemoveUnit(Herald.Instance.unit)
      call BlackEmpirePortal.GoToNext()
    endmethod

    public static method create takes nothing returns thistype
      local thistype this = thistype.allocate("The First Obelisk", "The twisted reality of Ny'alotha is a mere shadow of Azeroth, but that will soon change. The first step in merging the two realities is to establish an Obelisk in Northrend.", "ReplaceableTextures\\CommandButtons\\BTNIceCrownObelisk.blp")
      call this.AddQuestItem(QuestItemObelisk.create(ControlPoint.ByUnitType('n02S')))
      return this
    endmethod
  endstruct

endlibrary