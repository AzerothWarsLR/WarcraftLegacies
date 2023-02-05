namespace Launcher
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
    
    /// <summary>
    /// The folder where you want the published map to be saved to.
    /// </summary>
    public string OutputFolderPath { get; set; }

    /// <summary>
    /// The name of the seperate map script that gets saved in <see cref="OutputFolderPath"/>.
    /// </summary>
    public string OutputScriptName { get; set; }
    
    /// <summary>
    /// All files in this folder will be added to the published map.
    /// </summary>
    public string AssetsFolderPath { get; set; }
  }
}