using War3Net.Build.Object;

namespace Launcher.DataTransferObjects;

public class UnitObjectDataDto
{
  public int FormatVersion { get; set; }
  public SimpleObjectModification[] BaseUnits { get; set; }
  public SimpleObjectModification[] NewUnits { get; set; }
}
