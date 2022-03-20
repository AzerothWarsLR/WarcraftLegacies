namespace AzerothWarsCSharp.Source.Main.Libraries
{
  public class Filters
  {
    player P = null;
    
    public static bool IsUnitHeroEnum()
    {
      return IsUnitType(GetFilterUnit(), UNIT_TYPE_HERO);
    }

    static bool EnemyAliveFilter()
    {
      unit u = GetFilterUnit();
      bool b = (IsUnitEnemy(u, P) || GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) && IsUnitAlive(u) &&
                  BlzIsUnitInvulnerable(u) == false;
      return b;
    }

    static bool UnitEnemyAliveFilter()
    {
      unit u = GetFilterUnit();
      bool b = (IsUnitEnemy(u, P) || GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) && IsUnitAlive(u) &&
                  BlzIsUnitInvulnerable(u) == false && !IsUnitType(u, UNIT_TYPE_STRUCTURE) &&
                  !IsUnitType(u, UNIT_TYPE_ANCIENT);
      return b;
    }

    static bool AllyAliveFilter()
    {
      unit u = GetFilterUnit();
      return (IsUnitAlly(u, P) || GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) && IsUnitAlive(u) &&
             BlzIsUnitInvulnerable(u) == false;
    }
  }
}