namespace Launcher.DataTransferObjects
{
  public class CustomTextTriggersDto
  {
    public int FormatVersion { get; set; }
    public int SubVersion { get; set; }
    public string GlobalCustomScriptComment { get; set; }
    public GlobalCustomScriptCode GlobalCustomScriptCode { get; set; }
    public object[] CustomTextTriggers { get; set; }
  }

  public class GlobalCustomScriptCode
  {
    public string Code { get; set; }
  }
}