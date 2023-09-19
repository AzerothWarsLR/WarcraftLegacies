using War3Api.Object;
using War3Net.Build;

namespace Launcher.Migrations
{
  public interface IObjectMigration
  {
    public void Migrate(Map map, ObjectDatabase objectDatabase);
  }
}