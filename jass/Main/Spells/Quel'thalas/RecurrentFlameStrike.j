//Casts Flame Strike at itself every few seconds.
library RecurrentFlameStrike initializer OnInit requires T32, DummyCast, FilteredCastEvents

  globals
    private constant integer ABIL_ID = 'A04H'
    private constant integer DUMMY_SPELL_ID = 'A0F9'
    private constant string DUMMY_SPELL_ORDER = "flamestrike"
    private constant real DURATION = 14.
    private constant real PERIOD = 7.
  endglobals

  private struct RecurrentFlameStrike
    private unit caster = null
    private real x = 0.
    private real y = 0.
    private real tick = 0
    private real duration = 0.
    private integer level = 0

    private method destroy takes nothing returns nothing
      call stopPeriodic()
      set caster = null
      call deallocate()
    endmethod

    private method Cast takes nothing returns nothing
      call DummyCastPoint(GetOwningPlayer(this.caster), DUMMY_SPELL_ID, DUMMY_SPELL_ORDER, this.level, this.x, this.y)
    endmethod

    private method periodic takes nothing returns nothing
      set tick = tick + 1
      set duration = duration - 1. / T32_FPS
      if tick >= PERIOD * T32_FPS then
        call Cast()
        set tick = tick - PERIOD * T32_FPS
      endif
      if duration <= 0 then
        call destroy()
      endif
    endmethod

    implement T32x

    static method create takes unit caster, real x, real y, integer level returns thistype
      local thistype this = thistype.allocate()
      set this.caster = caster
      set this.duration = DURATION
      set this.x = x
      set this.y = y
      set this.level = level
      set this.tick = 0
      call startPeriodic()
      call Cast()
      return this
    endmethod
  endstruct

  private function Cast takes nothing returns nothing
    call RecurrentFlameStrike.create(GetTriggerUnit(), GetSpellTargetX(), GetSpellTargetY(), GetUnitAbilityLevel(GetTriggerUnit(), ABIL_ID))
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterSpellEffectAction(ABIL_ID, function Cast)
  endfunction

endlibrary