using System.Drawing;
using System.Numerics;
using AutoMapper;
using Launcher.DataTransferObjects;
using Launcher.ValueResolvers;
using War3Net.Build.Audio;
using War3Net.Build.Common;
using War3Net.Build.Environment;
using War3Net.Build.Info;
using War3Net.Build.Widget;
using Region = War3Net.Build.Environment.Region;

namespace Launcher.Services;

public sealed class AutoMapperConfigurationProvider
{
  public static MapperConfiguration GetConfiguration()
  {
    var autoMapperConfig = new MapperConfiguration(cfg =>
    {
      cfg.CreateMap<MapEnvironmentDto, MapEnvironment>()
        .ForMember(dest => dest.TerrainTiles,
          opt => opt.MapFrom<TerrainTileResolver>())
        .ReverseMap();
      cfg.CreateMap<MapInfoDto, MapInfo>().ReverseMap();
      cfg.CreateMap<MapPathingMapDto, MapPathingMap>().ReverseMap();
      cfg.CreateMap<MapPreviewIconsDto, MapPreviewIcons>().ReverseMap();
      cfg.CreateMap<QuadrilateralDto, Quadrilateral>().ReverseMap();
      cfg.CreateMap<MapShadowMapDto, MapShadowMap>().ReverseMap();

      cfg.CreateMap<SoundDto, Sound>().ReverseMap();
      cfg.CreateMap<PlayerDataDto, PlayerData>().ReverseMap();
      cfg.CreateMap<TerrainTileDto, TerrainTile>().ReverseMap();
      cfg.CreateMap<UnitData, UnitDataDto>().ForMember(dest => dest.Position, opt
        => opt.MapFrom<UnitDataDtoZPositionValueResolver>());
      cfg.CreateMap<UnitDataDto, UnitData>().ForMember(dest => dest.Position, opt
        => opt.MapFrom<UnitDataZPositionValueResolver>());
      cfg.CreateMap<DoodadDataDto, DoodadData>().ReverseMap();
      cfg.CreateMap<Vector3Dto, Vector3>().ReverseMap();
      cfg.CreateMap<Vector2Dto, Vector2>().ReverseMap();
      cfg.CreateMap<ColorDto, Color>().ReverseMap();
      cfg.CreateMap<RegionDto, Region>()
        .ForMember(dest => dest.Color, opt
        => opt.MapFrom<ColorValueResolver>())
        .ReverseMap();
      cfg.CreateMap<ForceDataDto, ForceData>().ReverseMap();
      cfg.CreateMap<UpgradeDataDto, UpgradeData>().ReverseMap();
      cfg.CreateMap<TechDataDto, TechData>().ReverseMap();
    });
    return autoMapperConfig;
  }
}
