namespace Launcher.DataTransferObjects
{
  public class DoodadObjectDataDto
  {
    public int FormatVersion { get; set; }
    public BaseDoodads[] BaseDoodads { get; set; }
    public NewDoodads[] NewDoodads { get; set; }
  }

  public class BaseDoodads
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public ModificationDto[] Modifications { get; set; }
  }


  public class NewDoodads
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public ModificationDto[] Modifications { get; set; }
  }
}