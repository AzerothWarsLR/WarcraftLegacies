using System;
using System.Linq;
using War3Api.Object;
using War3Net.Build;
using Warcraft.Cartographer.Migrations;
using WarcraftLegacies.Shared;

namespace WarcraftLegacies.CLI.Migrations;

/// <summary>
/// Sets the "Text - Tooltip - Basic", "Text - Tooltip - Revive", and "Text - Tooltip - Awaken" fields for units.
/// </summary>
public sealed class UnitTooltipBasicMigration : IMapMigration
{
  /// <inheritdoc />
  public void Migrate(Map map, ObjectDatabase objectDatabase)
  {
    var units = objectDatabase.GetUnits();
    var localized = MapMigrationProvider.IsLocalized;

    foreach (var unit in units)
    {
      try
      {
        // A build from the base map data composes every entry from the object database, which is what it has always
        // done; a localised build is handled below.
        if (!localized)
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

          continue;
        }

        var name = unit.TextName;

        // A localised build ships its tooltips as translated map data, so an entry the map data already states is
        // left as it is: composing one here would put an English name behind a translated verb, or an English verb
        // in front of a translated name.
        var hasBasic = !string.IsNullOrEmpty(unit.TextTooltipBasic);
        var hasAwaken = !string.IsNullOrEmpty(unit.TextTooltipAwaken);
        var hasRevive = !string.IsNullOrEmpty(unit.TextTooltipRevive);

        if (unit.AbilitiesHero.Any())
        {
          // A hero's build-bar entry is named after its proper name, which is localized separately, so the verb
          // is translated around the substituted name rather than stored as one whole string.
          var properName = unit.TextProperNames.Any() ? unit.TextProperNames.First() : name;
          if (!hasBasic)
          {
            unit.TextTooltipBasic = BuildText.Format("Summon {name}", properName);
          }

          if (!hasAwaken)
          {
            unit.TextTooltipAwaken = BuildText.Format("Revive {name}", name);
          }

          if (!hasRevive)
          {
            unit.TextTooltipRevive = BuildText.Format("Revive {name}", name);
          }
        }
        else if (!hasBasic)
        {
          var verb = unit.StatsIsABuilding ? "Build" : "Train";
          unit.TextTooltipBasic = BuildText.Format($"{verb} {{name}}", name);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to apply tooltip migration for {unit.TextName}: {ex}");
      }
    }

    // The changes live on the database's objects, so the database's data has to replace the map's for them to
    // reach the archive. Without this the archive keeps the English map data it was read from.
    var unitData = objectDatabase.GetAllData().UnitData;
    map.UnitObjectData = unitData;
    map.UnitSkinObjectData = unitData;
  }
}
