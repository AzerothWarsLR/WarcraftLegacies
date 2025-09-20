#nullable enable
using System.CommandLine;
using AutoMapper;
using Launcher.Services;
using Launcher.Settings;
using Microsoft.Extensions.Configuration;

namespace Launcher.Commands;

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

    var setMapTitlesOption = new Option<bool>(
      name: "--set-map-titles",
      description: "Whether or not to adjust the map's title, file name, and loading screen title.");
    command.AddOption(setMapTitlesOption);

    var outputTypeOption = new Option<MapOutputType>(
      name: "--output-type",
      description: "Whether the output should be a .w3x file or a folder.");
    command.AddOption(outputTypeOption);

    command.SetHandler(Run, mapNameArgument, launchArgument, mapDataDirectoryArgument, outputDirectoryArgument,
      sourceCodeFolderPathOption, backupDirectoryOption, setMapTitlesOption, outputTypeOption);
  }

  private static void Run(string mapName, bool launch, string mapDataDirectory, string outputDirectory,
    string? sourceCodeFolderPath, string? backupDirectory, bool setMapTitles,
    MapOutputType mapOutputType = MapOutputType.File)
  {
    var appConfiguration = Program.GetAppConfiguration();
    var compilerSettings = appConfiguration.GetRequiredSection(nameof(CompilerSettings)).Get<CompilerSettings>();
    var mapSettings = appConfiguration.GetRequiredSection(nameof(MapSettings)).Get<MapSettings>();

    var autoMapperConfig = new AutoMapperConfigurationProvider().GetConfiguration();
    var mapper = new Mapper(autoMapperConfig);
    var conversionService = new MapDataToMapConverter(mapper, new JsonModifierProvider());


    var options = new AdvancedMapBuilderOptions
    {
      MapName = mapName,
      OutputDirectory = outputDirectory,
      SourceCodeProjectFolderPath = sourceCodeFolderPath,
      Launch = launch,
      BackupDirectory = backupDirectory,
      SetMapTitles = setMapTitles
    };
    var advancedMapBuilder = new AdvancedMapBuilder(compilerSettings, mapSettings);

    switch (mapOutputType)
    {
      case MapOutputType.File:
        var (mapFile, additionalFiles) = conversionService.ConvertToMapAndAdditionalFileDirectories(mapDataDirectory);
        advancedMapBuilder.SaveMapFile(mapFile, additionalFiles, options);
        break;
      case MapOutputType.Folder:
        var (mapFolder, additionalFileDirectories) = conversionService.ConvertToMapAndAdditionalFiles(mapDataDirectory);
        advancedMapBuilder.SaveMapDirectory(mapFolder, additionalFileDirectories, options);
        break;
    }
  }
}
