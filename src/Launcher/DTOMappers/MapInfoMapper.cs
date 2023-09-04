using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Launcher.DataTransferObjects;
using War3Net.Build.Common;
using War3Net.Build.Info;

namespace Launcher.DTOMappers
{
  public sealed class MapInfoMapper
  {
    private readonly Dictionary<uint, string> _triggerStrings;

    public MapInfoMapper(Dictionary<uint, string> triggerStrings)
    {
      _triggerStrings = triggerStrings;
    }
    
    public MapInfoDto MapToDto(MapInfo mapInfo)
    {
      var dto = new MapInfoDto
      {
        FormatVersion = mapInfo.FormatVersion,
        MapVersion = mapInfo.MapVersion,
        EditorVersion = mapInfo.EditorVersion,
        GameVersion = mapInfo.GameVersion,
        MapName = TriggerStringParser.GetTriggerStringValueFromKey(mapInfo.MapName, _triggerStrings),
        MapAuthor = TriggerStringParser.GetTriggerStringValueFromKey(mapInfo.MapAuthor, _triggerStrings),
        MapDescription = TriggerStringParser.GetTriggerStringValueFromKey(mapInfo.MapDescription, _triggerStrings),
        RecommendedPlayers = TriggerStringParser.GetTriggerStringValueFromKey(mapInfo.RecommendedPlayers, _triggerStrings),
        Unk1 = mapInfo.Unk1,
        Unk2 = mapInfo.Unk2,
        Unk3 = mapInfo.Unk3,
        Unk4 = mapInfo.Unk4,
        Unk5 = mapInfo.Unk5,
        Unk6 = mapInfo.Unk6,
        CameraBounds = MapCameraBoundsToDto(mapInfo.CameraBounds),
        CameraBoundsComplements = mapInfo.CameraBoundsComplements,
        PlayableMapAreaWidth = mapInfo.PlayableMapAreaWidth,
        PlayableMapAreaHeight = mapInfo.PlayableMapAreaHeight,
        Unk7 = mapInfo.Unk7,
        MapFlags = mapInfo.MapFlags,
        Tileset = mapInfo.Tileset,
        CampaignBackgroundNumber = mapInfo.CampaignBackgroundNumber,
        LoadingScreenBackgroundNumber = mapInfo.LoadingScreenBackgroundNumber,
        LoadingScreenPath = TriggerStringParser.GetTriggerStringValueFromKey(mapInfo.LoadingScreenPath, _triggerStrings),
        LoadingScreenText = TriggerStringParser.GetTriggerStringValueFromKey(mapInfo.LoadingScreenText, _triggerStrings),
        LoadingScreenTitle = TriggerStringParser.GetTriggerStringValueFromKey(mapInfo.LoadingScreenTitle, _triggerStrings),
        LoadingScreenSubtitle = TriggerStringParser.GetTriggerStringValueFromKey(mapInfo.LoadingScreenSubtitle, _triggerStrings),
        LoadingScreenNumber = mapInfo.LoadingScreenNumber,
        GameDataSet = mapInfo.GameDataSet,
        PrologueScreenPath = mapInfo.PrologueScreenPath,
        PrologueScreenText = TriggerStringParser.GetTriggerStringValueFromKey(mapInfo.PrologueScreenText, _triggerStrings),
        PrologueScreenTitle = TriggerStringParser.GetTriggerStringValueFromKey(mapInfo.PrologueScreenTitle, _triggerStrings),
        PrologueScreenSubtitle = TriggerStringParser.GetTriggerStringValueFromKey(mapInfo.PrologueScreenSubtitle, _triggerStrings),
        FogStyle = mapInfo.FogStyle,
        FogStartZ = mapInfo.FogStartZ,
        FogEndZ = mapInfo.FogEndZ,
        FogDensity = mapInfo.FogDensity,
        FogColor = mapInfo.FogColor,
        GlobalWeather = mapInfo.GlobalWeather,
        SoundEnvironment = mapInfo.SoundEnvironment,
        LightEnvironment = mapInfo.LightEnvironment,
        WaterTintingColor = mapInfo.WaterTintingColor,
        ScriptLanguage = mapInfo.ScriptLanguage,
        SupportedModes = mapInfo.SupportedModes,
        GameDataVersion = mapInfo.GameDataVersion,
        Players = mapInfo.Players.Select(MapPlayerDataToDto).ToList(),
        Forces = mapInfo.Forces.Select(MapForceDataToDto).ToList(),
        UpgradeData = mapInfo.UpgradeData.Select(MapUpgradeDataToDto).ToList(),
        TechData = mapInfo.TechData.Select(MapTechDataToDto).ToList(),
        RandomUnitTables = mapInfo.RandomUnitTables,
        RandomItemTables = mapInfo.RandomItemTables
      };

      return dto;
    }

    private static QuadrilateralDto MapCameraBoundsToDto(Quadrilateral quadrilateral)
    {
      return new QuadrilateralDto
      {
        BottomLeft = Vector2ToDto(quadrilateral.BottomLeft),
        TopRight = Vector2ToDto(quadrilateral.TopRight),
        TopLeft = Vector2ToDto(quadrilateral.TopLeft),
        BottomRight = Vector2ToDto(quadrilateral.BottomRight)
      };
    }

    private PlayerDataDto MapPlayerDataToDto(PlayerData playerData)
    {
      var dto = new PlayerDataDto
      {
        Id = playerData.Id,
        Controller = playerData.Controller,
        Race = playerData.Race,
        Flags = playerData.Flags,
        Name = TriggerStringParser.GetTriggerStringValueFromKey(playerData.Name, _triggerStrings),
        StartPosition = Vector2ToDto(playerData.StartPosition),
        AllyLowPriorityFlags = playerData.AllyLowPriorityFlags,
        AllyHighPriorityFlags = playerData.AllyHighPriorityFlags,
        EnemyLowPriorityFlags = playerData.EnemyLowPriorityFlags,
        EnemyHighPriorityFlags = playerData.EnemyHighPriorityFlags
      };
      return dto;
    }
    
    private ForceDataDto MapForceDataToDto(ForceData forceData)
    {
      var dto = new ForceDataDto
      {
        Flags = forceData.Flags,
        Players = forceData.Players,
        Name = _triggerStrings[TriggerStringParser.ParseTriggerStringAsKey(forceData.Name)]
      };
      return dto;
    }
    
    private static UpgradeDataDto MapUpgradeDataToDto(UpgradeData upgradeData)
    {
      var dto = new UpgradeDataDto
      {
        Players = upgradeData.Players,
        Id = upgradeData.Id,
        Level = upgradeData.Level,
        Availability = upgradeData.Availability
      };
      return dto;
    }
    
    private static TechDataDto MapTechDataToDto(TechData techData)
    {
      var dto = new TechDataDto
      {
        Players = techData.Players,
        Id = techData.Id
      };
      return dto;
    }
    
    private static Vector2Dto Vector2ToDto(Vector2 vector2)
    {
      return new Vector2Dto
      {
        X = vector2.X,
        Y = vector2.Y
      };
    }
  }
}