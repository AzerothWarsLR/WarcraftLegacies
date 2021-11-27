library BlackEmpireObelisk initializer OnInit requires ControlPoint

  globals
    private constant integer ABIL_ID = 'A06Z'
    private constant real DURATION = 10.
    private constant integer OBELISK_ID = 'n0BA'
    private constant string PROGRESS_EFFECT = "war3mapImported\\Progressbar.mdx"
    private constant real PROGRESS_SCALE = 1.5
    private constant real PROGRESS_HEIGHT = 225.

    Event BlackEmpireObeliskSummoned
  endglobals

  private struct BlackEmpireObelisk
    private static thistype array byCaster
    private unit caster
    private real tick = 0.
    private real maxDuration = 0.
    private real elapsedDuration = 0.
    private ControlPoint controlPoint
    private unit obeliskUnit
    private effect sfxProgress = null
    static thistype triggerObelisk

    private method destroy takes nothing returns nothing
      call BlzSetSpecialEffectPosition(this.sfxProgress, -100000, -100000, 0)    //Has no death animation so needs to be moved off the map
      call DestroyEffect(this.sfxProgress)
      set this.obeliskUnit = null
      set this.sfxProgress = null
      call this.stopPeriodic()
      call this.deallocate()
    endmethod

    public method operator ControlPoint takes nothing returns ControlPoint
      return this.controlPoint
    endmethod

    private method End takes boolean finished returns nothing
      if this.elapsedDuration >= this.maxDuration then
        set thistype.triggerObelisk = this
        call BlackEmpireObeliskSummoned.fire()
      else
        call RemoveUnit(this.obeliskUnit)
      endif
      call this.destroy()
    endmethod

    public static method OnAnyStopChannel takes nothing returns nothing
      call thistype.byCaster[GetUnitId(GetTriggerUnit())].End(false)
    endmethod

    public static method OnAnyStartChannel takes nothing returns nothing
      local unit caster = GetTriggerUnit()
      local ControlPoint controlPoint = ControlPoint.ByHandle(GetSpellTargetUnit())
      if controlPoint != 0 and controlPoint == BlackEmpirePortal.Objective.NearbyControlPoint then
        set thistype.byCaster[GetUnitId(caster)] = thistype.create(caster, controlPoint, DURATION)
        call SetUnitInvulnerable(caster, false)
        call SetUnitOwner(GetSpellTargetUnit(), GetOwningPlayer(caster), true)
      else
        call IssueImmediateOrder(caster, "stop")
      endif
    endmethod

    private method periodic takes nothing returns nothing    
      set this.tick = this.tick+1
      set this.elapsedDuration = this.elapsedDuration + 1./T32_FPS
    endmethod

    implement T32x

    static method create takes unit caster, ControlPoint controlPoint, real duration returns thistype
      local thistype this = thistype.allocate()
      set this.caster = caster
      set this.controlPoint = controlPoint
      set this.elapsedDuration = 0
      set this.maxDuration = duration
      set this.obeliskUnit = CreateUnit(GetOwningPlayer(caster), OBELISK_ID, GetUnitX(controlPoint.Unit), GetUnitY(controlPoint.Unit), 270)

      set this.sfxProgress = AddSpecialEffect(PROGRESS_EFFECT, GetUnitX(controlPoint.Unit), GetUnitY(controlPoint.Unit))
      call BlzSetSpecialEffectTimeScale(this.sfxProgress, 1./duration)
      call BlzSetSpecialEffectColorByPlayer(this.sfxProgress, GetOwningPlayer(caster))
      call BlzSetSpecialEffectScale(sfxProgress, PROGRESS_SCALE)
      call BlzSetSpecialEffectHeight(sfxProgress, PROGRESS_HEIGHT)

      call this.startPeriodic()      
      return this
    endmethod
  endstruct

  function GetTriggerBlackEmpireObelisk takes nothing returns BlackEmpireObelisk
    return BlackEmpireObelisk.triggerObelisk
  endfunction

  private function OnInit takes nothing returns nothing  
    call RegisterSpellChannelAction(ABIL_ID, function BlackEmpireObelisk.OnAnyStartChannel)
    call RegisterSpellEndcastAction(ABIL_ID, function BlackEmpireObelisk.OnAnyStopChannel)  
    set BlackEmpireObeliskSummoned = Event.create()
  endfunction 

endlibrary