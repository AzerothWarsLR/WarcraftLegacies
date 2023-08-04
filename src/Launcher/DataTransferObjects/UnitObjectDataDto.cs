namespace Launcher.DataTransferObjects
{
  public class UnitObjectDataDto
  {
    public int FormatVersion { get; set; }
    public BaseUnits[] BaseUnits { get; set; }
    public NewUnits[] NewUnits { get; set; }
  }

  public class BaseUnits
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public Modifications[] Modifications { get; set; }
  }

  public class Modifications
  {
    public int Id { get; set; }
    public int Type { get; set; }
    public object Value { get; set; }
  }

  public class NewUnits
  {
    public int OldId { get; set; }
    public int NewId { get; set; }
    public int[] Unk { get; set; }
    public ModificationDto[] Modifications { get; set; }
  }
}