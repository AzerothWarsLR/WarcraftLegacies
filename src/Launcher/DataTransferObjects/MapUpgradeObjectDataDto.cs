using War3Net.Build.Object;

namespace Launcher.DataTransferObjects;

public class MapUpgradeObjectDataDto
{
  public int FormatVersion { get; set; }
  public LevelObjectModification[] BaseUpgrades { get; set; }
  public LevelObjectModification[] NewUpgrades { get; set; }
}
