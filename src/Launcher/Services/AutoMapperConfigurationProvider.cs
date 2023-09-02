using System;
using System.Drawing;
using System.Linq;
using System.Numerics;
using AutoMapper;
using Launcher.DataTransferObjects;
using Launcher.ValueResolvers;
using War3Api.Object;
using War3Net.Build.Audio;
using War3Net.Build.Common;
using War3Net.Build.Environment;
using War3Net.Build.Import;
using War3Net.Build.Info;
using War3Net.Build.Object;
using War3Net.Build.Script;
using War3Net.Build.Widget;
using Region = War3Net.Build.Environment.Region;
using UnitDto = Launcher.DataTransferObjects.War3Api.Object.UnitDto;

namespace Launcher.Services
{
  public sealed class AutoMapperConfigurationProvider
  {
    public MapperConfiguration GetConfiguration()
    {
      var autoMapperConfig = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<MapAbilityObjectDataDto, AbilityObjectData>().ReverseMap();
        cfg.CreateMap<MapBuffObjectDataDto, BuffObjectData>().ReverseMap();
        cfg.CreateMap<MapCustomTextTriggersDto, MapCustomTextTriggers>().ReverseMap();
        cfg.CreateMap<MapDestructableObjectDataDto,DestructableObjectData>().ReverseMap();
        cfg.CreateMap<MapDoodadObjectDataDto, DoodadObjectData>().ReverseMap();
        cfg.CreateMap<MapDoodadsDto, MapDoodads>().ReverseMap();
        cfg.CreateMap<MapEnvironmentDto, MapEnvironment>().ReverseMap();
        cfg.CreateMap<MapImportedFilesDto, ImportedFiles>().ReverseMap();
        cfg.CreateMap<MapItemObjectDataDto, ItemObjectData>().ReverseMap();
        cfg.CreateMap<MapInfoDto, MapInfo>().ReverseMap();
        cfg.CreateMap<MapRegionsDto, MapRegions>().ReverseMap();
        cfg.CreateMap<MapUnitsDto, MapUnits>().ReverseMap();
        cfg.CreateMap<MapPathingMapDto, MapPathingMap>().ReverseMap();
        cfg.CreateMap<MapPreviewIconsDto, MapPreviewIcons>().ReverseMap();
        cfg.CreateMap<QuadrilateralDto, Quadrilateral>().ReverseMap();
        cfg.CreateMap<MapShadowMapDto, MapShadowMap>().ReverseMap();
        cfg.CreateMap<MapSoundsDto, MapSounds>().ReverseMap();
        cfg.CreateMap<MapTriggerStringsDto, TriggerStrings>().ReverseMap();
        cfg.CreateMap<MapUnitObjectDataDto, UnitObjectData>().ReverseMap();
        cfg.CreateMap<MapUpgradeObjectDataDto, UpgradeObjectData>().ReverseMap();
        cfg.CreateMap<MapTriggersDto, MapTriggers>()
          .ForMember(dest => dest.TriggerItems, opt 
            => opt.MapFrom<TriggerItemValueResolver>())
          .ReverseMap();

        cfg.CreateMap<SoundDto, Sound>().ReverseMap();
        cfg.CreateMap<PlayerDataDto, PlayerData>().ReverseMap();
        cfg.CreateMap<TerrainTileDto, TerrainTile>().ReverseMap();
        cfg.CreateMap<UnitDataDto, UnitData>().ReverseMap();
        cfg.CreateMap<DoodadDataDto, DoodadData>().ReverseMap();
        cfg.CreateMap<Vector3Dto, Vector3>().ReverseMap();
        cfg.CreateMap<Vector2Dto, Vector2>().ReverseMap();
        cfg.CreateMap<ColorDto, Color>().ReverseMap();
        cfg.CreateMap<RegionDto, Region>()
          .ForMember(dest => dest.Color, opt
          => opt.MapFrom<ColorValueResolver>())
          .ReverseMap();
        cfg.CreateMap<TriggerItemDto, TriggerItem>().ReverseMap();
        
        cfg.CreateMap<Unit, UnitDto>().ForAllMembers(GetUnitPreCondition());
      });
      return autoMapperConfig;
    }

    private static Action<IMemberConfigurationExpression<Unit, UnitDto, object>> GetUnitPreCondition()
    {
      return x => x.PreCondition((source, _) =>
      {
        var destinationMemberName = x.DestinationMember.Name;
        var isModifiedName = $"Is{destinationMemberName}Modified";
        var isModifiedProperty = typeof(Unit).GetProperty(isModifiedName);
          
        if (isModifiedProperty == null)
          return false;

        if (isModifiedProperty.GetMethod == null)
          return false;

        var allProperties = typeof(Unit).GetProperties();
        if (allProperties.Select(property => property.Name).Contains($"{destinationMemberName}Raw"))
          return false;

        if (destinationMemberName == "Modifications")
          return false;
          
        var result = isModifiedProperty.GetMethod.Invoke(source, null);
        if (result == null)
          return false;
          
        var isModified = (bool)result;
        return isModified;
      });
    }
  }
}