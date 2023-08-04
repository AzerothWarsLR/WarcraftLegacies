namespace Launcher.DataTransferObjects
{
  public class BuffObjectDataDto
  {
    public int FormatVersion { get; set; }
    public BaseBuffs[] BaseBuffs { get; set; }
    public NewBuffs[] NewBuffs { get; set; }
  }

  public class BaseBuffs
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public object[] Modifications { get; set; }
  }

  public class NewBuffs
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public ModificationDto[] Modifications { get; set; }
  }
}