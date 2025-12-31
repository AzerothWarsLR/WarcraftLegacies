using System;
using Warcraft.Cartographer.Deserialization;
using WarcraftLegacies.CLI.Migrations;
using WarcraftLegacies.CLI.Settings;

namespace WarcraftLegacies.CLI.Contexts;

internal sealed class MapBuildContext : MapCommandContext
{
  public AdvancedMapBuilderOptions AdvancedMapBuilderOptions { get; }

  public MapDataToMapConverterOptions MapConverterOptions { get; }

  public MapOutputKind OutputKind { get; set; }

  public MapBuildContext(string mapName, IncludeFromMap include, bool deleteDestination) : base(mapName, include, deleteDestination)
  {
    AdvancedMapBuilderOptions = DefaultOptionsFactory.CreateAdvancedMapBuilderOptions(Paths);
    AdvancedMapBuilderOptions.MapMigrations = MapMigrationProvider.GetMapMigrations();
    AdvancedMapBuilderOptions.DeleteDestination = deleteDestination;
    AdvancedMapBuilderOptions.ShouldTranspile = include.HasFlag(IncludeFromMap.Script);

    MapConverterOptions = DefaultOptionsFactory.CreateMapDataToMapConverterOptions(Paths);
    MapConverterOptions.IncludeFromMap = include;
  }

  public override void Execute()
  {
    var converter = new MapDataToMapConverter(MapConverterOptions);
    var builder = new AdvancedMapBuilder(AdvancedMapBuilderOptions);

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
