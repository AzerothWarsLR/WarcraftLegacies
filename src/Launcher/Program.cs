using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CSharpLua;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using War3Net.Build;
using War3Net.Build.Extensions;
using War3Net.Build.Info;
using War3Net.IO.Mpq;
using WCSharp.ConstantGenerator;
using CoreSystemProvider = CSharpLua.CoreSystem.CoreSystemProvider;

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
      var baseMapPath = args[1];
      var sourceCodeProjectFolderPath = args[2];
      var config = GetAppConfiguration();

      switch (launchMode)
      {
        case LaunchMode.GenerateConstants:
          ConstantGenerator.Run(baseMapPath, sourceCodeProjectFolderPath, new ConstantGeneratorOptions
          {
            IncludeCode = true
          });
          break;
        case LaunchMode.Publish:
          Build(baseMapPath, sourceCodeProjectFolderPath, false, config);
          break;
        case LaunchMode.Test:
          Build(baseMapPath, sourceCodeProjectFolderPath, true, config);
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(args));
      }
    }

    private static IConfiguration GetAppConfiguration()
    {
      var userAppsettingsFileName = $"appsettings.{Environment.UserName}.json";
      var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent;
      var projectDirPath = Path.GetDirectoryName(projectDir.FullName);
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

    /// <summary>
    ///   Builds the Warcraft 3 map.
    /// </summary>
    private static void Build(string baseMapPath, string projectFolderPath, bool launch, IConfiguration config)
    {
      var launchSettings = config.GetRequiredSection(nameof(LaunchSettings)).Get<LaunchSettings>();

      // Ensure these folders exist
      Directory.CreateDirectory(launchSettings.AssetsFolderPath);
      Directory.CreateDirectory(launchSettings.OutputFolderPath);

      // Load existing map data
      var map = Map.Open(baseMapPath);

      FixDoodadData(map);
      if (launch)
        SetTestPlayerSlot(map, launchSettings.TestingPlayerSlot);
      var builder = new MapBuilder(map);
      builder.AddFiles(baseMapPath, "*", SearchOption.AllDirectories);
      builder.AddFiles(launchSettings.AssetsFolderPath, "*", SearchOption.AllDirectories);

      // Set debug options if necessary, configure compiler
      const string csc = Debug ? "-debug -define:DEBUG" : null;
      var csproj = Directory.EnumerateFiles(projectFolderPath, "*.csproj", SearchOption.TopDirectoryOnly).Single();
      var compiler = new Compiler(csproj, launchSettings.OutputFolderPath, string.Empty, null,
        "War3Api.*;WCSharp.*;MacroTools.*", "", csc, false, null,
        string.Empty)
      {
        IsExportMetadata = true,
        IsModule = false,
        IsInlineSimpleProperty = false,
        IsPreventDebugObject = true,
        IsCommentsDisabled = !Debug
      };

      // Collect required paths and compile
      var coreSystemFiles = CoreSystemProvider.GetCoreSystemFiles();
      var blizzardJ = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "Warcraft III/JassHelper/Blizzard.j");
      var commonJ = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "Warcraft III/JassHelper/common.j");
      var compileResult = map.CompileScript(compiler, coreSystemFiles, blizzardJ, commonJ);

      // If compilation failed, output an error
      if (!compileResult.Success)
        throw new Exception(compileResult.Diagnostics.First(x => x.Severity == DiagnosticSeverity.Error).GetMessage());

      // Update war3map.lua so you can inspect the generated Lua code easily
      File.WriteAllText(Path.Combine(launchSettings.OutputFolderPath, launchSettings.OutputScriptName), map.Script);

      // Build w3x file
      var archiveCreateOptions = new MpqArchiveCreateOptions
      {
        BlockSize = 3,
        AttributesCreateMode = MpqFileCreateMode.Overwrite,
        ListFileCreateMode = MpqFileCreateMode.Overwrite
      };

      builder.Build(Path.Combine(launchSettings.OutputFolderPath, launchSettings.OutputMapName), archiveCreateOptions);
      if (launch)
        LaunchGame(launchSettings);
    }

    /// <summary>
    ///   Makes all players prior to the given player slot computers,
    ///   so that the given player slot is what the tester will play as when the map is launched.
    /// </summary>
    private static void SetTestPlayerSlot(Map map, int playerSlot)
    {
      if (map.Info == null) return;
      foreach (var player in map.Info.Players)
        if (player.Id < playerSlot && player.Id != playerSlot && player.Controller != PlayerController.None)
          player.Controller = PlayerController.Computer;
    }

    private static void FixDoodadData(Map map)
    {
      if (map.Doodads == null) 
        return;
      var i = 0;
      foreach (var doodad in map.Doodads.Doodads)
      {
        doodad.CreationNumber = i;
        i++;
      }
    }

    private static void LaunchGame(LaunchSettings launchSettings)
    {
      var wc3Exe = launchSettings.Warcraft3ExecutablePath;
      if (File.Exists(wc3Exe))
      {
        var commandLineArgs = new StringBuilder();
        var isReforged = Version.Parse(FileVersionInfo.GetVersionInfo(wc3Exe).FileVersion) >= new Version(1, 32);
        commandLineArgs.Append(isReforged ? " -launch" : $" -graphicsapi {GraphicsApi}");

        commandLineArgs.Append(" -nowfpause");

        var mapPath = Path.Combine(launchSettings.OutputFolderPath, launchSettings.OutputMapName);
        var absoluteMapPath = new FileInfo(mapPath).FullName;
        commandLineArgs.Append($" -loadfile \"{absoluteMapPath}\"");

        Process.Start(wc3Exe, commandLineArgs.ToString());
      }
      else
      {
        throw new Exception(
          "Please set Warcraft3ExecutablePath in Launcher/appsettings.json to the path of your Warcraft III executable.");
      }
    }
  }
}