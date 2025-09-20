using War3Net.Build.Object;

namespace Launcher.DataTransferObjects;

public class MapItemObjectDataDto
{
  public int FormatVersion { get; set; }
  public SimpleObjectModification[] BaseItems { get; set; }
  public SimpleObjectModification[] NewItems { get; set; }
}
