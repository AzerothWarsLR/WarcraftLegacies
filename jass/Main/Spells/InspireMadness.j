library InspireMadness initializer OnInit requires Filters

  globals
    private constant integer ABIL_ID = 'A10M'

    private constant real RADIUS = 400.
    private constant integer COUNT_BASE = 2    //How many units to charm
    private constant integer COUNT_LEVEL = 4   
    private constant real DURATION = 16.    //The units kill themselves after this duration

    private constant string EFFECT = "war3mapImported\\Call of Dread Purple.mdx"
    private constant real EFFECT_SCALE = 1.1
    private constant string EFFECT_TARGET = "Abilities\\Spells\\Other\\Charm\\CharmTarget.mdl"
    private constant real EFFECT_SCALE_TARGET = 0.5
  endglobals

  private function Cast takes nothing returns nothing
    local unit caster = null
    local integer level
    local group tempGroup
    local integer i = 0 //Tracks number of units charmed
    local unit u = null
    local player triggerPlayer = null
    local effect tempEffect = null
    set caster = GetTriggerUnit()
    set triggerPlayer = GetOwningPlayer(caster)
    set level = GetUnitAbilityLevel(caster, ABIL_ID) 
    set tempGroup = CreateGroup()
    call GroupEnumUnitsInRange(tempGroup, GetSpellTargetX(), GetSpellTargetY(), RADIUS, null)
    loop
    exitwhen BlzGroupGetSize(tempGroup) == 0 or i == COUNT_BASE+COUNT_LEVEL*level
      set u = BlzGroupUnitAt(tempGroup, GetRandomInt( 0, BlzGroupGetSize(tempGroup) - 1) )
      if not IsUnitType(u, UNIT_TYPE_STRUCTURE) and not IsUnitType(u, UNIT_TYPE_ANCIENT) and not IsUnitType(u, UNIT_TYPE_MECHANICAL) and not IsUnitType(u, UNIT_TYPE_RESISTANT) and not IsUnitType(u, UNIT_TYPE_HERO) and not IsUnitAlly(u, triggerPlayer) and IsUnitAliveBJ(u) then
        call SetUnitOwner(u, triggerPlayer, true)
        call UnitApplyTimedLife(u, 'Bpos', DURATION)
        call SetUnitExploded(u, true)
        set tempEffect = AddSpecialEffect(EFFECT_TARGET, GetUnitX(u), GetUnitY(u))
        call BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE_TARGET)
        call DestroyEffect(tempEffect)
        set i = i + 1
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

  private function OnInit takes nothing returns nothing
    call RegisterSpellEffectAction(ABIL_ID, function Cast)
  endfunction

endlibrary