using System.Collections.Generic;
using War3Net.Build.Script;

namespace Launcher.DataTransferObjects;

public sealed class TriggerItemDto
{
  public string Name { get; set; }
  public int Id { get; set; }
  public int ParentId { get; set; }
  public TriggerItemType Type { get; set; }
  public string IsDescription { get; set; }
  public bool IsComment { get; set; }
  public bool IsEnabled { get; set; }
  public bool IsCustomTextTrigger { get; set; }
  public bool IsInitiallyOn { get; set; }
  public bool RunOnMapInit { get; set; }
  public List<TriggerFunction> Functions { get; set; }
}
