using War3Api.Object;
using War3Net.Build;

namespace Warcraft.Cartographer.Migrations;

public interface IMapMigration
{
  public void Migrate(Map map, ObjectDatabase objectDatabase);
}
