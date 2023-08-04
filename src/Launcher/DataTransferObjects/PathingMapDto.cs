namespace Launcher.DataTransferObjects;

public sealed class PathingMapDto
{
  public int FormatVersion { get; set; }
  public int Width { get; set; }
  public int Height { get; set; }
  public int[] Cells { get; set; }
}