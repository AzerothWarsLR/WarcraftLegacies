using System;
using System.Linq;
using War3Api.Object;
using War3Net.Build;

namespace Launcher.MapMigrations;

/// <summary>
/// Sets the "Text - Tooltip - Basic", "Text - Tooltip - Revive", and "Text - Tooltip - Awaken" fields for units.
/// </summary>
public sealed class UnitTooltipBasicMigration : IMapMigration
{
  /// <inheritdoc />
  public void Migrate(Map map, ObjectDatabase objectDatabase)
  {
    var units = objectDatabase.GetUnits();
    foreach (var unit in units)
    {
      try
      {
        if (unit.AbilitiesHero.Any())
        {
          unit.TextTooltipBasic = $"Summon {unit.TextProperNames.First()}";
          unit.TextTooltipAwaken = $"Revive {unit.TextName}";
          unit.TextTooltipRevive = $"Revive {unit.TextName}";
        }
        else
        {
          unit.TextTooltipBasic = $"{(unit.StatsIsABuilding ? "Build" : "Train")} {unit.TextName}";
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to apply tooltip migration for {unit.TextName}: {ex}");
      }
    }

    var unitData = objectDatabase.GetAllData().UnitData;
    map.UnitObjectData = unitData;
    map.UnitSkinObjectData = unitData;
  }
}
