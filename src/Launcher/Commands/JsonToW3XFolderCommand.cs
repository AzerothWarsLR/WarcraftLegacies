#nullable enable
using System.CommandLine;
using System.IO;
using AutoMapper;
using Launcher.Services;
using Launcher.Settings;

namespace Launcher.Commands;

public static class JsonToW3XFolderCommand
{
  public static void RegisterJsonToW3XCommand(this RootCommand rootCommand)
  {
    var command = new Command("json-to-w3x", "Converts raw map data into a Warcraft 3 map.");
    rootCommand.Add(command);

    var mapNameArgument = new Argument<string>(
      name: "mapname",
      description: "The directory in which the source map data is stored.");
    command.AddArgument(mapNameArgument);

    command.SetHandler(Run, mapNameArgument);
  }

  private static void Run(string mapName)
  {
    var appSettings = AppSettings.Load();
    var autoMapperConfig = AutoMapperConfigurationProvider.GetConfiguration();
    var mapper = new Mapper(autoMapperConfig);
    var conversionService = new MapDataToMapConverter(mapper);

    var advancedMapBuilder = new AdvancedMapBuilder(new AdvancedMapBuilderOptions
    {
      MapName = mapName,
      OutputType = MapOutputType.Folder,
      RootPath = appSettings.CompilerSettings.RootPath
    });

    var mapDataDirectory = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.MapData, mapName);

    var (mapFolder, additionalFileDirectories) = conversionService.ConvertToMapAndAdditionalFiles(mapDataDirectory);
    advancedMapBuilder.SaveMapDirectory(mapFolder, additionalFileDirectories);
  }
}
