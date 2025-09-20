using System.Collections.Generic;
using War3Net.Build.Script;

namespace Launcher.DataTransferObjects;

public sealed class MapTriggersDto
{
  public int FormatVersion { get; set; }
  public int SubVersion { get; set; }
  public int GameVersion { get; set; }
  public object[] Variables { get; set; }
  public TriggerItemDto[] TriggerItems { get; set; }
  public Dictionary<TriggerItemType, int> TriggerItemCounts { get; set; }
}
