
library CPCapture initializer OnInit requires AIDS

  //**CONFIG
  globals
    private constant real CAPTURE_THRESHOLD = 0.85   //Percentage of maximum HP; below this, the CP will go to the damager
  endglobals
  //*ENDCONFIG

  private function Actions takes nothing returns nothing
    local unit attacker = GetEventDamageSource()
    local unit attacked = GetTriggerUnit()
    local real hp    

    if IsUnitInGroup(GetTriggerUnit(), ControlPoints) then
      set hp = (GetUnitState(attacked, UNIT_STATE_LIFE) - GetEventDamage()) / GetUnitState(attacked, UNIT_STATE_MAX_LIFE)
      if hp < CAPTURE_THRESHOLD then
        call BlzSetEventDamage(0)
        call SetUnitOwner(attacked, GetOwningPlayer(attacker), true)
        call SetUnitLifePercentBJ(attacked, 100)
      endif  
    endif      

    set attacker = null
    set attacked = null     
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DAMAGED, function Actions) //TODO: use filtered events, since all Control Points identities are known
    call TriggerAddCondition(trig,Condition(function Actions))
  endfunction

endlibrary
