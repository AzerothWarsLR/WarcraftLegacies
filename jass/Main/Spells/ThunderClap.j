library ThunderClap initializer OnInit requires DummyCast, Filters

  globals
    private constant integer ABIL_ID        = 'A0QC'
    private constant integer DUMMY_ID       = 'S00H'        //The ability that gets cast on each unit in the radius
    private constant string  DUMMY_ORDER    = "cripple"
    private constant real    DAMAGE_BASE    = 65
    private constant real    RADIUS         = 225.00
    private constant string  EFFECT         = "Abilities\\Spells\\Human\\Thunderclap\\ThunderClapCaster.mdl"
    private group     TempGroup = CreateGroup()
  endglobals
 
  private function Cast takes nothing returns nothing
    local unit u
    local unit caster
    local integer level        
    set caster = GetTriggerUnit()
    set level = GetUnitAbilityLevel(caster, ABIL_ID)             
    set P = GetOwningPlayer(caster)
    call GroupEnumUnitsInRange(TempGroup,GetUnitX(caster),GetUnitY(caster),RADIUS,Condition(function EnemyAliveFilter))
    loop
      set u = FirstOfGroup(TempGroup)
      exitwhen u == null
      call UnitDamageTarget(caster, u, DAMAGE_BASE, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS)
      call DummyCastUnit(GetOwningPlayer(caster), DUMMY_ID, DUMMY_ORDER, 1, u)
      call GroupRemoveUnit(TempGroup,u)
    endloop
    call DestroyEffect(AddSpecialEffect(EFFECT,GetUnitX(caster),GetUnitY(caster)))
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterSpellEffectAction(ABIL_ID, function Cast)
  endfunction 
    
endlibrary
