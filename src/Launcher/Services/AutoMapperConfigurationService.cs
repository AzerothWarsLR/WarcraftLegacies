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
        cfg.CreateMap<MapAbilityObjectDataDto, MapAbilityObjectData>();
        cfg.CreateMap<MapBuffObjectDataDto, MapBuffObjectData>();
        cfg.CreateMap<MapCustomTextTriggersDto, MapCustomTextTriggers>();
        cfg.CreateMap<MapDestructableObjectDataDto, MapDestructableObjectData>();
        cfg.CreateMap<MapDoodadObjectDataDto, MapDoodadObjectData>();
        cfg.CreateMap<MapDoodadsDto, MapDoodads>();
        cfg.CreateMap<MapEnvironmentDto, MapEnvironment>();
        cfg.CreateMap<MapImportedFilesDto, MapImportedFiles>();
        cfg.CreateMap<MapItemObjectDataDto, MapItemObjectData>();
        cfg.CreateMap<MapInfoDto, MapInfo>();
        cfg.CreateMap<MapRegionsDto, MapRegions>();
        cfg.CreateMap<MapUnitsDto, MapUnits>();
        cfg.CreateMap<MapPathingMapDto, MapPathingMap>();
        cfg.CreateMap<MapPreviewIconsDto, MapPreviewIcons>();
        cfg.CreateMap<QuadrilateralDto, Quadrilateral>();
        cfg.CreateMap<MapShadowMapDto, MapShadowMap>();
        cfg.CreateMap<MapSoundsDto, MapSounds>();
        cfg.CreateMap<MapTriggerStringsDto, MapTriggerStrings>();
        cfg.CreateMap<MapUnitObjectDataDto, MapUnitObjectData>();
        cfg.CreateMap<MapUpgradeObjectDataDto, MapUpgradeObjectData>();
        cfg.CreateMap<MapTriggersDto, MapTriggers>();

        cfg.CreateMap<SoundDto, Sound>();
        cfg.CreateMap<TerrainTileDto, TerrainTile>();
        cfg.CreateMap<UnitDataDto, UnitData>();
      });
      return autoMapperConfig;
    }
  }
}