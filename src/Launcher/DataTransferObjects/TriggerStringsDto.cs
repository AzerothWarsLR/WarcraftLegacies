namespace Launcher.DataTransferObjects
{
  public class TriggerStringsDto
  {
    public StringsDto[] Strings { get; set; }
  }

  public class StringsDto
  {
    public int EmptyLineCount { get; set; }
    public int Key { get; set; }
    public int KeyPrecision { get; set; }
    public string Comment { get; set; }
    public string Value { get; set; }
  }
}