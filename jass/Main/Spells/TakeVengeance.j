//When Maiev dies, she becomes an illusory assassin with additional damage. 
//If she hits at least x times before it expires, she revives. Lasts y seconds.

library TakeVengeance initializer OnInit requires Table, FilteredDamageEvents

  globals
    private constant integer HERO_ID = 'Ewrd' //The hero that can use Take Vengeance

    private constant integer ABIL_ID = 'A017'
    private constant integer ALTERNATE_FORM_ID = 'espv'
    private constant integer HITS_REVIVE_THRESHOLD = 5   //Maiev needs to hit this many times to revive
    private constant real HEAL_BASE = 900.                //Maiev goes into Vengeance form with this much free health
    private constant real HEAL_LEVEL = 300.
    private constant integer DAMAGE_BASE = 20
    private constant integer DAMAGE_LEVEL = 20
    private constant real DURATION = 20.

    private constant string REVIVE_EFFECT = "Heal Blue.mdx"
  endglobals

  private struct Vengeance
    private static trigger damageTrigger
    readonly static Table vengeanceByUnit

    private unit caster
    private integer tick
    private integer originalFormId
    private integer damageBonus
    private integer hitsDone
    private real duration
    private real maxDuration
    
    private method operator DamageBonus= takes integer i returns nothing
      call BlzSetUnitBaseDamage(caster, BlzGetUnitBaseDamage(caster, 0) + i - DamageBonus, 0)
      set damageBonus = i
    endmethod

    private method operator DamageBonus takes nothing returns integer
      return damageBonus
    endmethod

    private method destroy takes nothing returns nothing
      set vengeanceByUnit[GetHandleId(caster)] = 0
      set DamageBonus = 0
      call BlzSetUnitSkin(caster, originalFormId)
      call stopPeriodic()
      set caster = null
      call deallocate()
    endmethod

    private method revive takes nothing returns nothing
      call DestroyEffect(AddSpecialEffect(REVIVE_EFFECT, GetUnitX(caster), GetUnitY(caster)))
      call destroy()
    endmethod

    method onAttack takes nothing returns nothing
      set hitsDone = hitsDone + 1
      if hitsDone >= HITS_REVIVE_THRESHOLD then
        call revive()
      endif
    endmethod

    private method periodic takes nothing returns nothing
      set tick = tick + 1
      set duration = duration - T32_PERIOD
      if duration <= 0 then
        call KillUnit(caster)
        call destroy()
      endif
    endmethod

    implement T32x

    private static method onInit takes nothing returns nothing
      set vengeanceByUnit = Table.create()
    endmethod

    static method create takes unit caster, integer damageBonus, real heal, real duration returns thistype
      local thistype this = thistype.allocate()
      call SetUnitState(caster, UNIT_STATE_LIFE, heal)
      set vengeanceByUnit[GetHandleId(caster)] = this
      set tick = 0
      set this.caster = caster
      set this.duration = duration
      set this.maxDuration = duration
      set originalFormId = BlzGetUnitSkin(caster)
      set DamageBonus = damageBonus
      set hitsDone = 0
      call BlzSetUnitSkin(caster, ALTERNATE_FORM_ID)
      call startPeriodic()
      call DestroyEffect(AddSpecialEffect(REVIVE_EFFECT, GetUnitX(caster), GetUnitY(caster)))
      return this
    endmethod
  endstruct

  //When Maiev deals damage, check if she has Vengeance and act
  private function OnInflictsDamage takes nothing returns nothing
    local Vengeance tempVengeance = Vengeance.vengeanceByUnit[GetHandleId(GetEventDamageSource())]
      if tempVengeance != 0 and BlzGetEventIsAttack() == true then
        call tempVengeance.onAttack()
      endif
  endfunction

  //Unit is damaged; check if it has this ability and it would take the damage. If so, trigger this ability
  private function OnTakesDamage takes nothing returns nothing
    local unit triggerUnit = GetTriggerUnit()
    local integer abilityLevel = 0
    if GetUnitAbilityLevel(triggerUnit, ABIL_ID) > 0 then
      set abilityLevel = GetUnitAbilityLevel(triggerUnit, ABIL_ID)
      if BlzGetUnitSkin(triggerUnit) != ALTERNATE_FORM_ID and GetEventDamage() >= GetUnitState(triggerUnit, UNIT_STATE_LIFE) and GetUnitState(triggerUnit, UNIT_STATE_MANA) >= BlzGetUnitAbilityManaCost(triggerUnit, ABIL_ID, abilityLevel) then
        call BlzSetEventDamage(0)
        call Vengeance.create(triggerUnit, DAMAGE_BASE + DAMAGE_LEVEL*abilityLevel, HEAL_BASE + HEAL_LEVEL*abilityLevel, DURATION)
      endif
    endif
    set triggerUnit = null
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterUnitTypeTakesDamageAction(HERO_ID, function OnTakesDamage)
    call RegisterUnitTypeInflictsDamageAction(HERO_ID, function OnInflictsDamage)
  endfunction

endlibrary