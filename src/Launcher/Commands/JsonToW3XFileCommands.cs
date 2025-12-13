#nullable enable
using System.CommandLine;
using System.IO;
using AutoMapper;
using Launcher.Services;
using Launcher.Settings;

namespace Launcher.Commands;

public static class JsonToW3XFileCommands
{
  public static void RegisterJsonToW3XFileCommands(this RootCommand rootCommand)
  {
    var mapNameArgument = new Argument<string>(
      name: "mapname",
      description: "The name of the project.");

    var publishCommand = new Command("publish", "Publishes a release-ready w3x file.");
    rootCommand.Add(publishCommand);
    publishCommand.AddArgument(mapNameArgument);
    publishCommand.SetHandler(name => Run(name, MapOutputType.Publish), mapNameArgument);

    var testCommand = new Command("test", "Compiles a .w3x file into the artifacts folder, then launches it.");
    rootCommand.Add(testCommand);
    testCommand.AddArgument(mapNameArgument);
    testCommand.SetHandler(name => Run(name, MapOutputType.Test), mapNameArgument);
  }

  private static void Run(string mapName, MapOutputType outputType)
  {
    var appSettings = AppSettings.Load();
    var autoMapperConfig = AutoMapperConfigurationProvider.GetConfiguration();
    var mapper = new Mapper(autoMapperConfig);
    var conversionService = new MapDataToMapConverter(mapper);

    var advancedMapBuilder = new AdvancedMapBuilder(new AdvancedMapBuilderOptions
    {
      MapName = mapName,
      OutputType = outputType,
      RootPath = appSettings.CompilerSettings.RootPath,
      Warcraft3ExecutablePath = appSettings.CompilerSettings.Warcraft3ExecutablePath,
      Version = appSettings.MapSettings.Version,
      TestingPlayerSlot = appSettings.CompilerSettings.TestingPlayerSlot
    });

    var mapDataDirectory = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.MapData, mapName);

    var (mapFile, additionalFiles) = conversionService.ConvertToMapAndAdditionalFileDirectories(mapDataDirectory);
    advancedMapBuilder.SaveMapFile(mapFile, additionalFiles);
  }
}
