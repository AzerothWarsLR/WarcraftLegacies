namespace Launcher.DataTransferObjects
{
  public class MapDestructableObjectDataDto
  {
    public int FormatVersion { get; set; }
    public BaseDestructables[] BaseDestructables { get; set; }
    public NewDestructables[] NewDestructables { get; set; }
  }

  public class BaseDestructables
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public Modifications[] Modifications { get; set; }
  }

  public class NewDestructables
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public ModificationDto[] Modifications { get; set; }
  }
}