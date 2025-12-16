#nullable enable
using System.CommandLine;
using System.IO;
using AutoMapper;
using Launcher.Services;
using Launcher.Settings;

namespace Launcher.Commands;

public static class JsonToW3XFolderCommands
{
  public static void RegisterJsonToW3XCommands(this RootCommand rootCommand)
  {
    var mapNameArgument = new Argument<string>(
      name: "mapname",
      description: "The directory in which the source map data is stored.");
    var jsonToW3XCommand = new Command("json-to-w3x", "Converts raw map data into a Warcraft 3 map.");
    rootCommand.Add(jsonToW3XCommand);
    jsonToW3XCommand.AddArgument(mapNameArgument);
    jsonToW3XCommand.SetHandler(name => Run(name, BuildFolderOutputOptions), mapNameArgument);

    var testCommand = new Command("test", "Compiles a .w3x folder into the artifacts folder, then launches it for testing purposes.");
    rootCommand.Add(testCommand);
    testCommand.AddArgument(mapNameArgument);
    testCommand.SetHandler(name => Run(name, BuildTestOutputOptions), mapNameArgument);
  }

  private static void Run(string mapName, OptionsFactory optionsFactory)
  {
    var appSettings = AppSettings.Load();
    var autoMapperConfig = AutoMapperConfigurationProvider.GetConfiguration();
    var mapper = new Mapper(autoMapperConfig);
    var conversionService = new MapDataToMapConverter(mapper);

    var advancedMapBuilder = new AdvancedMapBuilder(optionsFactory(mapName, appSettings));
    var mapDataDirectory = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.MapDataPath, mapName);

    var (mapFolder, additionalFileDirectories) = conversionService.ConvertToMapAndAdditionalFiles(mapDataDirectory);
    advancedMapBuilder.SaveMapDirectory(mapFolder, additionalFileDirectories);
  }

  private static AdvancedMapBuilderOptions BuildFolderOutputOptions(string mapName, AppSettings appSettings)
  {
    return new AdvancedMapBuilderOptions(appSettings.CompilerSettings.RootPath, mapName)
    {
      Version = appSettings.MapSettings.Version,
      OutputPath = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.MapsPath, $"{mapName}.w3x"),
      ShouldBackup = true
    };
  }

  private static AdvancedMapBuilderOptions BuildTestOutputOptions(string mapName, AppSettings appSettings)
  {
    return new AdvancedMapBuilderOptions(appSettings.CompilerSettings.RootPath, mapName)
    {
      TestingPlayerSlot = appSettings.CompilerSettings.TestingPlayerSlot,
      Warcraft3ExecutablePath = appSettings.CompilerSettings.Warcraft3ExecutablePath,
      ShouldTranspile = true,
      ShouldMigrate = true,
      Version = appSettings.MapSettings.Version,
      OutputPath = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.ArtifactsPath, $"{mapName}{appSettings.MapSettings.Version}.w3x"),
    };
  }

  private delegate AdvancedMapBuilderOptions OptionsFactory(string rootName, AppSettings appSettings);
}
