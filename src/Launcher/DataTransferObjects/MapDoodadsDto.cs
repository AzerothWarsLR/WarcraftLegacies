using War3Net.Build.Widget;

namespace Launcher.DataTransferObjects
{
  public class MapDoodadsDto
  {
    public int FormatVersion { get; set; }
    public int SubVersion { get; set; }
    public bool UseNewFormat { get; set; }
    public DoodadData[] Doodads { get; set; }
    public int SpecialDoodadVersion { get; set; }
    public object[] SpecialDoodads { get; set; }
  }
}