namespace Launcher.Settings;

public sealed class CompilerSettings
{
  /// <summary>
  /// The player slot to launch the testing player as.
  /// </summary>
  public int TestingPlayerSlot { get; set; }

  /// <summary>
  /// The path to your Warcraft 3 executable.
  /// </summary>
  public string Warcraft3ExecutablePath { get; set; }

  /// <summary>
  /// The folder where artifacts created during launches are stored.
  /// </summary>
  public string ArtifactsPath { get; set; }

  /// <summary>
  /// All files in this folder will be added to the published map.
  /// </summary>
  public string SharedAssetsPath { get; set; }
}
