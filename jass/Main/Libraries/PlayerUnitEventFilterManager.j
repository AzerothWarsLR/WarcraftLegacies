//Provides a single trigger for each generic event.
//"Filtered" events can then be registered against each trigger.
//For example, you can create an event for "A Footman attacks", and only actions registered against that filtered event will fire.
//This is a substantial performance boost.
library PlayerUnitEventFilterManager

  globals
    private hashtable array Triggers
  endglobals

  //Try to execute all actions registered to an event that match a given filteredEventType and filterValue
  function PlayerUnitEventExecute takes playerunitevent whichPlayerUnitEvent, FilteredEventType filteredEventType, integer filterValue returns nothing
    local hashtable hashTable = Triggers[GetHandleId(whichPlayerUnitEvent)]
    local trigger trig = LoadTriggerHandle(hashTable, filteredEventType, filterValue)
    if trig != null then
      call TriggerExecute(trig)
    endif
  endfunction

  //Register an action against an event, filtered by a filteredEventType and an expected filterValue
  function PlayerUnitEventAddFilteredAction takes playerunitevent whichPlayerUnitEvent, code whichTriggerAction, FilteredEventType filteredEventType, integer filterValue returns nothing
    local hashtable hashTable = Triggers[GetHandleId(whichPlayerUnitEvent)]
    local trigger trig = LoadTriggerHandle(hashTable, filteredEventType, filterValue)
    if trig == null then
      set trig = CreateTrigger()
      call SaveTriggerHandle(hashTable, filteredEventType, filterValue, trig)
    endif
    call TriggerAddAction(trig, whichTriggerAction)
  endfunction

  //Register a generic trigger, like you would with TriggerRegisterAnyUnitEventBJ
  function PlayerUnitEventAddAction takes playerunitevent whichPlayerUnitEvent, code whichTriggerAction returns nothing
    local trigger trig
    //There is one hashtable per playerunitevent
    local hashtable hashTable = Triggers[GetHandleId(whichPlayerUnitEvent)]
    if hashTable == null then
      set hashTable = InitHashtable()
      set Triggers[GetHandleId(whichPlayerUnitEvent)] = hashTable
    endif
    //Each hashtable maintains a list of triggers indexed by a filterValue and a filteredEventType, but [0,0] is reserved for the unfiltered event
    set trig = LoadTriggerHandle(hashTable, 0, 0)
    if trig == null then
      set trig = CreateTrigger()
      call TriggerRegisterAnyUnitEventBJ(trig, whichPlayerUnitEvent)
      call SaveTriggerHandle(hashTable, 0, 0, trig)
    endif
    call TriggerAddAction(trig, whichTriggerAction)
  endfunction

  //Used to index filtered events. For example, you might have a type for a unit type being attacked, and another type for a unit type attacking.
  struct FilteredEventType
      
  endstruct

endlibrary