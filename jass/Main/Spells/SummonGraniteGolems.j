library SummonGraniteGolems initializer OnInit requires DummyCast, Filters

  globals
    private constant integer ABIL_ID = 'A0EP'
    private constant integer SUMMON_ID = 'nggr'
    private constant integer SUMMON_COUNT = 4
    private constant real DURATION = 60.
    private constant real RADIUS = 400.
    private constant real ANGLE_OFFSET = 45.
    private constant string EFFECT = "war3mapImported\\Earth NovaTarget.mdx"
  endglobals

  private function Cast takes nothing returns nothing
    local integer i = 0
    local real angle = ANGLE_OFFSET
    local unit summonedUnit
    local real x
    local real y
    loop
      exitwhen i == SUMMON_COUNT
      set angle = angle + 360. / SUMMON_COUNT
      set x = GetPolarOffsetX(GetUnitX(GetTriggerUnit()), RADIUS, angle)
      set y = GetPolarOffsetY(GetUnitY(GetTriggerUnit()), RADIUS, angle)
      set summonedUnit = CreateUnit(GetOwningPlayer(GetTriggerUnit()), SUMMON_ID, x, y, GetAngleBetweenPoints(x, y, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit())))
      call UnitApplyTimedLife(summonedUnit, 0, DURATION)
      call UnitAddType(summonedUnit, UNIT_TYPE_SUMMONED)
      call SetUnitAnimation(summonedUnit, "birth")
      call QueueUnitAnimation(summonedUnit, "stand")
      call DestroyEffect(AddSpecialEffect(EFFECT, x, y))
      set i = i + 1
    endloop
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterSpellEffectAction(ABIL_ID, function Cast)
  endfunction 
    
endlibrary
