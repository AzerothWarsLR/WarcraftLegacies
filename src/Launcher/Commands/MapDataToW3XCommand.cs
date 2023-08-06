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

      var launchArgument = new Argument<bool>(
        name: "launch",
        description: "Whether or not to launch the map after it's converted.");
      command.AddArgument(launchArgument);
      
      var sourceCodeFolderPathOption = new Option<string>(
        name: "--sourecodepath",
        description: "C# code included in this directory will be transpiled into Lua and included in the output.");
      command.AddOption(sourceCodeFolderPathOption);

      command.SetHandler(Run, launchArgument, sourceCodeFolderPathOption);
    }

    private static void Run(bool launch, string? sourceCodeFolderPath)
    {
      var config = Program.GetAppConfiguration();
      var launchSettings = config.GetRequiredSection(nameof(LaunchSettings)).Get<LaunchSettings>();
      var mapSettings = config.GetRequiredSection(nameof(MapSettings)).Get<MapSettings>();
      var autoMapperConfig = new AutoMapperConfigurationService().GetConfiguration();
      var mapper = new Mapper(autoMapperConfig);
      var conversionService = new MapDataToW3XConversionService(mapper, new JsonModifierProvider());
      var mapBuilderFromMapData = conversionService.Convert(Path.Combine(launchSettings.MapDataFolderPath, mapSettings.Name));
      new MapBuilderService().Build(mapBuilderFromMapData, sourceCodeFolderPath, launch, config);
    }
  }
}