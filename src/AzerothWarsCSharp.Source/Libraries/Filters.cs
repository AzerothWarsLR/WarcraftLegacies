using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Libraries
{
  public static class Filters
  {
    public static bool IsTargetEnemyAndAlive(unit caster, unit target)
    {
      var casterPlayer = GetOwningPlayer(caster);
      return caster != target &&
             (IsUnitEnemy(target, casterPlayer) || GetOwningPlayer(target) == Player(PLAYER_NEUTRAL_PASSIVE)) &&
             UnitAlive(target) && BlzIsUnitInvulnerable(target) == false;
    }
  }
}