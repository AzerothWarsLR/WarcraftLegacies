namespace Launcher
{
  public sealed class MapSettings
  {
    /// <summary>
    /// The name of the published map.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// The current version of the map that players can see, e.g. "2.4.0".
    /// </summary>
    public string Version { get; set; }
  }
}