using War3Net.Build.Info;

namespace Launcher.DataTransferObjects;

public sealed class UpgradeDataDto
{
  public int Players { get; set; }

  public int Id { get; set; }

  public int Level { get; set; }

  public UpgradeAvailability Availability { get; set; }
}
