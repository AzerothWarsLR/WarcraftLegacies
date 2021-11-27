library StormEarthAndFire initializer OnInit requires Filters

  globals
    private constant integer  ABIL_ID = 'A0HM'

    private constant integer  UNIT_TYPE_1 = 'npn4'
    private constant integer  UNIT_TYPE_2 = 'npn5'
    private constant integer  UNIT_TYPE_3 = 'npn6'
    private constant real     DURATION = 60.    //Summoned unit duration

    private constant string   EFFECT = "war3mapImported\\Soul Discharge Blue.mdx"
    private constant real     EFFECT_SCALE = 1.1
    private constant string   EFFECT_TARGET = "Abilities\\Spells\\Items\\AIil\\AIilTarget.mdl"
    private constant real     EFFECT_SCALE_TARGET = 1.0

    private constant real    HEALTH_BONUS_BASE = -0.15     //These refer to the % extra amount of that stat a Simulacrum gets
    private constant real    HEALTH_BONUS_LEVEL = 0.15     //The level ones are for each additional hero level, including level 1
    private constant real    DAMAGE_BONUS_BASE = -0.15
    private constant real    DAMAGE_BONUS_LEVEL = 0.15
  endglobals

  private function SummonPanda takes player whichPlayer, integer unitType, real x, real y, real facing, real damageBonus, real hitpointBonus, real duration returns unit
    local unit newUnit = CreateUnit(whichPlayer, unitType, x, y, facing)
    local effect tempEffect
    call UnitAddType(newUnit, UNIT_TYPE_SUMMONED)
    call UnitApplyTimedLife(newUnit, 0, DURATION)
    call ScaleUnitBaseDamage(newUnit, 1 + damageBonus, 0)
    call ScaleUnitMaxHP(newUnit, 1 + hitpointBonus)
    set tempEffect = AddSpecialEffect(EFFECT_TARGET, GetUnitX(newUnit), GetUnitY(newUnit))
    call BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE_TARGET)
    call DestroyEffect(tempEffect)
    return newUnit
  endfunction

  private function Cast takes nothing returns nothing
    local unit caster = null
    local integer level
    local group tempGroup
    local unit u = null
    local player triggerPlayer = null
    local effect tempEffect = null
    local unit newUnit = null
    local real x
    local real y
    set caster = GetTriggerUnit()
    set triggerPlayer = GetOwningPlayer(caster)
    set level = GetUnitAbilityLevel(caster, ABIL_ID) 
    set x = GetPolarOffsetX(GetUnitX(caster), 150, GetUnitFacing(caster))
    set y = GetPolarOffsetY(GetUnitY(caster), 150, GetUnitFacing(caster))
    //Create the replicant
    call SummonPanda(triggerPlayer, UNIT_TYPE_1, x, y, GetUnitFacing(caster), DAMAGE_BONUS_BASE + DAMAGE_BONUS_LEVEL*level, HEALTH_BONUS_BASE + HEALTH_BONUS_LEVEL*level, DURATION)
    call SummonPanda(triggerPlayer, UNIT_TYPE_2, x, y, GetUnitFacing(caster), DAMAGE_BONUS_BASE + DAMAGE_BONUS_LEVEL*level, HEALTH_BONUS_BASE + HEALTH_BONUS_LEVEL*level, DURATION)
    call SummonPanda(triggerPlayer, UNIT_TYPE_3, x, y, GetUnitFacing(caster), DAMAGE_BONUS_BASE + DAMAGE_BONUS_LEVEL*level, HEALTH_BONUS_BASE + HEALTH_BONUS_LEVEL*level, DURATION)
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterSpellEffectAction(ABIL_ID, function Cast)
  endfunction

endlibrary