﻿using System.Linq;
using System.Numerics;
using Launcher.DataTransferObjects;
using War3Net.Build.Common;
using War3Net.Build.Info;

namespace Launcher.DTOMappers
{
  public sealed class MapInfoMapper
  {
    private readonly TriggerStringDictionary _triggerStrings;

    public MapInfoMapper(TriggerStringDictionary triggerStrings)
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
        MapName = !string.IsNullOrEmpty(mapInfo.MapName) ? _triggerStrings[mapInfo.MapName] : "",
        MapAuthor = !string.IsNullOrEmpty(mapInfo.MapAuthor) ? _triggerStrings[mapInfo.MapAuthor] : "",
        MapDescription = !string.IsNullOrEmpty(mapInfo.MapDescription) ? _triggerStrings[mapInfo.MapDescription] : "",
        RecommendedPlayers = !string.IsNullOrEmpty(mapInfo.RecommendedPlayers)
          ? _triggerStrings[mapInfo.RecommendedPlayers]
          : "",
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
        LoadingScreenPath = !string.IsNullOrEmpty(mapInfo.LoadingScreenPath)
          ? _triggerStrings[mapInfo.LoadingScreenPath]
          : "",
        LoadingScreenText = !string.IsNullOrEmpty(mapInfo.LoadingScreenText)
          ? _triggerStrings[mapInfo.LoadingScreenText]
          : "",
        LoadingScreenTitle = !string.IsNullOrEmpty(mapInfo.LoadingScreenTitle)
          ? _triggerStrings[mapInfo.LoadingScreenTitle]
          : "",
        LoadingScreenSubtitle = !string.IsNullOrEmpty(mapInfo.LoadingScreenSubtitle)
          ? _triggerStrings[mapInfo.LoadingScreenSubtitle]
          : "",
        LoadingScreenNumber = mapInfo.LoadingScreenNumber,
        GameDataSet = mapInfo.GameDataSet,
        PrologueScreenPath = mapInfo.PrologueScreenPath,
        PrologueScreenText = !string.IsNullOrEmpty(mapInfo.PrologueScreenText)
          ? _triggerStrings[mapInfo.PrologueScreenText]
          : "",
        PrologueScreenTitle = !string.IsNullOrEmpty(mapInfo.PrologueScreenTitle)
          ? _triggerStrings[mapInfo.PrologueScreenTitle]
          : "",
        PrologueScreenSubtitle = !string.IsNullOrEmpty(mapInfo.PrologueScreenSubtitle)
          ? _triggerStrings[mapInfo.PrologueScreenSubtitle]
          : "",
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
        Name = _triggerStrings[playerData.Name],
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
        Name = _triggerStrings[forceData.Name]
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