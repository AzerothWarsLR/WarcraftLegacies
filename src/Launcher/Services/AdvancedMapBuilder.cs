#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CSharpLua;
using Launcher.Extensions;
using Launcher.MapMigrations;
using Microsoft.CodeAnalysis;
using War3Net.Build;
using War3Net.Build.Extensions;
using War3Net.Build.Info;
using War3Net.IO.Mpq;
using CoreSystemProvider = CSharpLua.CoreSystem.CoreSystemProvider;

namespace Launcher.Services;

/// <summary>
/// Builds a Warcraft 3 map based on inputs.
/// </summary>
public sealed class AdvancedMapBuilder(AdvancedMapBuilderOptions options)
{
  private const string GraphicsApi = "Direct3D9";

  /// <summary>
  /// Builds a Warcraft 3 map based on the provided inputs and saves it as an MPQ archive to the published maps directory.
  /// </summary>
  public void PublishMapArchive(Map map, IEnumerable<DirectoryEnumerationOptions> additionalFileDirectories)
  {
    SupplementMap(map);

    var mapBuilder = new MapBuilder(map);

    foreach (var additionalFileDirectory in additionalFileDirectories)
    {
      mapBuilder.AddFiles(additionalFileDirectory.Path, additionalFileDirectory.SearchPattern ?? "*", SearchOption.AllDirectories);
    }

    var archiveCreateOptions = new MpqArchiveCreateOptions
    {
      BlockSize = 3,
      AttributesCreateMode = MpqFileCreateMode.Overwrite,
      ListFileCreateMode = MpqFileCreateMode.Overwrite
    };

    mapBuilder.Build(options.PublishedMapPath, archiveCreateOptions);
    Console.WriteLine($"Published map archive to {Path.GetFullPath(options.PublishedMapPath)}.");
  }

  /// <summary>
  /// Builds a Warcraft 3 map based on the provided inputs and saves it as a directory.
  /// <para>If doing so would cause an existing map to be overwritten, the destination is moved to the backups folder first.</para>
  /// </summary>
  public void SaveMapDirectory(Map map, IEnumerable<PathData> additionalFiles)
  {
    SupplementMap(map);

    if (options.ShouldBackup && Directory.Exists(options.W3XFolderPath))
    {
      if (options.ShouldBackup)
      {
        BackupFiles(options.BackupPath, options.W3XFolderPath);
      }
      Directory.Delete(options.W3XFolderPath, true);
    }

    map.BuildDirectory(options.W3XFolderPath, additionalFiles);

    Console.WriteLine($"Exported map folder to {Path.GetFullPath(options.W3XFolderPath)}.");
    if (options.ShouldLaunch)
    {
      LaunchGame(options.Warcraft3ExecutablePath, options.W3XFolderPath);
    }
  }

  /// <summary>
  /// Conditionally adds C# code, a map title, and/or a testing player slot depending on options setup.
  /// </summary>
  private void SupplementMap(Map map)
  {
    if (options.ShouldSetVersion)
    {
      SetMapTitles(map, options.Version);
    }

    if (options.ShouldLaunch && options.TestingPlayerSlot != 0)
    {
      SetTestPlayerSlot(map, options.TestingPlayerSlot);
    }

    if (options.ShouldTranspile)
    {
      AddCSharpCode(map);
    }

    if (options.ShouldMigrate)
    {
      ApplyMigrations(map);
    }
  }

  private static void ApplyMigrations(Map map)
  {
    Console.WriteLine("Applying object data migrations...");
    var timer = new Stopwatch();
    timer.Start();

    var objectDatabase = map.GetObjectDatabaseFromMap();
    foreach (var migration in MapMigrationProvider.GetMapMigrations())
    {
      migration.Migrate(map, objectDatabase);
    }

    map.UnitObjectData.FixUnkValues();

    timer.Stop();
    Console.WriteLine($"Completed object data migrations in {timer.Elapsed.Milliseconds} milliseconds.");
  }

  private static void SetMapTitles(Map map, string version)
  {
    if (map.Info == null)
    {
      return;
    }

    map.Info.MapName = $"Warcraft Legacies {version}";
    map.Info.LoadingScreenTitle = $"Warcraft Legacies {version}";
  }

  /// <summary>
  ///   Makes all players prior to the given player slot computers,
  ///   so that the given player slot is what the tester will play as when the map is launched.
  /// </summary>
  private static void SetTestPlayerSlot(Map map, int playerSlot)
  {
    if (map.Info == null)
    {
      return;
    }

    foreach (var player in map.Info.Players)
    {
      if (player.Id < playerSlot && player.Id != playerSlot && player.Controller != PlayerController.None)
      {
        player.Controller = PlayerController.Computer;
      }
    }
  }

  public void AddCSharpCode(Map map)
  {
    var compiler = new Compiler(options.CsProjPath, options.ScriptArtifactPath, string.Empty, null!,
      "War3Api.*;WCSharp.*;MacroTools.*;MacroTools.Shared.*;WarcraftLegacies.Shared.*", "", null!, false, null,
      string.Empty)
    {
      IsExportMetadata = true,
      IsModule = false,
      IsInlineSimpleProperty = false,
      IsPreventDebugObject = true,
      IsCommentsDisabled = true
    };

    // Collect required paths and compile
    var coreSystemFiles = CoreSystemProvider.GetCoreSystemFiles(CSharpLua.CoreSystem.Wc3Api.WCSharp);
    const string blizzardJ = "../../../../../build/blizzard.j";
    const string commonJ = "../../../../../build/common.j";
    var mapScriptBuilder = new MapScriptBuilder();
    mapScriptBuilder.SetDefaultOptionsForCSharpLua();
    mapScriptBuilder.ForceGenerateGlobalDestructableVariable = false;

    var compileResult = map.CompileScript(compiler, mapScriptBuilder, coreSystemFiles, blizzardJ, commonJ);

    // If compilation failed, output an error
    if (!compileResult.Success)
    {
      throw new Exception(compileResult.Diagnostics.First(x => x.Severity == DiagnosticSeverity.Error).GetMessage());
    }

    // Update war3map.lua so you can inspect the generated Lua code easily
    Directory.CreateDirectory(options.ScriptArtifactPath);
    File.WriteAllText(Path.Combine(options.ScriptArtifactPath, MapDataPaths.ScriptPath), map.Script);
  }

  private static void BackupFiles(string backupDirectory, string mapPath)
  {
    if (File.Exists(mapPath))
    {
      Directory.CreateDirectory(backupDirectory);
      var backupName = $"{Path.GetFileNameWithoutExtension(mapPath)}-{DateTime.Now:yyyyMMdd_HHmmss}.w3x";
      File.Copy(mapPath, Path.Combine(backupDirectory, backupName));
    }

    if (Directory.Exists(mapPath))
    {
      Directory.CreateDirectory(backupDirectory);
      var backupName = $"{Path.GetFileNameWithoutExtension(mapPath)}-{DateTime.Now:yyyyMMdd_HHmmss}.w3x";
      DirectoryUtils.CopyDirectory(mapPath, Path.Combine(backupDirectory, backupName), true);
    }
  }

  private static void LaunchGame(string warcraft3ExecutablePath, string mapFilePath)
  {
    if (File.Exists(warcraft3ExecutablePath))
    {
      Console.WriteLine("Launching map in Warcraft 3...");
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
      throw new InvalidOperationException(
        "Please set Warcraft3ExecutablePath in Launcher/appsettings.json to the path of your Warcraft III executable.");
    }
  }
}
