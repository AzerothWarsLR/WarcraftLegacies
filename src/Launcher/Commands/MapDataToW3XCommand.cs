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
      
      var publishArgument = new Argument<bool>(
        name: "publish",
        description: "If true, the map will be saved in a directory for published maps.");
      command.AddArgument(publishArgument);
      
      var outputDirectoryArgument = new Argument<string>(
        name: "outputDirectory",
        description: "Where the fully built map should be saved.");
      command.AddArgument(outputDirectoryArgument);
      
      var sourceCodeFolderPathOption = new Option<string>(
        name: "--sourecodepath",
        description: "C# code included in this directory will be transpiled into Lua and included in the output.");
      command.AddOption(sourceCodeFolderPathOption);

      command.SetHandler(Run, mapNameArgument, launchArgument, publishArgument, outputDirectoryArgument,
        sourceCodeFolderPathOption);
    }

    private static void Run(string mapName, bool launch, bool publish, string outputDirectory, string? sourceCodeFolderPath)
    {
      var appConfiguration = Program.GetAppConfiguration();
      var launchSettings = appConfiguration.GetRequiredSection(nameof(LaunchSettings)).Get<LaunchSettings>();
      var mapSettings = appConfiguration.GetRequiredSection(nameof(MapSettings)).Get<MapSettings>();
      
      var autoMapperConfig = new AutoMapperConfigurationService().GetConfiguration();
      var mapper = new Mapper(autoMapperConfig);
      var conversionService = new MapDataToW3XConversionService(mapper, new JsonModifierProvider());
      var mapBuilderFromMapData = conversionService.Convert(Path.Combine(launchSettings.MapDataPath, mapName));
      
      new MapBuilderService(launchSettings, mapSettings)
        .BuildAndSave(mapBuilderFromMapData, mapName, sourceCodeFolderPath, launch, outputDirectory);
    }
  }
}