using War3Net.Build.Common;

namespace Launcher.DataTransferObjects;

public sealed class MapEnvironmentDto
{
  public int FormatVersion { get; set; }
  public Tileset Tileset { get; set; }
  public bool IsCustomTileset { get; set; }
  public int[] TerrainTypes { get; set; }
  public int[] CliffTypes { get; set; }
  public int Width { get; set; }
  public int Height { get; set; }
  public int Left { get; set; }
  public int Bottom { get; set; }
  public TerrainTileDto[] TerrainTiles { get; set; }
  public int Right { get; set; }
  public int Top { get; set; }
}

public sealed class TerrainTileDto
{
  public float Height { get; set; }
  public float WaterHeight { get; set; }
  public bool IsEdgeTile { get; set; }
  public int Texture { get; set; }
  public bool IsRamp { get; set; }
  public bool IsBlighted { get; set; }
  public bool IsWater { get; set; }
  public bool IsBoundary { get; set; }
  public int Variation { get; set; }
  public int CliffVariation { get; set; }
  public int CliffLevel { get; set; }
  public int CliffTexture { get; set; }
}
