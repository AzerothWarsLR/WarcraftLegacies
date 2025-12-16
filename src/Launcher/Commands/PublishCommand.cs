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

    var advancedMapBuilder = new AdvancedMapBuilder(new AdvancedMapBuilderOptions(appSettings.CompilerSettings.RootPath, mapName)
    {
      Version = appSettings.MapSettings.Version,
      ShouldMigrate = true,
      ShouldTranspile = true,
      OutputPath = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.PublishedPath, $"{mapName}{appSettings.MapSettings.Version}.w3x"),
    });

    var mapDataDirectory = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.MapDataPath, mapName);

    var (mapFile, additionalFiles) = conversionService.ConvertToMapAndAdditionalFileDirectories(mapDataDirectory);
    advancedMapBuilder.SaveMapFile(mapFile, additionalFiles);
  }
}
