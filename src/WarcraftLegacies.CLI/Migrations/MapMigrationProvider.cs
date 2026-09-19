using System.Collections.Generic;
using Warcraft.Cartographer.Migrations;
using WarcraftLegacies.Shared;

namespace WarcraftLegacies.CLI.Migrations;

public static class MapMigrationProvider
{
  /// <summary>
  /// Gets the migrations a build applies to the map.
  /// <para>
  /// The tooltip migrations stay in the list even for a localised build, because they also normalise the
  /// unit database that later migrations walk; they simply do nothing when a locale overlay is active,
  /// since their text would overwrite the translated tooltips.
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
  /// Whether the tooltip migrations should generate text for the build currently loaded in
  /// <see cref="BuildText"/>. They compose "Summon X" / "Train X" from the unit's name, which is right for
  /// a build from the base map data but wrong for a localised build: it would overwrite the tooltips the
  /// locale overlay supplies with half translated ones.
  /// </summary>
  public static bool ShouldGenerateTooltips => true;
}
