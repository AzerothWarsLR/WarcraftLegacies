namespace AzerothWarsCSharp.Source.Main.Libraries
{
  public class Filters
  {
    player P = null;
    
    public static bool IsUnitHeroEnum()
    {
      return IsUnitType(GetFilterUnit(), UNIT_TYPE_HERO);
    }

    static boolean EnemyAliveFilter()
    {
      unit u = GetFilterUnit();
      boolean b = (IsUnitEnemy(u, P) || GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) && IsUnitAlive(u) &&
                  BlzIsUnitInvulnerable(u) == false;
      return b;
    }

    static boolean UnitEnemyAliveFilter()
    {
      unit u = GetFilterUnit();
      boolean b = (IsUnitEnemy(u, P) || GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) && IsUnitAlive(u) &&
                  BlzIsUnitInvulnerable(u) == false && !IsUnitType(u, UNIT_TYPE_STRUCTURE) &&
                  !IsUnitType(u, UNIT_TYPE_ANCIENT);
      return b;
    }

    static boolean AllyAliveFilter()
    {
      unit u = GetFilterUnit();
      return (IsUnitAlly(u, P) || GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)) && IsUnitAlive(u) &&
             BlzIsUnitInvulnerable(u) == false;
    }
  }
}