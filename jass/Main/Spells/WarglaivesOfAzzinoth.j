library WarglaivesOfAzzinoth initializer OnInit requires FilteredDamageEvents

  globals
    private constant integer ABIL_ID = 'A0YW'

    private constant real RADIUS = 150
    private constant real DAMAGE_BASE = 4
    private constant real DAMAGE_LEVEL = 14
    private constant real DAMAGE_MULT_DEMON = 1.2   //How much extra damage % to do versus demons

    private constant string EFFECT = "war3mapImported\\Culling Cleave.mdx"
    private constant real EFFECT_SCALE = 0.9
    private constant damagetype DAMAGE_TYPE = DAMAGE_TYPE_MAGIC
  endglobals

  private function DoGlaive takes nothing returns nothing
    local group tempGroup = CreateGroup()
    local unit u = null
    local unit caster = GetEventDamageSource()
    local integer level = GetUnitAbilityLevel(GetEventDamageSource(), ABIL_ID)
    local effect tempSfx = AddSpecialEffect(EFFECT, GetUnitX(caster), GetUnitY(caster))
    local real damage = 0
    call BlzSetSpecialEffectScale(tempSfx, EFFECT_SCALE)
    call BlzSetSpecialEffectYaw(tempSfx, GetUnitFacing(caster)*bj_DEGTORAD)
    call GroupEnumUnitsInRange(tempGroup, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()), RADIUS, null)
    loop
    exitwhen BlzGroupGetSize(tempGroup) == 0
      set u = FirstOfGroup(tempGroup)
      if not IsUnitAlly(u, GetOwningPlayer(caster)) and IsUnitAlive(u) and not BlzIsUnitInvulnerable(u) and not IsUnitType(u, UNIT_TYPE_STRUCTURE) and not IsUnitType(u, UNIT_TYPE_ANCIENT) then
        set damage = DAMAGE_BASE + DAMAGE_LEVEL*level
        if GetUnitRace(u) == RACE_DEMON then
          set damage = damage*DAMAGE_MULT_DEMON
        endif
        call UnitDamageTarget(caster, u, damage, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE, WEAPON_TYPE_WHOKNOWS)
      endif
      call GroupRemoveUnit(tempGroup, u)
    endloop
    call DestroyGroup(tempGroup)
    set tempGroup = null
    set caster = null
  endfunction

  private function Damaging takes nothing returns nothing
    local integer level = GetUnitAbilityLevel(GetEventDamageSource(), ABIL_ID)
    if level > 0 and BlzGetEventIsAttack() == true then
      call DoGlaive()
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterUnitTypeInflictsDamageAction('Eill', function Damaging)
    call RegisterUnitTypeInflictsDamageAction('Eidm', function Damaging)
    call RegisterUnitTypeInflictsDamageAction('Eevm', function Damaging)
    call RegisterUnitTypeInflictsDamageAction('Eilm', function Damaging)
    call RegisterUnitTypeInflictsDamageAction('Eevi', function Damaging)
    call RegisterUnitTypeInflictsDamageAction('E00F', function Damaging)
    call RegisterUnitTypeInflictsDamageAction('E00G', function Damaging)
    call RegisterUnitTypeInflictsDamageAction('E00E', function Damaging)
    call RegisterUnitTypeInflictsDamageAction('E00D', function Damaging)
  endfunction

endlibrary