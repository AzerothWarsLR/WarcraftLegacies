library DummyCast requires DummyCaster

  globals
    private group TempGroup = CreateGroup()
  endglobals

  function interface CastFilter takes unit caster, unit target returns boolean

  function DummyChannelInstantFromPoint takes player whichPlayer, integer abilId, string orderId, integer level, real x, real y, real duration returns nothing
    local unit u = CreateUnit(whichPlayer, DUMMY_TYPE, x, y, 0)
    call UnitAddAbility(u, abilId)
    call IssueImmediateOrder(u, orderId)
    call UnitApplyTimedLife(u, 'BTLF', duration)
  endfunction

  function DummyCastUnit takes player whichPlayer, integer abilId, string orderId, integer level, unit u returns nothing
    call SetUnitOwner(DUMMY, whichPlayer, false)
    call SetUnitX(DUMMY, GetUnitX(u))
    call SetUnitY(DUMMY, GetUnitY(u))
    call UnitAddAbility(DUMMY, abilId)
    call SetUnitAbilityLevel(DUMMY, abilId, level)
    call IssueTargetOrder(DUMMY, orderId, u)
    call UnitRemoveAbility(DUMMY,abilId)        
  endfunction
  
  function DummyCastPoint takes player whichPlayer, integer abilId, string orderId, integer level, real x, real y returns nothing
    call SetUnitOwner(DUMMY, whichPlayer, false)
    call SetUnitX(DUMMY, x)
    call SetUnitY(DUMMY, y)
    call UnitAddAbility(DUMMY, abilId)
    call SetUnitAbilityLevel(DUMMY, abilId, level)
    call IssuePointOrder(DUMMY, orderId, x, y)
    call UnitRemoveAbility(DUMMY,abilId)            
  endfunction
  
  function DummyCastInstant takes player whichPlayer, integer abilId, string orderId, integer level, real x, real y returns nothing
    call SetUnitOwner(DUMMY, whichPlayer, false)
    call SetUnitX(DUMMY, x)
    call SetUnitY(DUMMY, y)
    call UnitAddAbility(DUMMY, abilId)
    call SetUnitAbilityLevel(DUMMY, abilId, level)
    call IssueImmediateOrder(DUMMY, orderId)
    call UnitRemoveAbility(DUMMY,abilId)            
  endfunction

  function DummyCastUnitFromPoint takes player whichPlayer, integer abilId, string orderId, integer level, unit u, real originX, real originY returns nothing
    call SetUnitOwner(DUMMY, whichPlayer, false)
    call SetUnitX(DUMMY, originX)
    call SetUnitY(DUMMY, originY)
    call UnitAddAbility(DUMMY, abilId)
    call SetUnitAbilityLevel(DUMMY, abilId, level)
    call IssueTargetOrder(DUMMY, orderId, u)
    call UnitRemoveAbility(DUMMY,abilId)
  endfunction

  function DummyCastFromPointOnUnitsInCircle takes unit caster, integer abilId, string orderId, integer level, real targetX, real targetY, real radius, real originX, real originY, CastFilter castFilter returns nothing
    local unit u
    call GroupEnumUnitsInRange(TempGroup, targetX, targetY, radius, null)
    loop
      set u = FirstOfGroup(TempGroup)
      exitwhen u == null
      if castFilter.evaluate(caster, u) then
        call DummyCastUnitFromPoint(GetOwningPlayer(caster), abilId, orderId, level, u, originX, originY)
      endif
      call GroupRemoveUnit(TempGroup, u)
    endloop
  endfunction

  function DummyCastUnitId takes player whichPlayer, integer abilId, integer orderId, integer level, unit u returns nothing
    call SetUnitOwner(DUMMY, whichPlayer, false)
    call SetUnitX(DUMMY, GetUnitX(u))
    call SetUnitY(DUMMY, GetUnitY(u))
    call UnitAddAbility(DUMMY, abilId)
    call SetUnitAbilityLevel(DUMMY, abilId, level)
    call IssueTargetOrderById(DUMMY, orderId, u)
    call UnitRemoveAbility(DUMMY,abilId)        
  endfunction

  function DummyCastOnUnitsInCircle takes unit caster, integer abilId, string orderId, integer level, real x, real y, real radius, CastFilter castFilter returns nothing
    local unit u
    call GroupEnumUnitsInRange(TempGroup, x, y, radius, null)
    loop
      set u = FirstOfGroup(TempGroup)
      exitwhen u == null
      if castFilter.evaluate(caster, u) then
        call DummyCastUnit(GetOwningPlayer(caster), abilId, orderId, level, u)
      endif
      call GroupRemoveUnit(TempGroup, u)
    endloop
  endfunction  

endlibrary
