using War3Net.Build.Object;

namespace Launcher.DataTransferObjects;

public class MapDoodadObjectDataDto
{
  public int FormatVersion { get; set; }
  public VariationObjectModification[] BaseDoodads { get; set; }
  public VariationObjectModification[] NewDoodads { get; set; }
}
