using War3Net.Build.Object;

namespace Launcher.DataTransferObjects;

public class MapAbilityObjectDataDto
{
  public int FormatVersion { get; set; }
  public LevelObjectModification[] BaseAbilities { get; set; }
  public LevelObjectModification[] NewAbilities { get; set; }
}
