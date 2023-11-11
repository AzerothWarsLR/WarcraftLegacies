using static War3Api.Common;

namespace MacroTools.SpellSystem
{
  public static class CastFilters
  {
    public static bool IsTargetOrganicAndAlive(unit caster, unit target)
    {
      return !IsUnitType(target, UNIT_TYPE_STRUCTURE) && !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
             !IsUnitType(target, UNIT_TYPE_MECHANICAL) && UnitAlive(target);
    }
    
    public static bool IsTargetAllyAndAlive(unit caster, unit target)
    {
      var casterPlayer = GetOwningPlayer(caster);
      return (IsUnitAlly(target, casterPlayer) || GetOwningPlayer(target) == Player(PLAYER_NEUTRAL_PASSIVE)) &&
             UnitAlive(target) && BlzIsUnitInvulnerable(target) == false;
    }
    
    public static bool IsTargetOwnAliveNonHeroUnit(unit caster, unit target)
    {
      return  GetOwningPlayer(caster) == GetOwningPlayer(target) && UnitAlive(target) && 
              BlzIsUnitInvulnerable(target) == false && !IsUnitType(target, UNIT_TYPE_HERO) && 
              !IsUnitType(target, UNIT_TYPE_STRUCTURE) && !IsUnitType(target, UNIT_TYPE_ANCIENT);
    }
    
    public static bool IsTargetEnemyAndAlive(unit caster, unit target)
    {
      var casterPlayer = GetOwningPlayer(caster);
      return caster != target &&
             (IsUnitEnemy(target, casterPlayer) || GetOwningPlayer(target) == Player(PLAYER_NEUTRAL_PASSIVE)) &&
             UnitAlive(target) && BlzIsUnitInvulnerable(target) == false;
    }
  }
}