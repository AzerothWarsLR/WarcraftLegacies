namespace Launcher.DataTransferObjects
{
  public class ItemObjectDataDto
  {
    public int FormatVersion { get; set; }
    public BaseItems[] BaseItems { get; set; }
    public NewItems[] NewItems { get; set; }
  }

  public class BaseItems
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public ModificationDto[] Modifications { get; set; }
  }

  public class NewItems
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public ModificationDto Modifications { get; set; }
  }
}