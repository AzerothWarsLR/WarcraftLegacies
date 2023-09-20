namespace Launcher.MapMigrations
{
  public static class MapMigrationProvider
  {
    public static IMigration[] GetMapMigrations()
    {
      return new IMigration[]
      {
        new ControlPointMigration(),
        new GoldBountyMigration()
      };
    }
  }
}