namespace WarcraftLegacies.Launcher
{
  public sealed class LaunchSettings
  {
    /// <summary>
    /// The player slot to launch the testing player as.
    /// </summary>
    public int TestingPlayerSlot { get; set; }
    
    /// <summary>
    /// The path to your Warcraft 3 executable.
    /// </summary>
    public string Warcraft3ExecutablePath { get; set; }
  }
}