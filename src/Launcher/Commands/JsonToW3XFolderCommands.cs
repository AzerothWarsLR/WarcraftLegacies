#nullable enable
using System.CommandLine;
using System.IO;
using AutoMapper;
using Launcher.Services;

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
    var sharedOptionsPath = SharedPathOptions.Create(mapName);
    var advancedMapBuilder = new AdvancedMapBuilder(optionsFactory(sharedOptionsPath, mapName));

    var autoMapperConfig = AutoMapperConfigurationProvider.GetConfiguration();
    var mapper = new Mapper(autoMapperConfig);
    var conversionService = new MapDataToMapConverter(mapper);
    var (mapFolder, additionalFileDirectories) = conversionService.ConvertToMapAndAdditionalFiles(sharedOptionsPath.MapDataPath);
    advancedMapBuilder.SaveMapDirectory(mapFolder, additionalFileDirectories);
  }

  private static AdvancedMapBuilderOptions BuildFolderOutputOptions(SharedPathOptions sharedPathOptions, string mapName)
  {
    var options = AdvancedMapBuilderOptions.Create(sharedPathOptions);
    options.ShouldBackup = true;
    return options;
  }

  private static AdvancedMapBuilderOptions BuildTestOutputOptions(SharedPathOptions sharedPathOptions, string mapName)
  {
    var options = AdvancedMapBuilderOptions.Create(sharedPathOptions);
    options.ShouldLaunch = true;
    options.ShouldTranspile = true;
    options.ShouldMigrate = true;
    options.OutputPath = Path.Combine(options.ScriptArtifactPath, $"{mapName}.w3x");
    return options;
  }

  private delegate AdvancedMapBuilderOptions OptionsFactory(SharedPathOptions sharedPathOptions, string mapName);
}
