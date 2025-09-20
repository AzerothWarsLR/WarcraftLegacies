#nullable enable

namespace Launcher.Services;

public sealed class AdvancedMapBuilderOptions
{
  /// <summary>
  /// What to call the resulting map file.
  /// </summary>
  public string MapName { get; init; }

  /// <summary>
  /// Where the final map will be saved to.
  /// </summary>
  public string OutputDirectory { get; init; }

  /// <summary>
  /// C# code in this directory will be transpiled to Lua and included in the map.
  /// </summary>
  public string? SourceCodeProjectFolderPath { get; init; }

  /// <summary>
  /// Whether or not to set the output map's title, loading screen title, and file name.
  /// </summary>
  public bool SetMapTitles { get; init; }

  /// <summary>
  /// Whether or not to launch the map after building.
  /// </summary>
  public bool Launch { get; init; }

  /// <summary>
  /// Any overwritten maps will be moved to this directory instead of being deleted.
  /// </summary>
  public string? BackupDirectory { get; init; }
}
