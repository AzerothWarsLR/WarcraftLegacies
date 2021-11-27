library DivineJustice initializer OnInit requires Filters, FilteredCastEvents

  globals
    private constant integer    ABIL_ID                        = 'A097'
    private constant real       DURATION                       = 8.

    private constant string     CONSECRATION_EFFECT_SPARKLE    = "war3mapImported\\Consecrate.mdx"
    private constant string     CONSECRATION_EFFECT_RING       = "war3mapImported\\Point Target.mdx"
    private constant real       CONSECRATION_DAMAGE_BASE       = 200.
    private constant real       CONSECRATION_DAMAGE_LEVEL      = 250.
    private constant real       CONSECRATION_RADIUS            = 400.
    private constant real       CONSECRATION_SCALE             = 2.3
    private constant real       CONSECRATION_SCALE_RING        = 5.5
    private constant real       CONSECRATION_ALPHA_FADE        = 0.5
    private constant real       CONSECRATION_ALPHA_RING        = 255
    
    private constant string     EXPLODE_EFFECT                 = "war3mapImported\\Divine Edict.mdx"
    private constant real       EXPLODE_SCALE                  = 2.
    
    private constant string     PROGRESS_EFFECT                = "war3mapImported\\Progressbar.mdx"
    private constant real       PROGRESS_SCALE                 = 1.5
    private constant real       PROGRESS_HEIGHT                = 225.

    private keyword Consecration
    private Consecration array ConsecrationsByUnit      //For attaching to channeler unit
    private group UnitsWithConsecration = CreateGroup()
    private unit TempUnit = null
    private group TempGroup = CreateGroup()
  endglobals

  private struct Consecration
    unit       cas = null
    real       tick = 0.
    real       duration = 0.
    real       fullDuration = 0.
    
    effect     sfxSparkle = null
    effect     sfxRing = null
    effect     sfxProgress = null
    
    real       sfxRingAlpha    = 0
    real       sfxSparkleAlpha = 255
    
    real       x  = 0.
    real       y  = 0.
    real       z  = 0.
    real       radius = 0.
    real       damage = 0.
    real       fullDamage = 0.
    
    private boolean    ended = false
    
    private method destroy takes nothing returns nothing
      call BlzSetSpecialEffectTimeScale(this.sfxRing,1)   
      call BlzSetSpecialEffectPosition(this.sfxSparkle, -100000, -100000, 0)    //Has no death animation so needs to be moved off the map
      call BlzSetSpecialEffectPosition(this.sfxProgress, -100000, -100000, 0)    //Has no death animation so needs to be moved off the map
      call DestroyEffect(this.sfxSparkle)
      call DestroyEffect(this.sfxRing)
      call DestroyEffect(this.sfxProgress)

      call GroupRemoveUnit(UnitsWithConsecration, this.cas)
      call SetUnitInvulnerable(this.cas, false)

      set this.cas = null
      set this.sfxSparkle = null
      set this.sfxRing = null
      set this.sfxProgress = null
      
      call this.stopPeriodic()
      call this.deallocate()
    endmethod
    
    method end takes nothing returns nothing
      set this.ended = true
    endmethod

    method protect takes unit u returns nothing
      if GetDistanceBetweenPoints(this.x, this.y, GetUnitX(u), GetUnitY(u)) <= this.radius and IsUnitAlly(u, GetOwningPlayer(this.cas)) then
        call BlzSetEventDamage(0)
      endif
    endmethod

    private method explode takes nothing returns nothing
      local effect explodeEffect = AddSpecialEffect(EXPLODE_EFFECT, this.x, this.y)
      local unit u = null
      call BlzSetSpecialEffectScale(explodeEffect, EXPLODE_SCALE)
      call DestroyEffect(explodeEffect)

      set P = GetOwningPlayer(this.cas)  
      call GroupEnumUnitsInRange(TempGroup,this.x,this.y,this.radius,Condition(function EnemyAliveFilter))
      loop
        set u = FirstOfGroup(TempGroup)
        exitwhen u == null
        call UnitDamageTarget(this.cas, u, this.damage, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_NORMAL, WEAPON_TYPE_WHOKNOWS)
        call GroupRemoveUnit(TempGroup,u)
      endloop      
    endmethod

    private method periodic takes nothing returns nothing    
      set this.tick = this.tick+1
      set this.duration = this.duration - 1./T32_FPS
      
      if this.ended == true and this.duration > 0 then
        set this.duration = 0
      endif

      if this.duration >= 0 then  
        //Scale up the damage
        if this.damage < this.fullDamage then
          set this.damage = this.damage + this.fullDamage/(this.fullDuration*T32_FPS)
        endif
        //Fade in the ring
        if this.sfxRingAlpha < CONSECRATION_ALPHA_RING then
          set this.sfxRingAlpha = this.sfxRingAlpha + (CONSECRATION_ALPHA_RING / (CONSECRATION_ALPHA_FADE*T32_FPS))
          call BlzSetSpecialEffectAlpha(this.sfxRing, R2I(this.sfxRingAlpha))
        endif
      endif
          
      if this.duration == 0 then
        call this.explode()
        call this.destroy()
      endif
    endmethod
    
    implement T32x
    
    static method create takes unit cast, real x, real y, real damage, real radius, real duration returns thistype
      local thistype this = thistype.allocate()
      local integer i = 0
      local boolean b = false
      
      set this.cas = cast

      set this.x  = x
      set this.y  = y
      set this.z  = 20.00 + GetPositionZ(x,y)  
      set this.fullDamage = damage            
      set this.radius = radius
      set this.fullDuration = duration
      set this.duration = duration

      set this.sfxSparkle = AddSpecialEffect(CONSECRATION_EFFECT_SPARKLE,x,y)
      call BlzSetSpecialEffectScale(this.sfxSparkle,CONSECRATION_SCALE)
      call BlzSetSpecialEffectColor(this.sfxSparkle, 255, 255, 0) 
      
      set this.sfxRing = AddSpecialEffect(CONSECRATION_EFFECT_RING,x,y)
      call BlzSetSpecialEffectTimeScale(this.sfxRing, 0)
      call BlzSetSpecialEffectColor(this.sfxRing, 235, 235, 50)
      call BlzSetSpecialEffectAlpha(this.sfxRing, 0)
      call BlzSetSpecialEffectScale(this.sfxRing,CONSECRATION_SCALE_RING)
      
      set this.sfxProgress = AddSpecialEffect(PROGRESS_EFFECT,x,y)
      call BlzSetSpecialEffectTimeScale(this.sfxProgress, 1./DURATION)
      call BlzSetSpecialEffectColorByPlayer(this.sfxProgress, Player(4))
      call BlzSetSpecialEffectScale(sfxProgress,PROGRESS_SCALE)
      call BlzSetSpecialEffectHeight(sfxProgress, PROGRESS_HEIGHT)
      
      call GroupAddUnit(UnitsWithConsecration, cast)
      call SetUnitInvulnerable(this.cas, true)
      
      call this.startPeriodic()
      
      return this
    endmethod
  endstruct

  private function OnDamageB takes nothing returns nothing
    call ConsecrationsByUnit[GetUnitId(GetEnumUnit())].protect(TempUnit)
  endfunction

  private function OnDamage takes nothing returns nothing
    set TempUnit = GetTriggerUnit()     //This gets used in the .protect() method of Consecration
    if BlzGroupGetSize(UnitsWithConsecration) > 0 then
      call ForGroup(UnitsWithConsecration, function OnDamageB)
    endif
    set TempUnit = null
  endfunction

  private function StopChannel takes nothing returns nothing
    call ConsecrationsByUnit[GetUnitId(GetTriggerUnit())].end()
  endfunction

  private function StartChannel takes nothing returns nothing
    local unit u = GetTriggerUnit()
    local integer i = 0
    local boolean b = false
    
    set ConsecrationsByUnit[GetUnitId(u)] = Consecration.create(u, GetUnitX(u), GetUnitY(u), CONSECRATION_DAMAGE_BASE+GetUnitAbilityLevel(u, ABIL_ID)*CONSECRATION_DAMAGE_LEVEL, CONSECRATION_RADIUS, DURATION)
  endfunction
  
  private function OnInit takes nothing returns nothing  
    call RegisterSpellChannelAction(ABIL_ID, function StartChannel)
    call RegisterSpellEndcastAction(ABIL_ID, function StopChannel)  
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DAMAGED, function OnDamage)
  endfunction 
  
endlibrary