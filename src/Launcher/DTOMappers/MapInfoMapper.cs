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
        MapName = AAA,
        MapAuthor = AAA,
        MapDescription = AAA,
        RecommendedPlayers = AAA,
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
        LoadingScreenPath = AAA,
        LoadingScreenText = AAA,
        LoadingScreenTitle = AAA,
        LoadingScreenSubtitle = AAA,
        LoadingScreenNumber = mapInfo.LoadingScreenNumber,
        GameDataSet = mapInfo.GameDataSet,
        PrologueScreenPath = mapInfo.PrologueScreenPath,
        PrologueScreenText = AAA,
        PrologueScreenTitle = AAA,
        PrologueScreenSubtitle = AAA,
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