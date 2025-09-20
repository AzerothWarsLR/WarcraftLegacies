using War3Net.Build.Info;

namespace Launcher.DataTransferObjects;

public sealed class ForceDataDto
{
  public ForceFlags Flags { get; set; }

  public int Players { get; set; }

  public string Name { get; set; }
}
