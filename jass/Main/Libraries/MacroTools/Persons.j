library Persons initializer OnInit requires Math, GeneralHelpers, Event, Filters

  globals   
    force Observers

    Event OnPersonFactionChange
  endglobals

  struct Person
    private static thistype array byId
    readonly static thistype triggerPerson = 0         //Used in event response triggers
    readonly static Faction prevFaction = 0            //Used in OnPersonFactionChange event response for the previous faction 

    private Faction faction                  //Controls name, available objects, color, and icon
    private integer controlPointCount = 0
    private real controlPointValue = 0        //Gold per minute           
    private player p                         //The player this struct is indexed to  
     
    private real partialGold = 0              //Just used for income calculations
    readonly group cpGroup                    //Group of control point units this person owns  

    private Table objectLimits
    private Table objectLevels

    method operator Player takes nothing returns player
      return this.p
    endmethod

    method operator Faction takes nothing returns Faction
      return this.faction
    endmethod

    method operator Faction= takes Faction newFaction returns nothing
      local integer i = 0
      local Faction prevFaction

      set this.prevFaction = this.faction
      set thistype.prevFaction = this.faction

      //Unapply old faction
      if this.faction != 0 then   
        set this.faction = 0 
        if this.prevFaction != 0 then
          set this.prevFaction.Person = 0 //Referential integrity
        endif
      endif

      //Apply new faction
      if newFaction != 0 then
        if newFaction.Person == 0 then    
          call SetPlayerColorBJ(this.p, newFaction.playCol, true)
          set this.faction = newFaction 
          //Enforce referential integrity
          if newFaction.Person != this then
            set newFaction.Person = this 
          endif
        else
          call BJDebugMsg("Error: attempted to set Person " + GetPlayerName(this.p) + " to already occupied faction with name " + newFaction.name)
        endif
      endif

      set thistype.triggerPerson = this
      call OnPersonFactionChange.fire()
    endmethod

    method operator ControlPointValue takes nothing returns real
      return this.controlPointValue
    endmethod

    method operator ControlPointValue= takes real value returns nothing
      if (value < 0) then
        call BJDebugMsg("ERROR: Tried to assign a negative ControlPointValue value to " + GetPlayerName(this.p))
      endif
      set this.controlPointValue = value
    endmethod

    method operator ControlPointCount takes nothing returns integer
      return this.controlPointCount
    endmethod

    method operator ControlPointCount= takes integer value returns nothing
      if (value < 0) then
        call BJDebugMsg("ERROR: Tried to assign a negative ControlPoint counter to " + GetPlayerName(this.p))
      endif
      set this.controlPointCount = value
    endmethod

    method GetObjectLevel takes integer object returns integer
      return this.objectLevels[object]
    endmethod

    method SetObjectLevel takes integer object, integer level returns nothing
      set this.objectLevels[object] = level
      call SetPlayerTechResearched(this.Player, object, level)
    endmethod

    method GetObjectLimit takes integer id returns integer
      return this.objectLimits[id]
    endmethod

    method SetObjectLimit takes integer id, integer limit returns nothing
      set this.objectLimits[id] = limit
      call this.SetObjectLevel(id, IMinBJ(GetPlayerTechCount(this.Player, id, true), limit))
      if limit >= UNLIMITED then
        call SetPlayerTechMaxAllowed(this.Player, id, -1)
      elseif limit <= 0 then
        call SetPlayerTechMaxAllowed(this.Player, id, 0)
      else
        call SetPlayerTechMaxAllowed(this.Player, id, limit)
      endif
    endmethod

    method ModObjectLimit takes integer id, integer limit returns nothing
      call this.SetObjectLimit(id, this.objectLimits[id] + limit)
    endmethod
    
    method addGold takes real x returns nothing
      local real fullGold = floor(x)
      local real remainderGold = x - fullGold
      
      call SetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD) + R2I(fullGold))
      set this.partialGold = this.partialGold + remainderGold
      
      loop
      exitwhen this.partialGold < 1
        set this.partialGold = this.partialGold - 1
        call SetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD) + 1)
      endloop
    endmethod

    private method nullFaction takes nothing returns nothing
      
    endmethod

    method destroy takes nothing returns nothing
      call DestroyGroup(this.cpGroup)

      set thistype.byId[GetPlayerId(this.p)] = 0
      set this.p = null
      set this.cpGroup = null 

      call this.deallocate()
    endmethod

    static method ById takes integer id returns thistype
      return thistype.byId[id]
    endmethod

    static method ByHandle takes player whichPlayer returns thistype
      return thistype.byId[GetPlayerId(whichPlayer)]
    endmethod

    static method create takes player p returns Person
      local Person this = Person.allocate()
      
      set this.p = p
      set this.cpGroup = CreateGroup()
      set thistype.byId[GetPlayerId(p)] = this
      set this.objectLimits = Table.create()
      set this.objectLevels = Table.create()
      
      return this           
    endmethod

  endstruct

  function GetChangingPersonPrevFaction takes nothing returns Faction
    return Person.prevFaction
  endfunction

  function GetTriggerPerson takes nothing returns Person
    return Person.triggerPerson
  endfunction

  private function OnInit takes nothing returns nothing
    set Observers = CreateForce()
    set OnPersonFactionChange = Event.create()
  endfunction

endlibrary