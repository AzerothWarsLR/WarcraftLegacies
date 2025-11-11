using War3Net.Build.Object;

namespace Launcher.DataTransferObjects;

public class MapItemObjectDataDto
{
  public int FormatVersion { get; set; }

  public SimpleObjectModification[] Items { get; set; }
}
