library Artifact initializer OnInit requires Table, Event, Persons, Shore

  globals
    Event OnArtifactCreate
    Event OnArtifactAcquire
    Event OnArtifactDrop
    Event OnArtifactDestroy
    Event OnArtifactOwnerChange                     //The owner of this Artifact changes
    Event OnArtifactStatusChange                    //An Artifact changes status
    Event OnArtifactFactionChange                   //The owner of this Artifact changes factions
    Event OnArtifactCarrierOwnerChange              //The unit carrying an Artifact changes player ownership
    Event OnArtifactDescriptionChange               //The Artifact has its description changed. This is just text and is not represented anywhere by the Artifact itself

    constant integer ARTIFACT_STATUS_GROUND = 0     //Artifact is on the ground
    constant integer ARTIFACT_STATUS_UNIT = 1       //Artifact is held by a unit
    constant integer ARTIFACT_STATUS_SPECIAL = 2    //Artifact is nowhere, but artifically has a location
    constant integer ARTIFACT_STATUS_HIDDEN = 3     //Artifact does not allow pinging, and only displays text (which is not set automatically)

    constant integer ARTIFACT_HOLDER_ABIL_ID = 'A01Y'
  endglobals

  //A node in an ArtifactGroup
  private struct ArtifactNode
    thistype next = 0
    thistype prev = 0

    readonly Artifact whichArtifact     

    method hasNext takes nothing returns boolean
      if this.next != 0 then
        return true
      endif
      return false
    endmethod

    static method create takes Artifact whichArtifact returns thistype
      local thistype this = thistype.allocate()

      set this.whichArtifact = whichArtifact

      return this
    endmethod        
  endstruct

  //A linkedlist of Artifacts for iteration
  struct ArtifactGroup
    static thistype array artifactGroupsByPlayerId      //A list of ArtifactGroups indexed by player ID, automatically populated by the system
    static Table artifactGroupsByOwningUnit             //A list of ArtifactGroups indexed by the handle ID of the owning unit
    private Table artifactNodesByArtifact               //A list of Artifact nodes as indexed by their Artifact ID     
    ArtifactNode first
    ArtifactNode last

    method setOwningPersons takes Person p returns nothing
      local ArtifactNode tempArtifactNode = this.first
      loop
      exitwhen tempArtifactNode == 0
        call tempArtifactNode.whichArtifact.setOwningPerson(p)
        set tempArtifactNode = tempArtifactNode.next
      endloop  
    endmethod

    method updateFactions takes nothing returns nothing
      local ArtifactNode tempArtifactNode = this.first
      loop
      exitwhen tempArtifactNode == 0
        call tempArtifactNode.whichArtifact.updateFaction()
        set tempArtifactNode = tempArtifactNode.next
      endloop  
    endmethod

    method destroy takes nothing returns nothing
      call this.clear()
      call this.artifactNodesByArtifact.destroy()
      call this.deallocate()
    endmethod

    method clear takes nothing returns nothing
      local ArtifactNode tempArtifactNode = 0
      loop
      exitwhen this.last == 0
        set tempArtifactNode = this.last        
        set this.last = this.last.prev
        call tempArtifactNode.destroy()
      endloop
    endmethod

    method remove takes Artifact whichArtifact returns nothing
      local ArtifactNode tempArtifactNode = this.artifactNodesByArtifact[whichArtifact]

      set tempArtifactNode.prev.next = tempArtifactNode.next
      set tempArtifactNode.next.prev = tempArtifactNode.prev

      if this.first == tempArtifactNode then
        set this.first = tempArtifactNode.next
      endif

      if this.last == tempArtifactNode then
        set this.last = tempArtifactNode.prev
      endif

      set this.artifactNodesByArtifact[whichArtifact] = 0

      call tempArtifactNode.destroy()
    endmethod

    method add takes Artifact whichArtifact returns nothing
      local ArtifactNode newArtifactNode = ArtifactNode.create(whichArtifact)

      set this.last.next = newArtifactNode
      set newArtifactNode.prev = this.last            
      set this.last = newArtifactNode

      if this.first == 0 then
        set this.first = newArtifactNode
      endif

      set this.artifactNodesByArtifact[whichArtifact] = newArtifactNode
    endmethod

    static method create takes nothing returns thistype 
      local thistype this = thistype.allocate()

      set this.artifactNodesByArtifact = Table.create()

      return this
    endmethod

    static method onInit takes nothing returns nothing
      local integer i = 0
      loop
      exitwhen i > MAX_PLAYERS
        set thistype.artifactGroupsByPlayerId[i] = thistype.create()    //These should really get destroyed at some point if the Person gets destroyed
        set i = i + 1
      endloop
      set thistype.artifactGroupsByOwningUnit = Table.create()
    endmethod
  endstruct

  struct Artifact
    static Table artifactsByType
    readonly static Artifact triggerArtifact = 0
    readonly item item = null
    readonly Person owningPerson = 0
    private unit owningUnit = null
    readonly integer status = 0
    readonly string description = null                  //More like a situation describer; eg "Owned by xx..." or "Unknown location"

    real falseX = 0                                     //Where the map should ping this artifact when it is in SPECIAL status mode
    real falseY = 0                                     //^        

    method updateFaction takes nothing returns nothing
      set thistype.triggerArtifact = this
      call OnArtifactFactionChange.fire()
    endmethod

    method setStatus takes integer i returns nothing
      if this.status != i then
        set this.status = i
        set thistype.triggerArtifact = this
        call OnArtifactStatusChange.fire()
      endif
    endmethod

    method operator OwningUnit takes nothing returns unit
      return this.owningUnit
    endmethod

    method setOwningUnit takes unit u returns nothing
      local ArtifactGroup tempArtifactGroup = 0
      //Remove this Artifact from the ArtifactGroup belonging to the former owning unit, destroying if it is now empty
      set tempArtifactGroup = ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(this.owningUnit)]
      if tempArtifactGroup != 0 then
        call tempArtifactGroup.remove(this)
        if tempArtifactGroup.first == 0 then
          call tempArtifactGroup.destroy()
        endif
      endif
      
      //Transfer ownership
      set this.owningUnit = u     

      //Add this Artifact to the ArtifactGroup belonging to this particular unit, first creating it if it doesn't exist
      if this.owningUnit != null then
        set tempArtifactGroup = ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(u)]
        if tempArtifactGroup == 0 then
          set ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(u)] = ArtifactGroup.create()
          set tempArtifactGroup = ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(u)]
        endif
        call tempArtifactGroup.add(this)
      endif

      //Change the owner Person if needed
      if this.owningPerson != Person.ByHandle(GetOwningPlayer(u)) then
        if u != null then
          call this.setOwningPerson(Person.ByHandle(GetOwningPlayer(u)))
        else
          call this.setOwningPerson(0)
        endif
      endif
    endmethod

    method setOwningPerson takes Person p returns nothing
      if this.owningPerson != 0 then
        call ArtifactGroup.artifactGroupsByPlayerId[GetPlayerId(this.owningPerson.Player)].remove(this) //Remove this from the old owner's Artifact group
      endif

      if p != 0 then
        call ArtifactGroup.artifactGroupsByPlayerId[GetPlayerId(p.Player)].add(this) //Add this to the new owner's Artifact Group
      endif

      set this.owningPerson = p
      set thistype.triggerArtifact = this
      call OnArtifactOwnerChange.fire()

      if this.owningPerson != 0 then
        call this.setStatus(ARTIFACT_STATUS_UNIT)
      else
        call this.setStatus(ARTIFACT_STATUS_GROUND)
      endif
    endmethod

    method setDescription takes string s returns nothing
      set this.description = s
      set thistype.triggerArtifact = this
      call OnArtifactDescriptionChange.fire()
    endmethod

    method pickedUp takes nothing returns nothing
      set Artifact.triggerArtifact = this
      call this.setOwningUnit(GetTriggerUnit())
      call OnArtifactAcquire.fire()
    endmethod

    method dropped takes nothing returns nothing
      local Shore tempShore = 0
      set Artifact.triggerArtifact = this

      if not IsTerrainPathable(GetUnitX(this.owningUnit), GetUnitY(this.owningUnit), PATHING_TYPE_FLOATABILITY) and IsTerrainPathable(GetUnitX(this.owningUnit), GetUnitY(this.owningUnit), PATHING_TYPE_WALKABILITY) then
        set tempShore = GetNearestShore(GetUnitX(this.owningUnit), GetUnitY(this.owningUnit))
        set this.item = CreateItem(GetItemTypeId(this.item), tempShore.x, tempShore.y)
      endif

      //Remove dummy Artifact holding ability if the dropping unit had one
      if GetUnitAbilityLevel(this.owningUnit, ARTIFACT_HOLDER_ABIL_ID) > 0 then
        call UnitRemoveAbility(this.owningUnit, ARTIFACT_HOLDER_ABIL_ID)
      endif

      call this.setOwningPerson(0)
      call this.setOwningUnit(null)
      call OnArtifactDrop.fire()
    endmethod

    method ping takes player p returns nothing
      if GetLocalPlayer() == p then
        if this.status == ARTIFACT_STATUS_SPECIAL then
          call PingMinimap(this.falseX, this.falseY, 3.)
        elseif this.owningUnit != null then
          call PingMinimap(GetUnitX(this.owningUnit), GetUnitY(this.owningUnit), 3.)
        else
          call PingMinimap(GetItemX(this.item), GetItemY(this.item), 3.)
        endif
      endif            
    endmethod

    method destroy takes nothing returns nothing
      set thistype.triggerArtifact = this
      call OnArtifactDestroy.fire()
      call RemoveItem(this.item)
      set this.item = null
      call this.deallocate()
    endmethod

    static method create takes item whichItem returns Artifact
      local thistype this = thistype.allocate()
      if thistype.artifactsByType[GetItemTypeId(whichItem)] == null then
        set thistype.artifactsByType[GetItemTypeId(whichItem)] = this
        set thistype.triggerArtifact = this     //For event response
        set this.item = whichItem
        set this.status = 0
        call this.setOwningPerson(0)
        call OnArtifactCreate.fire()
        return this
      else
        call BJDebugMsg("ERROR: Attempted to create already existing Artifact from " + GetItemName(whichItem))
        return 0
      endif
    endmethod

    private static method onInit takes nothing returns nothing
      set thistype.artifactsByType = Table.create()
    endmethod
  endstruct 

  function GetTriggerArtifact takes nothing returns Artifact
    return Artifact.triggerArtifact
  endfunction         

  private function ItemPickup takes nothing returns nothing
    local Artifact tempArtifact = Artifact.artifactsByType[GetItemTypeId(GetManipulatedItem())]
    if tempArtifact != 0 then
      call tempArtifact.pickedUp()
    endif
  endfunction

  private function ItemDrop takes nothing returns nothing
    local Artifact tempArtifact = 0
    if not IsUnitIllusion(GetTriggerUnit()) then
      set tempArtifact = Artifact.artifactsByType[GetItemTypeId(GetManipulatedItem())]
      if tempArtifact != 0 then
        call tempArtifact.dropped()
      endif
    endif
  endfunction

  private function OnPersonFactionChanged takes nothing returns nothing
    call ArtifactGroup.artifactGroupsByPlayerId[GetPlayerId(GetTriggerPerson().Player)].updateFactions()
  endfunction

  private function UnitChangeOwner takes nothing returns nothing
    local ArtifactGroup tempArtifactGroup = ArtifactGroup.artifactGroupsByOwningUnit[GetHandleId(GetTriggerUnit())]
    if tempArtifactGroup != 0 then
      if GetTriggerUnit() != null then
        call tempArtifactGroup.setOwningPersons(Person.ByHandle(GetOwningPlayer(GetTriggerUnit())))
      else
        call tempArtifactGroup.setOwningPersons(0)
      endif
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call OnPersonFactionChange.register(trig)
    call TriggerAddAction(trig, function OnPersonFactionChanged)

    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_PICKUP_ITEM, function ItemPickup) //TODO: use filtered events
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DROP_ITEM, function ItemDrop) //TODO: use filtered events
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_CHANGE_OWNER, function UnitChangeOwner) //TODO: use filtered events

    set OnArtifactCreate = Event.create()
    set OnArtifactAcquire = Event.create()
    set OnArtifactDrop = Event.create()
    set OnArtifactDestroy = Event.create()
    set OnArtifactOwnerChange = Event.create()
    set OnArtifactStatusChange = Event.create()
    set OnArtifactFactionChange = Event.create() 
    set OnArtifactCarrierOwnerChange = Event.create()   
    set OnArtifactDescriptionChange = Event.create()  
  endfunction  

endlibrary