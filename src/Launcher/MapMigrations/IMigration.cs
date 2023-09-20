using War3Api.Object;
using War3Net.Build;

namespace Launcher.MapMigrations
{
  public interface IMigration
  {
    public void Migrate(Map map, ObjectDatabase objectDatabase);
  }
}