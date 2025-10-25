namespace Launcher.Settings;

/// <summary>
/// Settings related to the compiler or testing environment.
/// </summary>
public sealed class CompilerSettings
{
  /// <summary>
  /// The player slot to launch the testing player as.
  /// </summary>
  public int TestingPlayerSlot { get; init; }

  /// <summary>
  /// The path to your Warcraft 3 executable.
  /// </summary>
  public string Warcraft3ExecutablePath { get; init; }

  /// <summary>
  /// The folder where artifacts created during launches are stored.
  /// </summary>
  public string ArtifactsPath { get; init; }

  /// <summary>
  /// All files in this folder will be added to the published map.
  /// </summary>
  public string SharedAssetsPath { get; init; }
}
