library MassSimulacrum initializer OnInit requires Filters, FilteredCastEvents, FilteredDeathEvents

  globals
    private constant integer  ABIL_ID = 'A0DG'

    private constant real     RADIUS = 150.
    private constant integer  COUNT_BASE = 2    //How many units to copy
    private constant integer  COUNT_LEVEL = 4   
    private constant real     DURATION = 60.    //Summoned unit duration

    private constant string   EFFECT = "war3mapImported\\Soul Discharge Blue.mdx"
    private constant real     EFFECT_SCALE = 1.1
    private constant string   EFFECT_TARGET = "Abilities\\Spells\\Items\\AIil\\AIilTarget.mdl"
    private constant real     EFFECT_SCALE_TARGET = 1.0

    private constant real    HEALTH_BONUS_BASE = -0.5     //These refer to the % extra amount of that stat a Simulacrum gets
    private constant real    HEALTH_BONUS_LEVEL = 0.2     //The level ones are for each additional hero level, including level 1
    private constant real    DAMAGE_BONUS_BASE = -0.5
    private constant real    DAMAGE_BONUS_LEVEL = 0.2

    private group Simulacrums
  endglobals

  private function Cast takes nothing returns nothing
    local unit caster = null
    local integer level
    local group tempGroup
    local unit u = null
    local player triggerPlayer = null
    local effect tempEffect = null
    local unit newUnit = null
    set caster = GetTriggerUnit()
    set triggerPlayer = GetOwningPlayer(caster)
    set level = GetUnitAbilityLevel(caster, ABIL_ID) 
    set tempGroup = CreateGroup()
    call GroupEnumUnitsInRange(tempGroup, GetSpellTargetX(), GetSpellTargetY(), RADIUS, null)
    loop
    exitwhen BlzGroupGetSize(tempGroup) == 0
      set u = BlzGroupUnitAt(tempGroup, GetRandomInt( 0, BlzGroupGetSize(tempGroup) - 1) )
      if not IsUnitIllusion(u) and not IsUnitType(u, UNIT_TYPE_STRUCTURE) and not IsUnitType(u, UNIT_TYPE_ANCIENT) and not IsUnitType(u, UNIT_TYPE_MECHANICAL) and not IsUnitType(u, UNIT_TYPE_RESISTANT) and not IsUnitType(u, UNIT_TYPE_HERO) and IsUnitAlly(u, triggerPlayer) and IsUnitAliveBJ(u) then
        //Create the replicant
        set newUnit = CreateUnit(triggerPlayer, GetUnitTypeId(u), GetUnitX(u), GetUnitY(u), GetUnitFacing(u))
        call UnitAddType(newUnit, UNIT_TYPE_SUMMONED)
        call UnitApplyTimedLife(newUnit, 0, DURATION)
        call SetUnitVertexColor(newUnit, 100, 100, 230, 150)
        call ScaleUnitBaseDamage(newUnit, 1 + DAMAGE_BONUS_BASE + DAMAGE_BONUS_LEVEL*level, 0)
        call ScaleUnitMaxHP(newUnit, 1 + HEALTH_BONUS_BASE + HEALTH_BONUS_LEVEL*level)
        set tempEffect = AddSpecialEffect(EFFECT_TARGET, GetUnitX(newUnit), GetUnitY(newUnit))
        call BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE_TARGET)
        call DestroyEffect(tempEffect)
        call GroupAddUnit(Simulacrums, newUnit)
        set newUnit = null
      else
      endif
      call GroupRemoveUnit(tempGroup, u)
    endloop
    set tempEffect = AddSpecialEffect(EFFECT, GetSpellTargetX(), GetSpellTargetY())
    call BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE)
    call DestroyEffect(tempEffect)
    set caster = null  
    set tempEffect = null
    set triggerPlayer = null
    set tempGroup = null
    call DestroyGroup(tempGroup)
    set u = null
  endfunction

  private function Death takes nothing returns nothing
    local unit u = GetTriggerUnit()  
    if IsUnitInGroup(u, Simulacrums) then
      call DestroyEffect(AddSpecialEffect(EFFECT_TARGET, GetUnitX(u), GetUnitY(u)))
      call GroupRemoveUnit(Simulacrums,u)
      call RemoveUnit(u)
    endif
    set u = null
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DEATH, function Death)
    call RegisterSpellEffectAction(ABIL_ID, function Cast)

    set Simulacrums = CreateGroup()   
  endfunction

endlibrary