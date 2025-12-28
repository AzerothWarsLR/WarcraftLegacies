using System;
using Warcraft.Cartographer.Deserialization;
using WarcraftLegacies.CLI.Migrations;
using WarcraftLegacies.CLI.Settings;

namespace WarcraftLegacies.CLI.Contexts;

internal sealed class MapBuildContext : MapCommandContext
{
  public AdvancedMapBuilderOptions Builder { get; }

  public MapOutputKind OutputKind { get; set; }

  public MapBuildContext(string mapName, IncludeFromMap include, bool deleteDestination) : base(mapName, include, deleteDestination)
  {
    Builder = DefaultOptionsFactory.CreateAdvancedMapBuilderOptions(Paths);
    Builder.MapMigrations = MapMigrationProvider.GetMapMigrations();
  }

  public override void Execute()
  {
    var converter = new MapDataToMapConverter(DefaultOptionsFactory.CreateMapDataToMapConverterOptions(Paths));
    var builder = new AdvancedMapBuilder(Builder);

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
