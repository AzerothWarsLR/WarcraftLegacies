using War3Net.Build.Script;

namespace Launcher.DataTransferObjects
{
  public class MapCustomTextTriggersDto
  {
    public int FormatVersion { get; set; }
    public int SubVersion { get; set; }
    public string GlobalCustomScriptComment { get; set; }
    public CustomTextTrigger GlobalCustomScriptCode { get; set; }
    public object[] CustomTextTriggers { get; set; }
  }
}