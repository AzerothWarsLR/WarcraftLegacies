using War3Net.Build.Environment;

namespace Launcher.DataTransferObjects
{
  public class MapRegionsDto
  {
    public int FormatVersion { get; set; }
    public bool Protected { get; set; }
    public Region[] Regions { get; set; }
  }
}