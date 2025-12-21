#nullable enable

using Launcher.Settings;

namespace Launcher.Services;

public sealed class AdvancedMapBuilderOptions
{
  /// <summary>
  /// Creates a default <see cref="AdvancedMapBuilderOptions"/> from a set of path options shared with the whole project.
  /// </summary>
  public static AdvancedMapBuilderOptions Create(SharedPathOptions sharedPathOptions)
  {
    var settings = AppSettings.Current;
    var options = new AdvancedMapBuilderOptions
    {
      OutputPath = sharedPathOptions.OutputPath,
      CsProjPath = sharedPathOptions.CsProjPath,
      BackupPath = sharedPathOptions.BackupPath,
      ScriptArtifactPath = sharedPathOptions.ScriptArtifactPath,
      Warcraft3ExecutablePath = sharedPathOptions.Warcraft3ExecutablePath,
      Version = settings.MapSettings.Version
    };
    return options;
  }

  /// <summary>
  /// Creates a default <see cref="AdvancedMapBuilderOptions"/> from a set of path options shared with the whole project,
  /// using the map name to derive some paths.
  /// </summary>
  public static AdvancedMapBuilderOptions Create(string mapName)
  {
    var settings = AppSettings.Current;
    var sharedPathOptions = SharedPathOptions.Create(mapName);
    var options = new AdvancedMapBuilderOptions
    {
      OutputPath = sharedPathOptions.OutputPath,
      CsProjPath = sharedPathOptions.CsProjPath,
      BackupPath = sharedPathOptions.BackupPath,
      ScriptArtifactPath = sharedPathOptions.ScriptArtifactPath,
      Warcraft3ExecutablePath = sharedPathOptions.Warcraft3ExecutablePath,
      Version = settings.MapSettings.Version
    };
    return options;
  }

  /// <summary>
  /// Path to the file or folder in which to write the fully built map.
  /// </summary>
  public required string OutputPath { get; set; }

  /// <summary>
  /// Location of the main .NET project containing the map's code. If  supplied, it will be transpiled to Lua.
  /// </summary>
  public required string CsProjPath { get; set; }

  /// <summary>
  /// Path to the preferred backup folder. If provided, maps that would otherwise be overwritten are moved here instead.
  /// </summary>
  public required string BackupPath { get; set; }

  /// <summary>
  /// Path to the folder the war3map.lua should be copied to for later inspection.
  /// </summary>
  public required string ScriptArtifactPath { get; set; }

  /// <summary>
  /// Path to the Warcraft III executable. If provided, the map will be launched after building.
  /// </summary>
  public required string Warcraft3ExecutablePath { get; set; }

  /// <summary>
  /// Version number to be appended to the map title and loading screen.
  /// </summary>
  public required string Version { get; set; }

  /// <summary>
  /// If true, all object data migrations will be applied to the map during build.
  /// </summary>
  public bool ShouldMigrate { get; set; }

  /// <summary>
  /// If true, the project at <see cref="CsProjPath"/> will be converted to Lua and included in the map script.
  /// </summary>
  public bool ShouldTranspile { get; set; }

  /// <summary>
  /// If true, maps that would be overwritten by the build process are instead moved to <see cref="BackupPath"/>.
  /// </summary>
  public bool ShouldBackup { get; set; }

  /// <summary>
  /// If true, the configured version <see cref="Version"/> will be appended to the map title and loading screen.
  /// </summary>
  public bool ShouldSetVersion { get; set; }

  /// <summary>
  /// If true, the map will be launched in Warcraft 3 after building from the <see cref="Warcraft3ExecutablePath"/>,
  /// and the testing player slot will be set to <see cref="TestingPlayerSlot"/>.
  /// </summary>
  public bool ShouldLaunch { get; set; }

  /// <summary>
  /// If non-zero, all player slots before this will be filled with computers so that the testing player occupies
  /// this slot by default.
  /// </summary>
  public int TestingPlayerSlot { get; set; }
}
