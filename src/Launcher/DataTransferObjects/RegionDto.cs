using War3Net.Build.Common;

namespace Launcher.DataTransferObjects
{
  public sealed class RegionDto
  {
    public float Left { get; set; }

    public float Bottom { get; set; }

    public float Right { get; set; }

    public float Top { get; set; }

    public string Name { get; set; }

    public int CreationNumber { get; set; }

    public WeatherType WeatherType { get; set; }

    public string AmbientSound { get; set; }

    public ColorDto Color { get; set; }
  }
}