using System.IO;
using Launcher.Settings;

namespace Launcher.Services;

public sealed class SharedPathOptions
{
  /// <summary>
  /// Creates a default <see cref="SharedPathOptions"/> based on highly opinionated path conventions.
  /// </summary>
  public static SharedPathOptions Create(string mapName, bool publish = false)
  {
    var settings = AppSettings.Current;
    var rootPath = settings.CompilerSettings.RootPath;
    var options = new SharedPathOptions
    {
      OutputPath = publish
        ? Path.Combine(rootPath, PathConventions.PublishedPath, $"{mapName}.w3x")
        : Path.Combine(rootPath, PathConventions.MapsPath, $"{mapName}.w3x"),
      CsProjPath = Path.Combine(rootPath, PathConventions.SrcPath, $"{mapName}{PathConventions.SourceProjectSuffix}", $"{mapName}{PathConventions.SourceProjectSuffix}.csproj"),
      BackupPath = Path.Combine(rootPath, PathConventions.BackupsPath),
      ScriptArtifactPath = Path.Combine(rootPath, PathConventions.ArtifactsPath),
      Warcraft3ExecutablePath = settings.CompilerSettings.Warcraft3ExecutablePath,
      MapDataPath = Path.Combine(settings.CompilerSettings.RootPath, PathConventions.MapDataPath, mapName),
    };
    return options;
  }

  /// <summary>
  /// Path to the file or folder in which to write the fully built map.
  /// </summary>
  public required string OutputPath { get; set; }

  /// <summary>
  /// Location of the main .NET project containing the map's code.
  /// </summary>
  public required string CsProjPath { get; set; }

  /// <summary>
  /// Path to the preferred backup folder.
  /// </summary>
  public required string BackupPath { get; set; }

  /// <summary>
  /// Path to the folder the war3map.lua should be copied to for later inspection.
  /// </summary>
  public required string ScriptArtifactPath { get; set; }

  /// <summary>
  /// Path to the folder where this project's Json data is stored.
  /// </summary>
  public required string MapDataPath { get; set; }

  /// <summary>
  /// Path to the Warcraft III executable.
  /// </summary>
  public required string Warcraft3ExecutablePath { get; set; }
}
