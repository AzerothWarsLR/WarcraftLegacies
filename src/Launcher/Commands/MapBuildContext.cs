using System;
using AutoMapper;
using Launcher.Services;

namespace Launcher.Commands;

internal sealed class MapBuildContext : MapCommandContext
{
  public AdvancedMapBuilderOptions Builder { get; }

  public MapOutputKind OutputKind { get; set; }

  public MapBuildContext(string mapName) : base(mapName)
  {
    Builder = AdvancedMapBuilderOptions.Create(Paths);
  }

  public override void Execute()
  {
    var converter = new MapDataToMapConverter(Paths, new Mapper(AutoMapperConfigurationProvider.GetConfiguration()));
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
          var (map, directories) = converter.ConvertToMapAndAdditionalFileDirectories(Paths.MapDataPathOptions.RootPath);
          builder.PublishMapArchive(map, directories);
          break;
        }

      default:
        throw new ArgumentOutOfRangeException($"Unsupported output kind: {OutputKind}");
    }
  }
}
