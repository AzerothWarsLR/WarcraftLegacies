using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CSharpLua;
using Launcher.Settings;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using War3Api.Object.Enums;
using War3Net.Build;
using War3Net.Build.Extensions;
using War3Net.Build.Info;
using War3Net.IO.Mpq;

namespace Launcher.Services
{
  /// <summary>
  /// Builds a Warcraft 3 map based on inputs.
  /// </summary>
  public sealed class MapBuilderService
  {
    private const string GraphicsApi = "Direct3D9";
#if DEBUG
    private const bool Debug = true;
#else
		private const bool Debug = false;
#endif

    public void Build(string baseMapPath, string projectFolderPath, bool launch, IConfiguration config)
    {
      var launchSettings = config.GetRequiredSection(nameof(LaunchSettings)).Get<LaunchSettings>();
      var mapSettings = config.GetRequiredSection(nameof(MapSettings)).Get<MapSettings>();

      // Ensure these folders exist
      Directory.CreateDirectory(launchSettings.AssetsFolderPath);
      Directory.CreateDirectory(launchSettings.OutputFolderPath);

      // Load existing map data
      var map = Map.Open(baseMapPath);
      ConfigureControlPointData(map);
      if (launch)
        SetTestPlayerSlot(map, launchSettings.TestingPlayerSlot);
      SetMapTitles(map, mapSettings.Version);
      var builder = new MapBuilder(map);
      builder.AddFiles(baseMapPath, "*", SearchOption.AllDirectories);
      builder.AddFiles(launchSettings.AssetsFolderPath, "*", SearchOption.AllDirectories);

      // Set debug options if necessary, configure compiler
      const string csc = Debug ? "-debug -define:DEBUG" : null;
      var csproj = Directory.EnumerateFiles(projectFolderPath, "*.csproj", SearchOption.TopDirectoryOnly).Single();
      var compiler = new Compiler(csproj, launchSettings.OutputFolderPath, string.Empty, null!,
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
      var mapScriptBuilder = new MapScriptBuilder();
      mapScriptBuilder.SetDefaultOptionsForCSharpLua();
      mapScriptBuilder.ForceGenerateGlobalDestructableVariable = false;

      var compileResult = map.CompileScript(compiler, mapScriptBuilder, coreSystemFiles, blizzardJ, commonJ);

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

      var mapFilePath = launch
        ? $"{Path.Combine(launchSettings.OutputFolderPath, mapSettings.Name)}Test.w3x"
        : $"{Path.Combine(launchSettings.OutputFolderPath, mapSettings.Name)}{mapSettings.Version}.w3x";

      builder.Build(mapFilePath, archiveCreateOptions);
      if (launch)
        LaunchGame(launchSettings.Warcraft3ExecutablePath, mapFilePath);
    }

    private static void SetMapTitles(Map map, string version)
    {
      if (map.Info == null)
        return;
      map.Info.MapName = $"Warcraft Legacies {version}";
      map.Info.LoadingScreenTitle = $"Warcraft Legacies {version}";
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

    private static bool IsControlPoint(War3Api.Object.Unit unit)
    {
      return unit.IsStatsUnitClassificationModified &&
             unit.StatsUnitClassification.Contains(UnitClassification.Sapper) &&
             unit.StatsUnitClassification.Contains(UnitClassification.Ancient) &&
             !unit.StatsUnitClassification.Contains(UnitClassification.Mechanical);
    }

    private static void ConfigureControlPointData(Map map)
    {
      var objectDatabase = map.GetObjectDatabaseFromMap();
      foreach (var unit in objectDatabase.GetUnits().Where(IsControlPoint))
      {
        unit.CombatAttack1DamageBase = -1;
        unit.CombatAttack1DamageNumberOfDice = 1;
        unit.CombatAttack1DamageSidesPerDie = 1;
        unit.CombatAttacksEnabled = AttackBits.Attack1Only;
        unit.CombatAttack1Range = 900;
        unit.CombatAcquisitionRange = 900;
        unit.CombatAttack1TargetsAllowed = new[] { Target.Bridge };
        unit.EditorDisplayAsNeutralHostile = true;
        unit.StatsLevel = 0;
        unit.StatsRace = UnitRace.Creeps;
        unit.StatsCanBeBuiltOn = false;
        unit.PathingPathingMap = @"PathTextures\4x4SimpleSolid.tga";
        unit.StatsHitPointsRegenerationRate = 0;
      }

      map.UnitObjectData = objectDatabase.GetAllData().UnitData;
    }

    private static void LaunchGame(string warcraft3ExecutablePath, string mapFilePath)
    {
      if (File.Exists(warcraft3ExecutablePath))
      {
        var commandLineArgs = new StringBuilder();
        var fileVersion = FileVersionInfo.GetVersionInfo(warcraft3ExecutablePath).FileVersion;
        var isReforged = fileVersion != null && Version.Parse(fileVersion) >= new Version(1, 32);
        commandLineArgs.Append(isReforged ? " -launch" : $" -graphicsapi {GraphicsApi}");

        commandLineArgs.Append(" -nowfpause");

        var absoluteMapPath = new FileInfo(mapFilePath).FullName;
        commandLineArgs.Append($" -loadfile \"{absoluteMapPath}\"");

        Process.Start(warcraft3ExecutablePath, commandLineArgs.ToString());
      }
      else
      {
        throw new Exception(
          "Please set Warcraft3ExecutablePath in Launcher/appsettings.json to the path of your Warcraft III executable.");
      }
    }
  }
}