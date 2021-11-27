library MassIceArmor initializer OnInit requires DummyCast

  globals
    private constant integer ABIL_ID = 'A0H3'
    private constant integer DUMMY_ABIL_ID = 'A0H6'
    private constant string DUMMY_ORDER_STRING = "frostarmor"
    private constant real RADIUS = 400.
  endglobals

  private function BanishFilter takes unit caster, unit target returns boolean
    if IsUnitAlly(target, GetOwningPlayer(caster)) and not IsUnitType(target, UNIT_TYPE_STRUCTURE) and not IsUnitType(target, UNIT_TYPE_ANCIENT) and not IsUnitType(target, UNIT_TYPE_MECHANICAL) and IsUnitAliveBJ(target) then
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