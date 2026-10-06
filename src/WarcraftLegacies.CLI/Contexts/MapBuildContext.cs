using System;
using Warcraft.Cartographer.Deserialization;
using WarcraftLegacies.CLI.Migrations;
using WarcraftLegacies.CLI.Settings;

namespace WarcraftLegacies.CLI.Contexts;

internal sealed class MapBuildContext : MapCommandContext
{
  private readonly IncludeFromMap _include;

  public AdvancedMapBuilderOptions AdvancedMapBuilderOptions { get; }

  public MapOutputKind OutputKind { get; set; }

  public MapBuildContext(string mapName, IncludeFromMap include, bool deleteDestination) : base(mapName, include, deleteDestination)
  {
    AdvancedMapBuilderOptions = DefaultOptionsFactory.CreateAdvancedMapBuilderOptions(Paths);
    AdvancedMapBuilderOptions.DeleteDestination = deleteDestination;
    AdvancedMapBuilderOptions.ShouldTranspile = include.HasFlag(IncludeFromMap.Script);

    _include = include;
  }

  public override void Execute()
  {
    // Built here rather than in the constructor so that --locale, which the command applies after construction,
    // is already known.
    ApplyLocale();

    AdvancedMapBuilderOptions.MapMigrations = MapMigrationProvider.GetMapMigrations();

    var mapConverterOptions = DefaultOptionsFactory.CreateMapDataToMapConverterOptions(Paths, Locale);
    mapConverterOptions.IncludeFromMap = _include;

    var converter = new MapDataToMapConverter(mapConverterOptions);
    var builder = new AdvancedMapBuilder(AdvancedMapBuilderOptions);

    if (Locale is not null)
    {
      Console.WriteLine($"Building from the '{Locale}' map data overlay.");
    }

    switch (OutputKind)
    {
      case MapOutputKind.Directory:
        {
          var (map, directories) = converter.ConvertToMapAndAdditionalFiles();
          builder.SaveMapDirectory(map, directories);
          break;
        }

      case MapOutputKind.File:
        {
          var (map, directories) = converter.ConvertToMapAndAdditionalFileDirectories();
          builder.PublishMapArchive(map, directories);
          break;
        }

      default:
        throw new ArgumentOutOfRangeException($"Unsupported output kind: {OutputKind}");
    }
  }
}

internal enum MapOutputKind
{
  Directory,
  File
}
