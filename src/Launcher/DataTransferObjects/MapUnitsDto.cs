using War3Net.Build.Widget;

namespace Launcher.DataTransferObjects
{
  public class MapUnitsDto
  {
    public int FormatVersion { get; set; }
    public int SubVersion { get; set; }
    public bool UseNewFormat { get; set; }
    public UnitData[] Units { get; set; }
  }
}