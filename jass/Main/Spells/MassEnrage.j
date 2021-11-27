library MassEnrage initializer OnInit requires DummyCast

  globals
    private constant integer ABIL_ID = 'A0QK'
    private constant integer DUMMY_ABIL_ID = 'ACuf'
    private constant string DUMMY_ORDER_STRING = "unholyfrenzy"
    private constant real RADIUS = 50.
  endglobals

  private function EnrageFilter takes unit caster, unit target returns boolean
    if IsUnitAlly(target, GetOwningPlayer(caster)) and not IsUnitType(target, UNIT_TYPE_STRUCTURE) and not IsUnitType(target, UNIT_TYPE_ANCIENT) and not IsUnitType(target, UNIT_TYPE_MECHANICAL) and IsUnitAliveBJ(target) then
      return true
    endif
    return false
  endfunction

  private function Cast takes nothing returns nothing
    local unit caster = null
    local integer level
    set caster = GetTriggerUnit()
    set level = GetUnitAbilityLevel(caster, ABIL_ID) 
    call DummyCastOnUnitsInCircle(GetTriggerUnit(), DUMMY_ABIL_ID, DUMMY_ORDER_STRING, GetUnitAbilityLevel(GetTriggerUnit(), ABIL_ID), GetSpellTargetX(), GetSpellTargetY(), (RADIUS*level)+100, CastFilter.EnrageFilter)
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterSpellEffectAction(ABIL_ID, function Cast)
  endfunction

endlibrary