library EmpowerIntellect initializer OnInit requires PlayerUnitEventFilterManager

  globals
    private constant integer BUFF_ID = 'B069'
    private constant real REFUND_MULT = 0.75
  endglobals
 
  private function Cast takes nothing returns nothing
    local unit triggerUnit = null
    if (GetUnitAbilityLevel(GetTriggerUnit(), BUFF_ID) > 0) then
      set triggerUnit = GetTriggerUnit()
      call SetUnitState(triggerUnit, UNIT_STATE_MANA, GetUnitState(triggerUnit, UNIT_STATE_MANA) + I2R(BlzGetAbilityManaCost(GetSpellAbilityId(), GetUnitAbilityLevel(triggerUnit, BUFF_ID))) * REFUND_MULT)
      set triggerUnit = null
		endif
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_EFFECT, function Cast)
  endfunction 
    
endlibrary
