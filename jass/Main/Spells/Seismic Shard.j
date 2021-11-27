library SeismicShard initializer OnInit requires T32, DummyCast

  globals
    private constant integer ABIL_ID = 'A0OD'
    private constant integer DUMMY_ABIL_ID = 'A0OE'
    private constant string DUMMY_ORDER_STRING = "thunderbolt"
    private constant real RADIUS = 250.
  endglobals

  private function SeismicFilter takes unit caster, unit target returns boolean
    if not IsUnitAlly(target, GetOwningPlayer(caster)) and not IsUnitType(target, UNIT_TYPE_STRUCTURE) and not IsUnitType(target, UNIT_TYPE_ANCIENT) and not IsUnitType(target, UNIT_TYPE_MECHANICAL) and IsUnitAliveBJ(target) then
      return true
    endif
    return false
  endfunction

  private function Cast takes nothing returns nothing
    call DummyCastFromPointOnUnitsInCircle(GetTriggerUnit(), DUMMY_ABIL_ID, DUMMY_ORDER_STRING, GetUnitAbilityLevel(GetTriggerUnit(), ABIL_ID), GetSpellTargetX(), GetSpellTargetY(), RADIUS, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()), CastFilter.SeismicFilter)
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterSpellEffectAction(ABIL_ID, function Cast)
  endfunction

endlibrary