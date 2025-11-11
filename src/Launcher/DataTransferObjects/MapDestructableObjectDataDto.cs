using War3Net.Build.Object;

namespace Launcher.DataTransferObjects;

public class MapDestructableObjectDataDto
{
  public int FormatVersion { get; set; }

  public SimpleObjectModification[] Destructables { get; set; }
}
