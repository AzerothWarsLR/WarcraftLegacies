using AutoMapper;
using Launcher.DataTransferObjects;
using War3Net.Build.Audio;
using War3Net.Build.Common;
using War3Net.Build.Environment;
using War3Net.Build.Import;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Script;
using War3Net.Build.Widget;

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
        cfg.CreateMap<MapTriggersDto, MapTriggers>().ReverseMap();

        cfg.CreateMap<SoundDto, Sound>().ReverseMap();
        cfg.CreateMap<TerrainTileDto, TerrainTile>().ReverseMap();
        cfg.CreateMap<UnitDataDto, UnitData>().ReverseMap();
      });
      return autoMapperConfig;
    }
  }
}