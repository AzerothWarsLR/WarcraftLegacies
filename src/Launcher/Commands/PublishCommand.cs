#nullable enable
using System.CommandLine;
using System.IO;
using AutoMapper;
using Launcher.Services;
using Launcher.Settings;

namespace Launcher.Commands;

public static class PublishCommand
{
  public static void RegisterPublishCommand(this RootCommand rootCommand)
  {
    var mapNameArgument = new Argument<string>(
      name: "mapname",
      description: "The name of the project.");

    var publishCommand = new Command("publish", "Publishes a release-ready w3x file.");
    rootCommand.Add(publishCommand);
    publishCommand.AddArgument(mapNameArgument);
    publishCommand.SetHandler(Run, mapNameArgument);
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
      OutputType = MapOutputType.Publish,
      RootPath = appSettings.CompilerSettings.RootPath,
      Warcraft3ExecutablePath = appSettings.CompilerSettings.Warcraft3ExecutablePath,
      Version = appSettings.MapSettings.Version
    });

    var mapDataDirectory = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.MapData, mapName);

    var (mapFile, additionalFiles) = conversionService.ConvertToMapAndAdditionalFileDirectories(mapDataDirectory);
    advancedMapBuilder.SaveMapFile(mapFile, additionalFiles);
  }
}
