namespace Launcher.DataTransferObjects
{
  public class MapDoodadsDataDto
  {
    public int FormatVersion { get; set; }
    public int SubVersion { get; set; }
    public bool UseNewFormat { get; set; }
    public MapDoodadsDto[] Doodads { get; set; }
    public int SpecialDoodadVersion { get; set; }
    public object[] SpecialDoodads { get; set; }
  }

  public class MapDoodadsDto
  {
    public int State { get; set; }
    public int Life { get; set; }
    public int TypeId { get; set; }
    public int Variation { get; set; }
    public Position Position { get; set; }
    public double Rotation { get; set; }
    public Scale Scale { get; set; }
    public int SkinId { get; set; }
    public int MapItemTableId { get; set; }
    public object[] ItemTableSets { get; set; }
    public int CreationNumber { get; set; }
  }
}