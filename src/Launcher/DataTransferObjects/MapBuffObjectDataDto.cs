using War3Net.Build.Object;

namespace Launcher.DataTransferObjects;

public class MapBuffObjectDataDto
{
  public int FormatVersion { get; set; }

  public SimpleObjectModification[] Buffs { get; set; }
}
