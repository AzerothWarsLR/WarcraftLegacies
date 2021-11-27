library ReapingHour initializer OnInit requires T32, Set

  globals
    private constant integer ABIL_ID = 'A10N'

    private constant real RANGE = 1500.
    private constant real VELOCITY = 250.
    private constant real RADIUS = 50. //Radius of each Horsemen's damage
    private constant integer HORSEMEN_COUNT = 7 //Must be an odd number
    private constant real HORSEMEN_WIDTH = 700. //The total width of the spell
    private constant real DIST_FADE_START = 400.  //When the spell has this many units left to travel, the special effect begins to fade out

    private constant real DAMAGE_BASE = 50.
    private constant real DAMAGE_LEVEL = 50.
    private constant real EXECUTE_PERC = 1 //% of extra damage per % of lost life

    private constant string EFFECT_PROJ = "units\\undead\\HeroDeathKnight\\HeroDeathKnight.mdl"
    private constant real EFFECT_SCALE_PROJ = 0.7
    private constant string EFFECT_HIT = "Objects\\Spawnmodels\\Undead\\UndeadDissipate\\UndeadDissipate.mdl"
    private constant real EFFECT_SCALE_HIT = 0.7
    private constant string EFFECT_SPAWN = "Abilities\\Spells\\Undead\\AnimateDead\\AnimateDeadTarget.mdl"
    private constant real EFFECT_SCALE_SPAWN = 0.5

    private group TempGroup = CreateGroup()
  endglobals

  private struct ReapProjectile
    private effect sfx = null
    private real x = 0
    private real y = 0
    private real face = 0

    method destroy takes nothing returns nothing
      call DestroyEffect(this.sfx)
      set this.sfx = null
      call this.deallocate()
    endmethod

    method operator X= takes real r returns nothing
      set x = r
      call BlzSetSpecialEffectX(sfx, r)
      call BlzSetSpecialEffectZ(sfx, GetPositionZ(x, y))
    endmethod

    method operator X takes nothing returns real
      return x
    endmethod

    method operator Y= takes real r returns nothing
      set y = r
      call BlzSetSpecialEffectY(sfx, r)
      call BlzSetSpecialEffectZ(sfx, GetPositionZ(x, y))
    endmethod

    method operator Y takes nothing returns real
      return y
    endmethod

    method operator Face= takes real r returns nothing
      set face = r
      call BlzSetSpecialEffectYaw(sfx, r*bj_DEGTORAD)
    endmethod

    method operator Face takes nothing returns real
      return face
    endmethod

    method operator Alpha= takes integer i returns nothing
      call BlzSetSpecialEffectAlpha(sfx, i)
    endmethod

    static method create takes real x, real y, real face returns thistype
      local thistype this = thistype.allocate()
      local effect tempSfx = AddSpecialEffect(EFFECT_SPAWN, x, y)
      call DestroyEffect(tempSfx)
      call BlzSetSpecialEffectScale(tempSfx, EFFECT_SCALE_SPAWN)

      set this.sfx = AddSpecialEffect(EFFECT_PROJ, x, y)
      set X = x
      set Y = y
      set Face = face
      call BlzPlaySpecialEffect(this.sfx, ANIM_TYPE_WALK)
      call BlzSetSpecialEffectScale(this.sfx, EFFECT_SCALE_PROJ)

      return this
    endmethod
  endstruct

  //Responsible for handling the movement, damage and expiry of its child ReapProjectiles
  private struct ReapingHour
    private Set reapProjectiles
    private unit caster = null
    private real curDist = 0
    private real maxDist = 0
    private real damage = 0
    private group hitGroup = null   //Units already hit by this ReapingHour

    method destroy takes nothing returns nothing
      local integer i = 0
      local ReapProjectile reapProjectile
      call DestroyGroup(hitGroup)
      set hitGroup = null
      loop
        exitwhen i == reapProjectiles.size
        set reapProjectile = reapProjectiles[i]
        call reapProjectile.destroy()
        set i = i + 1
      endloop
      call reapProjectiles.destroy()
      call this.stopPeriodic()
      call this.deallocate()
    endmethod

    method hit takes ReapProjectile reapProjectile returns nothing
      local integer i = 0
      local unit u = null
      local effect tempEffect = null
      local real damageMult = 0
      call GroupEnumUnitsInRange(TempGroup, reapProjectile.X, reapProjectile.Y, RADIUS, null)
      loop
        set u = FirstOfGroup(TempGroup)
        exitwhen u == null
        if not IsUnitInGroup(u, this.hitGroup) and not IsUnitAlly(u, GetOwningPlayer(this.caster)) and IsUnitAlive(u) and not BlzIsUnitInvulnerable(u) and not IsUnitType(u, UNIT_TYPE_STRUCTURE) and not IsUnitType(u, UNIT_TYPE_ANCIENT) then
          set damageMult = 1 + ((GetUnitState(u, UNIT_STATE_MAX_LIFE) - GetUnitState(u, UNIT_STATE_LIFE))/GetUnitState(u, UNIT_STATE_MAX_LIFE))*EXECUTE_PERC
          call UnitDamageTarget(this.caster, u, this.damage*damageMult, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS)
          set tempEffect = AddSpecialEffect(EFFECT_HIT, GetUnitX(u), GetUnitY(u))
          call BlzSetSpecialEffectScale(tempEffect, EFFECT_SCALE_HIT)
          call DestroyEffect(tempEffect)
          set tempEffect = null
          call GroupAddUnit(this.hitGroup, u)
        endif
        call GroupRemoveUnit(TempGroup, u)
      endloop
      call GroupClear(TempGroup)
    endmethod

    method periodic takes nothing returns nothing
      local integer i = 0
      local ReapProjectile reapProjectile
      loop
        exitwhen i == reapProjectiles.size
        set reapProjectile = reapProjectiles[i]
        set reapProjectile.X = GetPolarOffsetX(reapProjectile.X, VELOCITY/T32_FPS, reapProjectile.Face)
        set reapProjectile.Y = GetPolarOffsetY(reapProjectile.Y, VELOCITY/T32_FPS, reapProjectile.Face)
        call hit(reapProjectile)
        //Begin fadeout near the end of the path
        if this.curDist > (this.maxDist - DIST_FADE_START) then
          set reapProjectile.Alpha = R2I(255*( 1 - ( ( this.curDist / this.maxDist ) ) ) )
        endif
        set i = i + 1
      endloop

      //Ended path
      if this.curDist >= this.maxDist then
        call this.destroy()
      endif

      set this.curDist = this.curDist + VELOCITY/T32_FPS
    endmethod

    implement T32x

    static method create takes unit caster, real x, real y, real face, real damage, real maxDist returns thistype
      local thistype this = thistype.allocate()
      local integer i = 0
      local real offsetAngle
      local real offsetDist
      local integer middle = (HORSEMEN_COUNT-1)/2

      set this.caster = caster
      set this.maxDist = maxDist
      set this.damage = damage
      set this.hitGroup = CreateGroup()
      set this.reapProjectiles = Set.create("reaping hour")

      loop
        exitwhen i == HORSEMEN_COUNT
        if i < middle then
          set offsetAngle = face-90 - 15*(middle-i)
          set offsetDist = (middle - i)*(HORSEMEN_WIDTH / HORSEMEN_COUNT)
        elseif i > middle then
          set offsetAngle = face+90 + 15*(i - middle)
          set offsetDist = (i - middle)*(HORSEMEN_WIDTH / HORSEMEN_COUNT)
        else
          set offsetAngle = 0
          set offsetDist = 0
        endif
        call reapProjectiles.add(ReapProjectile.create(GetPolarOffsetX(x, offsetDist, offsetAngle), GetPolarOffsetY(y, offsetDist, offsetAngle), face)) 
        set i = i + 1
      endloop

      call this.startPeriodic()

      return this
    endmethod
  endstruct

  private function Cast takes nothing returns nothing
    local ability triggerAbility = null
    local unit triggerUnit = null
    local real triggerX = 0
    local real triggerY = 0
    local real triggerFace = 0
    local integer i = 0
    local real offsetAngle = 0
    local real offsetDist = 0
    local integer middle = 0
    local integer level = 0
    set triggerUnit = GetTriggerUnit()
    set triggerX = GetUnitX(triggerUnit)
    set triggerY = GetUnitY(triggerUnit)
    set triggerFace = GetUnitFacing(triggerUnit)
    set level = GetUnitAbilityLevel(triggerUnit, ABIL_ID)    
    call ReapingHour.create(triggerUnit, triggerX, triggerY, triggerFace, DAMAGE_BASE + DAMAGE_LEVEL*level, RANGE)
    set triggerUnit = null
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterSpellEffectAction(ABIL_ID, function Cast)
  endfunction

endlibrary