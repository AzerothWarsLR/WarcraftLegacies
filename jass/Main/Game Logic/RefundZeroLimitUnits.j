//If a unit with a tech limit of 0 is trained or revived, delete and refund it instantly.
library RefundZeroLimitUnits initializer OnInit requires Persons, UnitType

  private function VerifyUnitIntegrity takes unit u returns nothing
    local player p = GetOwningPlayer(u)
    local Person tempPerson = Person.ByHandle(p)
    local UnitType tempUnitType = 0
    if tempPerson.GetObjectLimit(GetUnitTypeId(u)) == 0 then
      set tempUnitType = UnitType.ByHandle(u)
      if tempUnitType != 0 then
        call AdjustPlayerStateSimpleBJ(p, PLAYER_STATE_RESOURCE_GOLD, tempUnitType.GoldCost)
        call AdjustPlayerStateSimpleBJ(p, PLAYER_STATE_RESOURCE_LUMBER, tempUnitType.LumberCost)
      endif
      call RemoveUnit(u)
    endif
    set u = null
    set p = null
  endfunction

  private function OnAnyUnitTrained takes nothing returns nothing
    call VerifyUnitIntegrity(GetTriggerUnit())
  endfunction

  private function OnAnyUnitRevived takes nothing returns nothing
    call VerifyUnitIntegrity(GetRevivingUnit())
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_TRAIN_FINISH, function OnAnyUnitTrained) 
    call PlayerUnitEventAddAction(EVENT_PLAYER_HERO_REVIVE_FINISH, function OnAnyUnitRevived) 
  endfunction

endlibrary