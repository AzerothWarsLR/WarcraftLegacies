namespace Launcher.DataTransferObjects
{
  public class MapAbilityObjectDataDto
  {
    public int FormatVersion { get; set; }
    public BaseAbilities[] BaseAbilities { get; set; }
    public NewAbilities[] NewAbilities { get; set; }
  }

  public class BaseAbilities
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public Modifications[] Modifications { get; set; }
  }

  public class NewAbilities
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public Modifications1[] Modifications { get; set; }
  }

  public class Modifications1
  {
    public int Level { get; set; }
    public int Pointer { get; set; }
    public int Id { get; set; }
    public int Type { get; set; }
    public object Value { get; set; }
  }
}