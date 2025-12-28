namespace WarcraftLegacies.CLI.Settings;

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
  /// Where the root of the Warcraft III project exists in relation to this WarcraftLegacies.CLI executable.
  /// </summary>
  public string RootPath { get; init; }
}
