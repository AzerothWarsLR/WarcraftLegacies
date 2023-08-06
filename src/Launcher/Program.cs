using System;
using System.CommandLine;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Launcher.Commands;
using Launcher.Services;
using Launcher.Settings;
using Microsoft.Extensions.Configuration;

namespace Launcher
{
  internal static class Program
  {
    /// <summary>
    ///   Entry point for the program.
    /// </summary>
    private static int Main(string[] args)
    {
      var rootCommand = new RootCommand();
      rootCommand.RegisterGenerateConstantsCommand();
      rootCommand.RegisterMapDataToW3XCommand();
      rootCommand.RegisterW3XToMapDataCommand();
      return rootCommand.Invoke(args);

      var launchMode = Enum.Parse<LaunchMode>(args[0]);
      var baseMapPath = args.Length > 1 ? args[1] : "";
      var config = GetAppConfiguration();
      string sourceCodeProjectFolderPath;
      
      var launchSettings = config.GetRequiredSection(nameof(LaunchSettings)).Get<LaunchSettings>();
      var mapSettings = config.GetRequiredSection(nameof(MapSettings)).Get<MapSettings>();
      
      var autoMapperConfig = new AutoMapperConfigurationService().GetConfiguration();
      var mapper = new Mapper(autoMapperConfig);
      
      switch (launchMode)
      {
        case LaunchMode.Test:
          sourceCodeProjectFolderPath = args[2];
          var mapBuilderFromMapData = new MapDataToW3XConversionService(mapper, new JsonModifierProvider()).Convert(Path.Combine(launchSettings.MapDataFolderPath, mapSettings.Name));
          new MapBuilderService().Build(mapBuilderFromMapData, sourceCodeProjectFolderPath, true, config);
          break;
        case LaunchMode.JsonToW3X:
          var mapBuilderFromMapData2 = new MapDataToW3XConversionService(mapper, new JsonModifierProvider()).Convert(Path.Combine(launchSettings.MapDataFolderPath, mapSettings.Name));
          new MapBuilderService().Build(mapBuilderFromMapData2, null, false, config);
          break;
        case LaunchMode.W3XToJson:
          new W3XToMapDataConversionService(mapper).Convert(baseMapPath, Path.Combine(launchSettings.MapDataFolderPath, mapSettings.Name));
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(args));
      }
    }

    public static IConfiguration GetAppConfiguration()
    {
      var userAppsettingsFileName = $"appsettings.{Environment.UserName}.json";
      var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent;
      var projectDirPath = Path.GetDirectoryName(projectDir?.FullName);
      var userAppsettingsFilePath = $"{projectDirPath}\\{userAppsettingsFileName}";

      if (!File.Exists(userAppsettingsFilePath))
        CreateUserAppSettings(userAppsettingsFilePath);

      return new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false, true)
        .AddJsonFile(userAppsettingsFilePath, true, true)
        .Build();
    }

    private static void CreateUserAppSettings(string userAppsettingsFilePath)
    {
      var settings = new JsonSerializerOptions
      {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = true
      };
      File.WriteAllText(userAppsettingsFilePath, JsonSerializer.Serialize(new AppSettings()
      {
        LaunchSettings = new LaunchSettings
        {
          TestingPlayerSlot = 0,
          Warcraft3ExecutablePath = ""
        }
      }, settings));
    }
  }
}