using System.Collections.Generic;
using War3Net.Build.Environment;

namespace Launcher.DataTransferObjects;

public sealed class MapPathingMapDto
{
  public int FormatVersion { get; set; }
  public int Width { get; set; }
  public int Height { get; set; }
  public List<PathingType> Cells { get; set; }
}
