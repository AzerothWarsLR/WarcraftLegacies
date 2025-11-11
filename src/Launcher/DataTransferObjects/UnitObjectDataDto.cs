using War3Net.Build.Object;

namespace Launcher.DataTransferObjects;

public sealed class UnitObjectDataDto
{
  public int FormatVersion { get; init; }

  public SimpleObjectModification[] Units { get; init; }
}
