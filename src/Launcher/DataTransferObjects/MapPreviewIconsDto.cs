using System.Collections.Generic;
using War3Net.Build.Environment;

namespace Launcher.DataTransferObjects;

public class MapPreviewIconsDto
{
  public int FormatVersion { get; set; }
  public List<PreviewIcon> Icons { get; set; }
}
