using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Launcher.DataTransferObjects;
using War3Net.Build.Environment;

namespace Launcher.ValueResolvers;

public sealed class TerrainTileResolver : IValueResolver<MapEnvironmentDto, MapEnvironment, List<TerrainTile>>
{
  public List<TerrainTile> Resolve(MapEnvironmentDto source, MapEnvironment destination, List<TerrainTile> destMember, ResolutionContext context)
  {
    return source.TerrainTiles.Select(dto => new TerrainTile((MapEnvironmentFormatVersion)source.FormatVersion)
    {
      Height = dto.Height,
      WaterHeight = dto.WaterHeight,
      IsEdgeTile = dto.IsEdgeTile,
      Texture = dto.Texture,
      IsRamp = dto.IsRamp,
      IsBlighted = dto.IsBlighted,
      IsWater = dto.IsWater,
      IsBoundary = dto.IsBoundary,
      Variation = dto.Variation,
      CliffVariation = dto.CliffVariation,
      CliffLevel = dto.CliffLevel,
      CliffTexture = dto.CliffTexture
    }).ToList();
  }
}