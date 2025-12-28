namespace Warcraft.Cartographer.Paths;

public sealed class SharedPathOptions
{
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

  public required MapDataPathOptions MapDataPathOptions { get; init; }
}
