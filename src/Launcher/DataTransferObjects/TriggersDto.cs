namespace Launcher.DataTransferObjects
{
  public class MapTriggersDto
  {
    public int FormatVersion { get; set; }
    public int SubVersion { get; set; }
    public int GameVersion { get; set; }
    public object[] Variables { get; set; }
    public TriggerItemDto[] TriggerItems { get; set; }
    public TriggerItemCounts TriggerItemCounts { get; set; }
  }

  public class TriggerItemDto
  {
    public string Name { get; set; }
    public int Id { get; set; }
    public int ParentId { get; set; }
  }

  public class TriggerItemCounts
  {
    public int RootCategory { get; set; }
    public int UNK1 { get; set; }
    public int Category { get; set; }
    public int Gui { get; set; }
    public int Comment { get; set; }
    public int Script { get; set; }
    public int Variable { get; set; }
    public int UNK7 { get; set; }
  }
}