namespace Launcher.DataTransferObjects
{
  public sealed class MapRegionsDto
  {
    public int FormatVersion { get; set; }
    public bool Protected { get; set; }
    public RegionDto[] Regions { get; set; }
  }
}