using System;
using Launcher.Services;

namespace Launcher.CLI.Contexts;

internal sealed class MapBuildContext : MapCommandContext
{
  public AdvancedMapBuilderOptions Builder { get; }

  public MapOutputKind OutputKind { get; set; }

  public MapBuildContext(string mapName, IncludeFromMap include, bool deleteDestination) : base(mapName, include, deleteDestination)
  {
    Builder = AdvancedMapBuilderOptions.Create(Paths);
  }

  public override void Execute()
  {
    var converter = new MapDataToMapConverter(MapDataToMapConverterOptions.Create(Paths));
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
