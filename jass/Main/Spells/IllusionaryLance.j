library IllusionaryLance initializer OnInit requires FilteredDamageEvents, DummyCast

  globals
    private constant integer UNITTYPE_ID = 'U02A'
    private constant integer ABIL_ID = 'A0SF'
    private constant integer DUMMY_ABIL_ID = 'A0SI'
    private constant integer DUMMY_ORDER_ID = 852274

    private constant real ILLUSIONCHANCE_HERO = 0.1
    private constant real ILLUSIONCHANCE_ILLUSION = 0.01
  endglobals

  private function Damaging takes nothing returns nothing
    local integer level = GetUnitAbilityLevel(GetEventDamageSource(), ABIL_ID)
    local real chance
    if level > 0 and BlzGetEventIsAttack() then
      if IsUnitIllusion(GetEventDamageSource()) then
        set chance = level * ILLUSIONCHANCE_ILLUSION
      else
        set chance = level * ILLUSIONCHANCE_HERO
      endif
      if GetRandomReal(0,1) <= chance then
        call DummyCastUnitId(GetOwningPlayer(GetEventDamageSource()), DUMMY_ABIL_ID, DUMMY_ORDER_ID, 1, GetEventDamageSource())
      endif
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterUnitTypeInflictsDamageAction(UNITTYPE_ID, function Damaging)
  endfunction

endlibrary