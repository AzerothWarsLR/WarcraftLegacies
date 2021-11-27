library ControlPoint initializer OnInit requires AIDS

  globals 
    group ControlPoints = CreateGroup()
    ControlPoint array CPData
    Event OnControlPointLoss    
    Event OnControlPointOwnerChange   
  endglobals
  
  struct ControlPoint
    private static thistype array byIndex
    private static Table byUnitType
    private static Table byHandle
    private static integer count = 0
    static thistype triggerControlPoint = 0
    static player controlPointFormerOwner = null

    real x
    real y
    real value = 0
    unit u
    player owner

    method operator UnitType takes nothing returns integer
      return GetUnitTypeId(this.u)
    endmethod

    method operator Name takes nothing returns string
      return GetUnitName(this.u)
    endmethod

    method operator X takes nothing returns real
      return GetUnitX(this.u)
    endmethod

    method operator Y takes nothing returns real
      return GetUnitY(this.u)
    endmethod

    method operator Unit takes nothing returns unit
      return this.u
    endmethod

    method operator OwningPerson takes nothing returns Person
      return Person.ByHandle(this.owner)
    endmethod

    method changeOwner takes player p returns nothing
      local Person person = Person.ByHandle(this.owner)
  
      if person != 0 then
        set person.ControlPointValue = person.ControlPointValue - value
        set person.ControlPointCount = person.ControlPointCount - 1
        call GroupRemoveUnit(person.cpGroup, this.u)
      endif
  
      set thistype.triggerControlPoint = this
      call OnControlPointLoss.fire()

      set thistype.controlPointFormerOwner = this.owner
      set this.owner = p
      set person = Person.ByHandle(this.owner)
      
      if person != 0 then
        set person.ControlPointValue = person.ControlPointValue + value
        set person.ControlPointCount = person.ControlPointCount + 1
        call GroupAddUnit(person.cpGroup, this.u)
      endif

      set thistype.triggerControlPoint = this
      call OnControlPointOwnerChange.fire()
    endmethod
    
    static method ByHandle takes unit whichUnit returns thistype
      return thistype.byHandle[GetHandleId(whichUnit)]
    endmethod

    static method ByUnitType takes integer unitType returns thistype
      return thistype.byUnitType[unitType]
    endmethod

    static method GetHighestValueCP takes Person person returns thistype
      local integer i = 0
      local ControlPoint highestValueCP = 0
      loop
      exitwhen i == thistype.count
        if thistype.byIndex[i].OwningPerson == person and thistype.byIndex[i].value > highestValueCP.value then
          set highestValueCP = thistype.byIndex[i]
        endif
        set i = i + 1
      endloop
      return highestValueCP
    endmethod

    static method create takes unit u, real value returns ControlPoint
      local ControlPoint this = ControlPoint.allocate()
      local Person person = Person.ByHandle(GetOwningPlayer(u))
      
      set this.x = GetUnitX(u)
      set this.y = GetUnitY(u)
      set this.u = u
      set this.owner = GetOwningPlayer(u)
      set this.value = value
      
      set CPData[GetUnitId(u)] = this 
      
      call GroupAddUnit(ControlPoints,u)
      call GroupAddUnit(person.cpGroup, u)

      set OwningPerson.ControlPointValue = OwningPerson.ControlPointValue + this.value
      set OwningPerson.ControlPointCount = OwningPerson.ControlPointCount + 1

      set thistype.byUnitType[GetUnitTypeId(u)] = this
      set thistype.byHandle[GetHandleId(u)] = this
      set thistype.byIndex[thistype.count] = this
      set thistype.count = count + 1
      
      return this           
    endmethod        

    private static method onInit takes nothing returns nothing
      set thistype.byUnitType = Table.create()
      set thistype.byHandle = Table.create()
    endmethod

    method destroy takes nothing returns nothing
      call RemoveUnit(this.u)
      set OwningPerson.ControlPointValue = OwningPerson.ControlPointValue - this.value*-1
      set OwningPerson.ControlPointCount = OwningPerson.ControlPointCount - 1
      call this.deallocate()
    endmethod  
  endstruct

  function GetControlPointPreviousOwner takes nothing returns player
    return ControlPoint.controlPointFormerOwner
  endfunction

  function GetTriggerControlPoint takes nothing returns ControlPoint
    return ControlPoint.triggerControlPoint
  endfunction

  //Only provides an event response; internal logic is handled by ControlPoint struct    
  private function CPChangesOwner takes nothing returns nothing
    local unit u = GetTriggerUnit()
    local integer ui = GetUnitUserData(u)
    local player p = GetTriggerPlayer()
    
    if CPData[ui] != 0 then
      call CPData[ui].changeOwner(p)
    endif

    set u = null
    set p = null
  endfunction
  
  //Note that the Init function currently enumerates across every single unit on the map, then checks them for a Control Point buff before initializing them as a CP
  //This is not a good way to do this, considering that we know which units are CPs before the map is even compiled
  private function OnInit takes nothing returns nothing
    local group g
    local trigger trig = CreateTrigger()

    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_CHANGE_OWNER, function CPChangesOwner) //TODO: use filtered events
    
    set OnControlPointLoss = Event.create()
    set OnControlPointOwnerChange = Event.create()
  endfunction
    
endlibrary