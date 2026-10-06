using Warcraft.Cartographer.Migrations;
using WarcraftLegacies.Shared;

namespace WarcraftLegacies.CLI.Migrations;

public static class MapMigrationProvider
{
  /// <summary>
  /// Gets the migrations a build applies to the map.
  /// <para>
  /// The tooltip migrations stay in the list for every build. They also normalise the unit database that later
  /// migrations walk, and a localised build needs their output as much as a base build does - the verb on the
  /// build bar, the section headers, the limit line - with the difference that they take the map data's own text
  /// for the parts the translation states.
  /// </para>
  /// </summary>
  public static IMapMigration[] GetMapMigrations()
  {
    return new IMapMigration[]
    {
      new ControlPointMapMigration(),
      new CreepLevelMapMigration(),
      new GoldBountyMapMigration(),
      new FlightMigration(),
      new UnitTooltipExtendedMigration(),
      new UnitTooltipBasicMigration(),
      new PortraitModelFileMapMigration(),
      new HeroPriorityMigration()
    };
  }

  /// <summary>
  /// Whether the build currently loaded in <see cref="BuildText"/> targets a locale overlay.
  /// <para>
  /// The tooltip migrations compose text from the object database, which is what a build from the base map
  /// data wants. A localised build is different: its map data already holds the translation, so composing
  /// there would replace it with sentences built from English names. The migrations therefore take the
  /// base path when this is <c>false</c> and leave map data that already states a value alone when it is
  /// <c>true</c>.
  /// </para>
  /// </summary>
  public static bool IsLocalized => BuildText.Locale is not null;
}
