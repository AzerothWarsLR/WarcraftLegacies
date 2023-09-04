using System.Collections.Generic;
using Launcher.DataTransferObjects;
using War3Net.Build.Info;

namespace Launcher.DTOMappers
{
  public static class MapInfoMapper
  {
    public static MapInfoDto MapToDto(MapInfo mapInfo, Dictionary<uint, string> triggerStrings)
    {
      var dto = new MapInfoDto
      {
        FormatVersion = mapInfo.FormatVersion,
        MapVersion = mapInfo.MapVersion,
        EditorVersion = mapInfo.EditorVersion,
        GameVersion = mapInfo.GameVersion,
        MapName = triggerStrings[TriggerStringParser.ParseTriggerStringAsKey(mapInfo.MapName)],
        MapAuthor = triggerStrings[TriggerStringParser.ParseTriggerStringAsKey(mapInfo.MapAuthor)],
        MapDescription = triggerStrings[TriggerStringParser.ParseTriggerStringAsKey(mapInfo.MapDescription)],
        RecommendedPlayers = triggerStrings[TriggerStringParser.ParseTriggerStringAsKey(mapInfo.RecommendedPlayers)],
        Unk1 = mapInfo.Unk1,
        Unk2 = mapInfo.Unk2,
        Unk3 = mapInfo.Unk3,
        Unk4 = mapInfo.Unk4,
        Unk5 = mapInfo.Unk5,
        Unk6 = mapInfo.Unk6,
        CameraBounds = mapInfo.CameraBounds,
        CameraBoundsComplements = mapInfo.CameraBoundsComplements,
        PlayableMapAreaWidth = mapInfo.PlayableMapAreaWidth,
        PlayableMapAreaHeight = mapInfo.PlayableMapAreaHeight,
        Unk7 = mapInfo.Unk7,
        MapFlags = mapInfo.MapFlags,
        Tileset = mapInfo.Tileset,
        CampaignBackgroundNumber = mapInfo.CampaignBackgroundNumber,
        LoadingScreenBackgroundNumber = mapInfo.LoadingScreenBackgroundNumber,
        LoadingScreenPath = triggerStrings[TriggerStringParser.ParseTriggerStringAsKey(mapInfo.LoadingScreenPath)],
        LoadingScreenText = triggerStrings[TriggerStringParser.ParseTriggerStringAsKey(mapInfo.LoadingScreenText)],
        LoadingScreenTitle = triggerStrings[TriggerStringParser.ParseTriggerStringAsKey(mapInfo.LoadingScreenTitle)],
        LoadingScreenSubtitle = triggerStrings[TriggerStringParser.ParseTriggerStringAsKey(mapInfo.LoadingScreenSubtitle)],
        LoadingScreenNumber = mapInfo.LoadingScreenNumber,
        GameDataSet = mapInfo.GameDataSet,
        PrologueScreenPath = mapInfo.PrologueScreenPath,
        PrologueScreenText = triggerStrings[TriggerStringParser.ParseTriggerStringAsKey(mapInfo.PrologueScreenText)],
        PrologueScreenTitle = triggerStrings[TriggerStringParser.ParseTriggerStringAsKey(mapInfo.PrologueScreenTitle)],
        PrologueScreenSubtitle = triggerStrings[TriggerStringParser.ParseTriggerStringAsKey(mapInfo.PrologueScreenSubtitle)],
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
        Players = mapInfo.Players,
        Forces = mapInfo.Forces,
        UpgradeData = mapInfo.UpgradeData,
        TechData = mapInfo.TechData,
        RandomUnitTables = mapInfo.RandomUnitTables,
        RandomItemTables = mapInfo.RandomItemTables
      };

      return dto;
    }
  }
}