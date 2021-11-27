library MassBanish initializer OnInit requires T32, DummyCast, FilteredCastEvents

  globals
    private constant integer ABIL_ID = 'A0FD'
    private constant integer DUMMY_ABIL_ID = 'A0FE'
    private constant string DUMMY_ORDER_STRING = "banish"
    private constant real RADIUS = 250.
  endglobals

  private function BanishFilter takes unit caster, unit target returns boolean
    if not IsUnitType(target, UNIT_TYPE_STRUCTURE) and not IsUnitType(target, UNIT_TYPE_ANCIENT) and not IsUnitType(target, UNIT_TYPE_MECHANICAL) and IsUnitAliveBJ(target) then
      return true
    endif
    return false
  endfunction

  private function Cast takes nothing returns nothing
    call DummyCastOnUnitsInCircle(GetTriggerUnit(), DUMMY_ABIL_ID, DUMMY_ORDER_STRING, GetUnitAbilityLevel(GetTriggerUnit(), ABIL_ID), GetSpellTargetX(), GetSpellTargetY(), RADIUS, CastFilter.BanishFilter)
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterSpellEffectAction(ABIL_ID, function Cast)
  endfunction

endlibrary