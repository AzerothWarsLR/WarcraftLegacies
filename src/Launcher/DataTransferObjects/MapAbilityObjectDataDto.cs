using War3Net.Build.Object;

namespace Launcher.DataTransferObjects;

public class MapAbilityObjectDataDto
{
  public int FormatVersion { get; set; }

  public LevelObjectModification[] Abilities { get; set; }
}
