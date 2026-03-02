using System.Linq;
using War3Api.Object;
using War3Net.Build;
using Warcraft.Cartographer.Migrations;

namespace WarcraftLegacies.CLI.Migrations;

/// <summary>
/// Sets the priority of every hero to a minimum value.
/// </summary>
public sealed class HeroPriorityMigration : IMapMigration
{
  private const int MinimumHeroPriority = 16;

  /// <inheritdoc />
  public void Migrate(Map map, ObjectDatabase objectDatabase)
  {
    var units = objectDatabase.GetUnits();

    foreach (var unit in units)
    {
      if (unit.AbilitiesHero.Any() && unit.StatsPriority < MinimumHeroPriority)
      {
        unit.StatsPriority = MinimumHeroPriority;
      }
    }

    var unitData = objectDatabase.GetAllData().UnitData;
    map.UnitObjectData = unitData;
    map.UnitSkinObjectData = unitData;
  }
}
