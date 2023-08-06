using System.CommandLine;
using System.IO;
using AutoMapper;
using Launcher.Services;
using Launcher.Settings;
using Microsoft.Extensions.Configuration;

namespace Launcher.Commands
{
  public static class W3XToMapDataCommand
  {
    public static void RegisterW3XToMapDataCommand(this RootCommand rootCommand)
    {
      var command = new Command("w3x-to-mapdata", "Converts a Warcraft 3 map file into raw map data.");
      rootCommand.Add(command);

      var baseMapPathArgument = new Argument<string>(
        name: "basemappath",
        description: "The Warcraft 3 map to convert into map data.");
      command.AddArgument(baseMapPathArgument);

      command.SetHandler(Run, baseMapPathArgument);
    }

    private static void Run(string baseMapPath)
    {
      var config = Program.GetAppConfiguration();
      var launchSettings = config.GetRequiredSection(nameof(LaunchSettings)).Get<LaunchSettings>();
      var mapSettings = config.GetRequiredSection(nameof(MapSettings)).Get<MapSettings>();
      var autoMapperConfig = new AutoMapperConfigurationService().GetConfiguration();
      var mapper = new Mapper(autoMapperConfig);
      new W3XToMapDataConversionService(mapper).Convert(baseMapPath, Path.Combine(launchSettings.MapDataFolderPath, mapSettings.Name));
    }
  }
}