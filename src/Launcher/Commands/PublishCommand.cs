#nullable enable
using System.CommandLine;
using AutoMapper;
using Launcher.Services;

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
    var sharedPathOptions = SharedPathOptions.Create(mapName, true);

    var advancedMapBuilderOptions = AdvancedMapBuilderOptions.Create(sharedPathOptions);
    advancedMapBuilderOptions.ShouldMigrate = true;
    advancedMapBuilderOptions.ShouldSetVersion = true;
    advancedMapBuilderOptions.ShouldTranspile = true;
    var advancedMapBuilder = new AdvancedMapBuilder(advancedMapBuilderOptions);

    var autoMapperConfig = AutoMapperConfigurationProvider.GetConfiguration();
    var mapper = new Mapper(autoMapperConfig);
    var conversionService = new MapDataToMapConverter(mapper);
    var (mapFile, additionalFiles) = conversionService.ConvertToMapAndAdditionalFileDirectories(sharedPathOptions.MapDataPath);
    advancedMapBuilder.SaveMapFile(mapFile, additionalFiles);
  }
}
