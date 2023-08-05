using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Launcher.Services;
using Launcher.Settings;
using Microsoft.Extensions.Configuration;
using WCSharp.ConstantGenerator;

namespace Launcher
{
  internal static class Program
  {
    // Warcraft III
    private const string GraphicsApi = "Direct3D9";
#if DEBUG
    private const bool Debug = true;
#else
		private const bool Debug = false;
#endif

    /// <summary>
    ///   Entry point for the program.
    /// </summary>
    private static void Main(string[] args)
    {
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
        case LaunchMode.GenerateConstants:
          sourceCodeProjectFolderPath = args[2];
          ConstantGenerator.Run(baseMapPath, sourceCodeProjectFolderPath, new ConstantGeneratorOptions
          {
            IncludeCode = true
          });
          break;
        case LaunchMode.Publish:
          sourceCodeProjectFolderPath = args[2];
          new MapBuilderService().Build(baseMapPath, sourceCodeProjectFolderPath, false, config);
          break;
        case LaunchMode.Test:
          sourceCodeProjectFolderPath = args[2];
          new MapBuilderService().Build(baseMapPath, sourceCodeProjectFolderPath, true, config);
          break;
        case LaunchMode.JsonToW3X:
          new MapDataToW3XConversionService(mapper, new JsonModifierProvider()).Convert(Path.Combine(launchSettings.MapDataFolderPath, mapSettings.Name),
            Path.Combine(launchSettings.MapFolderPath, $"{mapSettings.Name}.w3x"));
          break;
        case LaunchMode.W3XToJson:
          new W3XToMapDataConversionService(mapper).Convert(baseMapPath, Path.Combine(launchSettings.MapDataFolderPath, mapSettings.Name));
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(args));
      }
    }

    private static IConfiguration GetAppConfiguration()
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