using System.Collections.Generic;
using War3Net.Build.Script;

namespace Launcher.DataTransferObjects
{
  public class MapTriggersDto
  {
    public int FormatVersion { get; set; }
    public int SubVersion { get; set; }
    public int GameVersion { get; set; }
    public object[] Variables { get; set; }
    public TriggerItemDto[] TriggerItems { get; set; }
    public Dictionary<TriggerItemType, int> TriggerItemCounts { get; set; }
  }

  public class TriggerItemDto
  {
    public string Name { get; set; }
    public int Id { get; set; }
    public int ParentId { get; set; }
  }
}