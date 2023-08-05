namespace Launcher.DataTransferObjects
{
  public sealed class MapDoodadsDto
  {
    public int FormatVersion { get; set; }
    public int SubVersion { get; set; }
    public bool UseNewFormat { get; set; }
    public DoodadDataDto[] Doodads { get; set; }
    public int SpecialDoodadVersion { get; set; }
    public object[] SpecialDoodads { get; set; }
  }
}