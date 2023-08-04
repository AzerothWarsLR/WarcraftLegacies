namespace Launcher.DataTransferObjects
{
  public class ModificationDto
  {
    public int Level { get; set; }
    public int Pointer { get; set; }
    public int Id { get; set; }
    public int Type { get; set; }
    public object Value { get; set; }
  }
}