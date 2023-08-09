#nullable enable
using System.CommandLine;
using System.IO;
using AutoMapper;
using Launcher.Services;
using Launcher.Settings;
using Microsoft.Extensions.Configuration;

namespace Launcher.Commands
{
  public static class MapDataToW3XCommand
  {
    public static void RegisterMapDataToW3XCommand(this RootCommand rootCommand)
    {
      var command = new Command("mapdata-to-w3x", "Converts raw map data into a Warcraft 3 map.");
      rootCommand.Add(command);

      var mapNameArgument = new Argument<string>(
        name: "mapname",
        description: "The directory in which the source map data is stored.");
      command.AddArgument(mapNameArgument);
      
      var launchArgument = new Argument<bool>(
        name: "launch",
        description: "Whether or not to launch the map after it's converted.");
      command.AddArgument(launchArgument);
      
      var mapDataDirectoryArgument = new Argument<string>(
        name: "mapDataPath",
        description: "The location of the map data that will be used to build the map.");
      command.AddArgument(mapDataDirectoryArgument);
      
      var outputDirectoryArgument = new Argument<string>(
        name: "outputDirectory",
        description: "Where the fully built map should be saved.");
      command.AddArgument(outputDirectoryArgument);
      
      var sourceCodeFolderPathOption = new Option<string>(
        name: "--sourcecodepath",
        description: "C# code included in this directory will be transpiled into Lua and included in the output.");
      command.AddOption(sourceCodeFolderPathOption);
      
      var backupDirectoryOption = new Option<string>(
        name: "--backup-directory",
        description: "Any overwritten maps will be moved to this directory instead of being deleted.");
      command.AddOption(backupDirectoryOption);

      command.SetHandler(Run, mapNameArgument, launchArgument, mapDataDirectoryArgument, outputDirectoryArgument,
        sourceCodeFolderPathOption, backupDirectoryOption);
    }

    private static void Run(string mapName, bool launch, string mapDataDirectory, string outputDirectory, string? sourceCodeFolderPath, string? backupDirectory)
    {
      var appConfiguration = Program.GetAppConfiguration();
      var compilerSettings = appConfiguration.GetRequiredSection(nameof(CompilerSettings)).Get<CompilerSettings>();
      var mapSettings = appConfiguration.GetRequiredSection(nameof(MapSettings)).Get<MapSettings>();
      
      var autoMapperConfig = new AutoMapperConfigurationService().GetConfiguration();
      var mapper = new Mapper(autoMapperConfig);
      var conversionService = new MapDataToW3XConversionService(mapper, new JsonModifierProvider());
      var mapBuilderFromMapData = conversionService.Convert(mapDataDirectory);
      
      new MapBuilderService(compilerSettings, mapSettings)
        .BuildAndSave(mapBuilderFromMapData, mapName, sourceCodeFolderPath, launch, outputDirectory, backupDirectory);
    }
  }
}