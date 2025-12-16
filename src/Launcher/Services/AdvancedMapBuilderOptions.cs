#nullable enable

using System.IO;

namespace Launcher.Services;

public sealed class AdvancedMapBuilderOptions(string rootPath, string mapName)
{
  /// <summary>
  /// Path to the file or folder in which to write the fully built map.
  /// </summary>
  public string OutputPath { get; init; } = Path.Combine(rootPath, PathConventions.MapsPath, $"{mapName}.w3x");

  /// <summary>
  /// Location of the main .NET project containing the map's code. If  supplied, it will be transpiled to Lua.
  /// </summary>
  public string CsProjPath { get; init; } = Path.Combine(rootPath, PathConventions.SrcPath, $"{mapName}{PathConventions.SourceProjectSuffix}", $"{mapName}{PathConventions.SourceProjectSuffix}.csproj");

  /// <summary>
  /// Path to the preferred backup folder. If provided, maps that would otherwise be overwritten are moved here instead.
  /// </summary>
  public string BackupPath { get; init; } = Path.Combine(rootPath, PathConventions.BackupsPath);

  /// <summary>
  /// Path to the folder the war3map.lua should be copied to for later inspection.
  /// </summary>
  public string ScriptArtifactPath { get; init; } = Path.Combine(rootPath, PathConventions.ArtifactsPath);

  /// <summary>
  /// Path to the Warcraft III executable. If provided, the map will be launched after building.
  /// </summary>
  public string? Warcraft3ExecutablePath { get; init; }

  /// <summary>
  /// Version number to be appended to the map title and loading screen.
  /// </summary>
  public string? Version { get; init; }

  /// <summary>
  /// If true, all object data migrations will be applied to the map during build.
  /// </summary>
  public bool ShouldMigrate { get; init; }

  /// <summary>
  /// If true, the project at <see cref="CsProjPath"/> will be converted to Lua and included in the map script.
  /// </summary>
  public bool ShouldTranspile { get; init; }

  /// <summary>
  /// If true, maps that would be overwritten by the build process are instead moved to <see cref="BackupPath"/>.
  /// </summary>
  public bool ShouldBackup { get; init; }

  /// <summary>
  /// If non-zero, all player slots before this will be filled with computers so that the testing player occupies
  /// this slot by default.
  /// </summary>
  public int TestingPlayerSlot { get; init; }
}
