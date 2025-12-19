using System.IO;
using Launcher.Settings;

namespace Launcher.Services;

public sealed class SharedPathOptions
{
  /// <summary>
  /// Creates a default <see cref="SharedPathOptions"/> based on highly opinionated path conventions.
  /// </summary>
  public static SharedPathOptions Create(string mapName)
  {
    var settings = AppSettings.Current;
    var rootPath = settings.CompilerSettings.RootPath;
    var options = new SharedPathOptions
    {
      W3XFolderPath = Path.Combine(rootPath, PathConventions.MapsPath, $"{mapName}.w3x"),
      PublishPath = Path.Combine(rootPath, PathConventions.PublishedPath, $"{mapName}.w3x"),
      CsProjPath = Path.Combine(rootPath, PathConventions.SrcPath, $"{mapName}{PathConventions.SourceProjectSuffix}", $"{mapName}{PathConventions.SourceProjectSuffix}.csproj"),
      BackupPath = Path.Combine(rootPath, PathConventions.BackupsPath),
      ScriptArtifactPath = Path.Combine(rootPath, PathConventions.ArtifactsPath),
      Warcraft3ExecutablePath = settings.CompilerSettings.Warcraft3ExecutablePath,
      MapDataPath = Path.Combine(settings.CompilerSettings.RootPath, PathConventions.MapDataPath, mapName),
      SourceProjectPath = Path.Combine(rootPath, PathConventions.SrcPath, $"{mapName}{PathConventions.SourceProjectSuffix}"),
      SharedProjectPath = Path.Combine(rootPath, PathConventions.SrcPath, $"{mapName}{PathConventions.SharedProjectSuffix}")
    };
    return options;
  }

  /// <summary>
  /// Path to the folder in which to write the fully built map.
  /// </summary>
  public required string W3XFolderPath { get; init; }

  /// <summary>
  /// Path to the file in which to write published, ready-to-release maps.
  /// </summary>
  public required string PublishPath { get; init; }

  /// <summary>
  /// Location of the main .NET project containing the map's code.
  /// </summary>
  public required string CsProjPath { get; init; }

  /// <summary>
  /// Path to the preferred backup folder.
  /// </summary>
  public required string BackupPath { get; init; }

  /// <summary>
  /// Path to the folder the war3map.lua should be copied to for later inspection.
  /// </summary>
  public required string ScriptArtifactPath { get; init; }

  /// <summary>
  /// Path to the folder where this project's Json data is stored.
  /// </summary>
  public required string MapDataPath { get; init; }

  /// <summary>
  /// Path to the Warcraft III executable.
  /// </summary>
  public required string Warcraft3ExecutablePath { get; init; }

  /// <summary>
  ///  Folder path in which the map's main C# files are stored.
  /// </summary>
  public required string SourceProjectPath { get; init; }

  /// <summary>
  ///  Folder path in which the map's shared C# files are stored.
  /// </summary>
  public required string SharedProjectPath { get; init; }
}
