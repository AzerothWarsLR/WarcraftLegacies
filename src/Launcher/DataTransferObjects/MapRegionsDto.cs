namespace Launcher.DataTransferObjects
{
  public class MapRegionsDto
  {
    public int FormatVersion { get; set; }
    public bool Protected { get; set; }
    public RegionDto[] Regions { get; set; }
  }

  public class RegionDto
  {
    public int Left { get; set; }
    public int Bottom { get; set; }
    public int Right { get; set; }
    public int Top { get; set; }
    public string Name { get; set; }
    public int CreationNumber { get; set; }
    public int WeatherType { get; set; }
    public string AmbientSound { get; set; }
    public Color Color { get; set; }
  }

  public class Color
  {
  }
}