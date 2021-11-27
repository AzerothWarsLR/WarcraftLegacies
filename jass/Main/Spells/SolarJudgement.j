library SolarJudgement initializer OnInit requires T32, Filters

  globals
    private constant integer ABIL_ID = 'A01F'

    private constant real DAMAGE_BASE = 20.
    private constant real DAMAGE_LEVEL = 20.
    private constant real DURATION = 14.
    private constant real PERIOD = 0.25

    private constant real HEAL_MULT = 1.5
    private constant real EVIL_MULT = 1.1

    private constant real RADIUS = 250.
    private constant real BOLT_RADIUS = 125.

    private constant string EFFECT = "Shining Flare.mdx"
    private constant string EFFECT_HEAL = "Abilities\\Spells\\Human\\Heal\\HealTarget.mdl"

    private group TempGroup = CreateGroup()
  endglobals

  struct SolarJudgement
    private unit caster
    private real x
    private real y
    private real damage
    private real tick = 0
    private real duration

    private method destroy takes nothing returns nothing
      call stopPeriodic()
      set caster = null
      call deallocate()
    endmethod

    private method bolt takes real x, real y returns nothing
      local real damageMult = 1.
      local unit u

      call DestroyEffect(AddSpecialEffect(EFFECT, x, y))

      set P = GetOwningPlayer(caster)  
      //Damage enemies
      call GroupEnumUnitsInRange(TempGroup,x,y,BOLT_RADIUS,Condition(function EnemyAliveFilter))
      loop
        set u = FirstOfGroup(TempGroup)
        exitwhen u == null
        if IsUnitType(u, UNIT_TYPE_UNDEAD) == true then
          set damageMult = EVIL_MULT
        else
          set damageMult = 1.
        endif
        call UnitDamageTarget(caster, u, damage*damageMult, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS)
        call GroupRemoveUnit(TempGroup,u)
      endloop

      //Heal allies
      call GroupEnumUnitsInRange(TempGroup,x,y,BOLT_RADIUS,Condition(function AllyAliveFilter))
      loop
        set u = FirstOfGroup(TempGroup)
        exitwhen u == null
        if IsUnitType(u, UNIT_TYPE_UNDEAD) == false then
          set damageMult = HEAL_MULT
          call SetUnitState(u, UNIT_STATE_LIFE, GetUnitState(u, UNIT_STATE_LIFE) + damage * damageMult)
          call DestroyEffect(AddSpecialEffectTarget(EFFECT_HEAL, u, "origin"))
        endif
        call GroupRemoveUnit(TempGroup,u)
      endloop      

      call GroupClear(TempGroup)
      set P = null
      set u = null
    endmethod

    private method randomBolt takes nothing returns nothing
      local real randomAngle = GetRandomReal(0, 2*bj_PI)
      local real randomRadius = GetRandomReal(0, RADIUS)
      call bolt(x + randomRadius * Cos(randomAngle), y + randomRadius * Sin(randomAngle))
    endmethod

    private method periodic takes nothing returns nothing
      set tick = tick + 1
      set duration = duration - 1./T32_FPS
      if tick >= PERIOD * T32_FPS then
        call randomBolt()
        set tick = tick - PERIOD * T32_FPS
      endif
      if duration <= 0 then
        call destroy()
      endif
    endmethod

    implement T32x

    static method create takes unit caster, real x, real y, real damage, real duration returns thistype
      local thistype this = thistype.allocate()
      set this.duration = duration
      set this.caster = caster
      set this.duration = duration
      set this.damage = damage
      set this.x = x
      set this.y = y
      set this.tick = 0
      call startPeriodic()
      return this
    endmethod
  endstruct

  private function Cast takes nothing returns nothing
    call SolarJudgement.create(GetTriggerUnit(), GetSpellTargetX(), GetSpellTargetY(), DAMAGE_BASE + DAMAGE_LEVEL*GetUnitAbilityLevel(GetTriggerUnit(), ABIL_ID), DURATION)
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterSpellEffectAction(ABIL_ID, function Cast)
  endfunction

endlibrary