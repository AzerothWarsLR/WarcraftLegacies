using System.Drawing;
using System.Numerics;
using AutoMapper;
using Launcher.DataTransferObjects;
using Launcher.ValueResolvers;
using War3Net.Build.Audio;
using War3Net.Build.Environment;
using War3Net.Build.Widget;
using Region = War3Net.Build.Environment.Region;

namespace Launcher.Services;

public sealed class AutoMapperConfigurationProvider
{
  public static MapperConfiguration GetConfiguration()
  {
    var autoMapperConfig = new MapperConfiguration(cfg =>
    {
      cfg.CreateMap<MapEnvironmentDto, MapEnvironment>().ReverseMap();
      cfg.CreateMap<MapPathingMapDto, MapPathingMap>().ReverseMap();
      cfg.CreateMap<MapPreviewIconsDto, MapPreviewIcons>().ReverseMap();
      cfg.CreateMap<MapShadowMapDto, MapShadowMap>().ReverseMap();

      cfg.CreateMap<SoundDto, Sound>().ReverseMap();
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
    });
    return autoMapperConfig;
  }
}
