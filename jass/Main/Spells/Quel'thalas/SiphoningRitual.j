//Like vanilla Life Drain & Siphon Mana, but it applies to a group of units.
//Only drains if the caster needs the health and mana OR the target is an enemy.
library SiphoningRitual initializer OnInit requires T32, DummyCast, Set, SpellHelpers, FilteredCastEvents

  globals
    private constant integer ABIL_ID = 'A0FA'
    private constant integer COUNT_BASE = 7    //Target limit
    private constant real LIFEDRAIN_BASE = 10. //Per second
    private constant real LIFEDRAIN_LEVEL = 10.
    private constant real MANADRAIN_BASE = 5. //Per second
    private constant real MANADRAIN_LEVEL = 5.
    private constant real RANGE = 500.
    private constant real RADIUS = 225.
    private constant real PERIOD = 0.1
  endglobals

  //A single beam connecting the caster to the victim, draining its life.
  private struct SiphoningBeam
    private unit caster = null
    private unit target = null
    private lightning lightning = null
    private real tick = 0.
    private real lifedrain = 0.
    private real manadrain = 0.
    private effect effect

    method destroy takes nothing returns nothing
      call DestroyLightning(this.lightning)
      set this.lightning = null
      set this.caster = null
      set this.target = null
      call DestroyEffect(this.effect)
      call stopPeriodic()
    endmethod

    private method drain takes nothing returns nothing
      if GetUnitState(caster, UNIT_STATE_LIFE) < GetUnitState(caster, UNIT_STATE_MAX_LIFE) or not IsUnitAlly(target, GetOwningPlayer(caster)) then
        call UnitDamageTarget(caster, target, lifedrain * PERIOD, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS)
        call UnitHeal(caster, caster, RMinBJ(lifedrain * PERIOD, GetUnitState(target, UNIT_STATE_LIFE)))
      endif
      if GetUnitState(caster, UNIT_STATE_MANA) < GetUnitState(caster, UNIT_STATE_MAX_MANA) or not IsUnitAlly(target, GetOwningPlayer(caster)) then
        call UnitRestoreMana(caster, caster, RMinBJ(manadrain * PERIOD, GetUnitState(target, UNIT_STATE_MANA)))
        call UnitReduceMana(caster, target, manadrain * PERIOD)
      endif
    endmethod

    private method periodic takes nothing returns nothing
      set tick = tick + 1
      if tick >= PERIOD * T32_FPS then
        call this.drain()
        call MoveLightning(this.lightning, true, GetUnitX(this.caster), GetUnitY(this.caster), GetUnitX(this.target), GetUnitY(this.target))
        if GetDistanceBetweenPoints(GetUnitX(this.caster), GetUnitY(this.caster), GetUnitX(this.target), GetUnitY(this.target)) > RANGE + RADIUS / 2 or not UnitAlive(target) or IsUnitType(target, UNIT_TYPE_MAGIC_IMMUNE) then
          call this.destroy()
        endif
        set tick = tick - PERIOD * T32_FPS
      endif
    endmethod

    implement T32x

    static method create takes unit caster, unit target, real lifedrain, real manadrain returns thistype
      local thistype this = thistype.allocate()
      set this.caster = caster
      set this.target = target
      set this.lifedrain = lifedrain
      set this.manadrain = manadrain
      set this.lightning = AddLightning("DRAB", true, GetUnitX(this.caster), GetUnitY(this.caster), GetUnitX(this.target), GetUnitY(this.target))
      set this.effect = AddSpecialEffectTarget("Abilities\\Spells\\Other\\Drain\\DrainTarget.mdl", this.target, "chest")
      call startPeriodic()
      return this
    endmethod
  endstruct

  //A group of SiphoningBeams.
  private struct SiphoningRitual
    public static thistype array ByUnit
    private Set siphoningBeams = 0
    private unit caster = null
    private real tick = 0
    private effect effect = null

    method destroy takes nothing returns nothing
      local integer i = 0
      set caster = null
      loop
        exitwhen i == siphoningBeams.size
        call SiphoningBeam(siphoningBeams[i]).destroy()
        set i = i + 1
      endloop
      call DestroyEffect(this.effect)
      call siphoningBeams.destroy()
      call stopPeriodic()
      call deallocate()
    endmethod

    private method periodic takes nothing returns nothing
      set tick = tick + 1
      if tick >= PERIOD * T32_FPS then
        set tick = tick - PERIOD * T32_FPS
      endif
    endmethod

    implement T32x

    static method create takes unit caster, real x, real y, real radius, real lifedrain, real manadrain returns thistype
      local thistype this = thistype.allocate()
      local group tempGroup = CreateGroup()
      local integer i = 0
      local unit u = null
      set this.caster = caster
      set this.tick = 0
      set this.siphoningBeams = Set.create("siphoning Beams")
      set this.effect = AddSpecialEffectTarget("Abilities\\Spells\\Other\\Drain\\DrainCaster.mdl", this.caster, "chest")

      call GroupEnumUnitsInRange(tempGroup, x, y, radius, null)
      loop
      exitwhen BlzGroupGetSize(tempGroup) == 0 or i == COUNT_BASE
        set u = BlzGroupUnitAt(tempGroup, GetRandomInt( 0, BlzGroupGetSize(tempGroup) - 1) )
        if caster != u and not IsUnitType(u, UNIT_TYPE_STRUCTURE) and not IsUnitType(u, UNIT_TYPE_ANCIENT) and not IsUnitType(u, UNIT_TYPE_MECHANICAL) and IsUnitAliveBJ(u) then
          call this.siphoningBeams.add(SiphoningBeam.create(this.caster, u, lifedrain, manadrain))
          set i = i + 1
        else
        endif
        call GroupRemoveUnit(tempGroup, u)
      endloop

      call DestroyGroup(tempGroup)
      set tempGroup = null
      call startPeriodic()
      return this
    endmethod
  endstruct

  private function StopChannel takes nothing returns nothing
    call SiphoningRitual.ByUnit[GetUnitId(GetTriggerUnit())].destroy()
  endfunction

  private function StartChannel takes nothing returns nothing
    local unit u = GetTriggerUnit()      
    set SiphoningRitual.ByUnit[GetUnitId(u)] = SiphoningRitual.create(u, GetSpellTargetX(), GetSpellTargetY(), RADIUS, LIFEDRAIN_BASE+GetUnitAbilityLevel(u, ABIL_ID)*LIFEDRAIN_LEVEL, MANADRAIN_BASE+GetUnitAbilityLevel(u, ABIL_ID)*MANADRAIN_LEVEL)
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterSpellChannelAction(ABIL_ID, function StartChannel)
    call RegisterSpellEndcastAction(ABIL_ID, function StopChannel)
  endfunction 

endlibrary