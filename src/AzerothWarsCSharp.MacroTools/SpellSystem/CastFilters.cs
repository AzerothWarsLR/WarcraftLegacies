using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.SpellSystem
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
      return caster != target &&
             (IsUnitAlly(target, casterPlayer) || GetOwningPlayer(target) == Player(PLAYER_NEUTRAL_PASSIVE)) &&
             UnitAlive(target) && BlzIsUnitInvulnerable(target) == false;
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