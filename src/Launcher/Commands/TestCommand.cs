#nullable enable
using System.CommandLine;
using System.IO;
using AutoMapper;
using Launcher.Services;
using Launcher.Settings;

namespace Launcher.Commands;

public static class TestCommand
{
  public static void RegisterTestCommand(this RootCommand rootCommand)
  {
    var command = new Command("test", "Compiles a .w3x file into the artifacts folder, then launches it.");
    rootCommand.Add(command);

    var mapNameArgument = new Argument<string>(
      name: "mapname",
      description: "The name of the project.");
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
      OutputType = MapOutputType.Test,
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
