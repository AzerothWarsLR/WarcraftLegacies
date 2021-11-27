//System to allow structures to convert themselves into Kodos. Those Kodos can then use an ability to rebuild the building.
library StructurePacking requires Table, AIDS

  globals
    private constant integer KODO_ID = 'oosc'
  endglobals

  struct PackKodo extends array
    //! runtextmacro AIDS()
    effect PackedBuildingEffect

    private static method AIDS_filter takes unit u returns boolean
      if GetUnitTypeId(u) == KODO_ID then
        return true
      endif
      return false
    endmethod

    private method AIDS_onDestroy takes nothing returns nothing
      call DestroyEffect(PackedBuildingEffect)
      set PackedBuildingEffect = null
    endmethod
  endstruct

  struct PackableStructure
    private static Table byStructureId
    private integer structureId
    private integer buildAbility
    private string structureModel

    method SetupKodo takes unit whichUnit returns nothing
      local effect e = AddSpecialEffectTarget(this.structureModel, whichUnit, "overhead")
      call BlzSetSpecialEffectScale(e, 0.25)
      call BlzSetSpecialEffectTime(e, 100.)
      set PackKodo(GetUnitId(whichUnit)).PackedBuildingEffect = e
      call UnitAddAbility(whichUnit, this.buildAbility)
      set e = null
    endmethod

    static method create takes integer structureId, string structureModel, integer buildAbility returns thistype
      local thistype this = thistype.allocate()
      set thistype.byStructureId[structureId] = this
      set this.structureModel = structureModel
      set this.buildAbility = buildAbility
      return this
    endmethod

    static method ByStructureId takes integer structureId returns thistype
      return thistype.byStructureId[structureId]
    endmethod

    private static method packBuilding takes unit building, unit kodo returns nothing
      if thistype.byStructureId[GetUnitTypeId(building)] == 0 then
        call BJDebugMsg("ERROR: there is no PackableStructure setup for building "+ GetUnitName(building))
        return
      endif
      call thistype(thistype.byStructureId[GetUnitTypeId(building)]).SetupKodo(kodo)
      call RemoveUnit(building)
    endmethod

    private static method OnAnyUnitCastSpell takes nothing returns nothing
      if GetUnitTypeId(GetTriggerUnit()) == KODO_ID then
        call KillUnit(GetTriggerUnit())
        call RemoveUnit(GetTriggerUnit())
      endif
    endmethod

    private static method OnTrainAnyUnit takes nothing returns nothing
      if GetUnitTypeId(GetTrainedUnit()) == KODO_ID then
        call thistype.packBuilding(GetTriggerUnit(), GetTrainedUnit())
        call RemoveUnit(GetTriggerUnit())
      endif
    endmethod

    private static method onInit takes nothing returns nothing
      local trigger trig = CreateTrigger()
      call TriggerRegisterAnyUnitEventBJ( trig, EVENT_PLAYER_UNIT_TRAIN_FINISH )
      call TriggerAddAction( trig, function thistype.OnTrainAnyUnit)

      set trig = CreateTrigger()
      call TriggerRegisterAnyUnitEventBJ( trig, EVENT_PLAYER_UNIT_SPELL_ENDCAST )
      call TriggerAddAction( trig, function thistype.OnAnyUnitCastSpell)

      set thistype.byStructureId = Table.create()
    endmethod
  endstruct

endlibrary