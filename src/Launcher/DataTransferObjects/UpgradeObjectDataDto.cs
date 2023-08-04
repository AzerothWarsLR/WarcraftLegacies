namespace Launcher.DataTransferObjects
{
  public class RootObject
  {
    public int FormatVersion { get; set; }
    public BaseUpgrades[] BaseUpgrades { get; set; }
    public NewUpgrades[] NewUpgrades { get; set; }
  }

  public class BaseUpgrades
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public ModificationDto[] Modifications { get; set; }
  }

  public class NewUpgrades
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public ModificationDto[] Modifications { get; set; }
  }
}