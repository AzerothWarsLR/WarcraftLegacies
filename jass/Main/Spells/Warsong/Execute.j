//When a Ravager reduces an enemy units hit points such that it ends up with less than 500% of the Ravager's damage, it dies instantly.
library Execute initializer OnInit requires FilteredDamageEvents, GeneralHelpers

  globals
    private constant integer UNITTYPE_ID = 'o021'
    private constant string EFFECT = "Objects\\Spawnmodels\\Human\\HumanLargeDeathExplode\\HumanLargeDeathExplode.mdl"
    private constant integer DAMAGE_MULT = 5
  endglobals

  private function OnDamage takes nothing returns nothing
    local unit triggerUnit = GetTriggerUnit()
    if BlzGetEventIsAttack() and GetUnitState(triggerUnit, UNIT_STATE_LIFE) < GetEventDamage() + GetUnitAverageDamage(GetEventDamageSource(), 0) * DAMAGE_MULT then
      call BlzSetEventDamage(GetUnitState(triggerUnit, UNIT_STATE_LIFE) + 1)
      call DestroyEffect(AddSpecialEffectTarget(EFFECT, triggerUnit, "origin"))
    endif
    set triggerUnit = null
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterUnitTypeInflictsDamageAction(UNITTYPE_ID, function OnDamage)
  endfunction

endlibrary