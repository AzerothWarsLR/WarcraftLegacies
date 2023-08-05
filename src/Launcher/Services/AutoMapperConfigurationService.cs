using System.Drawing;
using System.Numerics;
using AutoMapper;
using Launcher.DataTransferObjects;
using Launcher.ValueResolvers;
using War3Net.Build.Audio;
using War3Net.Build.Common;
using War3Net.Build.Environment;
using War3Net.Build.Import;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Script;
using War3Net.Build.Widget;
using Region = War3Net.Build.Environment.Region;

namespace Launcher.Services
{
  public sealed class AutoMapperConfigurationService
  {
    public MapperConfiguration GetConfiguration()
    {
      var autoMapperConfig = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<MapAbilityObjectDataDto, MapAbilityObjectData>().ReverseMap();
        cfg.CreateMap<MapBuffObjectDataDto, MapBuffObjectData>().ReverseMap();
        cfg.CreateMap<MapCustomTextTriggersDto, MapCustomTextTriggers>().ReverseMap();
        cfg.CreateMap<MapDestructableObjectDataDto, MapDestructableObjectData>().ReverseMap();
        cfg.CreateMap<MapDoodadObjectDataDto, MapDoodadObjectData>().ReverseMap();
        cfg.CreateMap<MapDoodadsDto, MapDoodads>().ReverseMap();
        cfg.CreateMap<MapEnvironmentDto, MapEnvironment>().ReverseMap();
        cfg.CreateMap<MapImportedFilesDto, MapImportedFiles>().ReverseMap();
        cfg.CreateMap<MapItemObjectDataDto, MapItemObjectData>().ReverseMap();
        cfg.CreateMap<MapInfoDto, MapInfo>().ReverseMap();
        cfg.CreateMap<MapRegionsDto, MapRegions>().ReverseMap();
        cfg.CreateMap<MapUnitsDto, MapUnits>().ReverseMap();
        cfg.CreateMap<MapPathingMapDto, MapPathingMap>().ReverseMap();
        cfg.CreateMap<MapPreviewIconsDto, MapPreviewIcons>().ReverseMap();
        cfg.CreateMap<QuadrilateralDto, Quadrilateral>().ReverseMap();
        cfg.CreateMap<MapShadowMapDto, MapShadowMap>().ReverseMap();
        cfg.CreateMap<MapSoundsDto, MapSounds>().ReverseMap();
        cfg.CreateMap<MapTriggerStringsDto, MapTriggerStrings>().ReverseMap();
        cfg.CreateMap<MapUnitObjectDataDto, MapUnitObjectData>().ReverseMap();
        cfg.CreateMap<MapUpgradeObjectDataDto, MapUpgradeObjectData>().ReverseMap();
        cfg.CreateMap<MapTriggersDto, MapTriggers>()
          .ForMember(dest => dest.TriggerItems, opt 
            => opt.MapFrom<TriggerItemValueResolver>())
          .ReverseMap();

        cfg.CreateMap<SoundDto, Sound>().ReverseMap();
        cfg.CreateMap<TerrainTileDto, TerrainTile>().ReverseMap();
        cfg.CreateMap<UnitDataDto, UnitData>().ReverseMap();
        cfg.CreateMap<DoodadDataDto, DoodadData>().ReverseMap();
        cfg.CreateMap<Vector3Dto, Vector3>().ReverseMap();
        cfg.CreateMap<Vector2Dto, Vector2>().ReverseMap();
        cfg.CreateMap<ColorDto, Color>().ReverseMap();
        cfg.CreateMap<RegionDto, Region>().ReverseMap();
        cfg.CreateMap<TriggerItemDto, TriggerItem>().ReverseMap();
      });
      return autoMapperConfig;
    }
  }
}