#nullable enable
using System;
using System.Collections.Generic;
using System.Drawing;
using War3Net.Build.Common;
using War3Net.Build.Info;

namespace Launcher.DataTransferObjects;

public sealed class MapInfoDto
{
  public MapInfoFormatVersion FormatVersion { get; set; }

  public int MapVersion { get; set; }

  public EditorVersion EditorVersion { get; set; }

  public Version? GameVersion { get; set; }

  public string? MapName { get; set; }

  public string? MapAuthor { get; set; }

  public string? MapDescription { get; set; }

  public string? RecommendedPlayers { get; set; }

  public float Unk1 { get; set; }

  public int Unk2 { get; set; }

  public float Unk3 { get; set; }

  public float Unk4 { get; set; }

  public float Unk5 { get; set; }

  public int Unk6 { get; set; }

  public QuadrilateralDto CameraBounds { get; set; }

  public RectangleMargins? CameraBoundsComplements { get; set; }

  public int PlayableMapAreaWidth { get; set; }

  public int PlayableMapAreaHeight { get; set; }

  public int Unk7 { get; set; }

  public MapFlags MapFlags { get; set; }

  public Tileset Tileset { get; set; }

  public int CampaignBackgroundNumber { get; set; }

  public int LoadingScreenBackgroundNumber { get; set; }

  public string? LoadingScreenPath { get; set; }

  public string? LoadingScreenText { get; set; }

  public string? LoadingScreenTitle { get; set; }

  public string? LoadingScreenSubtitle { get; set; }

  public int LoadingScreenNumber { get; set; }

  public GameDataSet GameDataSet { get; set; }

  public string? PrologueScreenPath { get; set; }

  public string? PrologueScreenText { get; set; }

  public string? PrologueScreenTitle { get; set; }

  public string? PrologueScreenSubtitle { get; set; }

  public FogStyle FogStyle { get; set; }

  public float FogStartZ { get; set; }

  public float FogEndZ { get; set; }

  public float FogDensity { get; set; }

  public Color FogColor { get; set; }

  public WeatherType GlobalWeather { get; set; }

  public string? SoundEnvironment { get; set; }

  public Tileset LightEnvironment { get; set; }

  public Color WaterTintingColor { get; set; }

  public ScriptLanguage ScriptLanguage { get; set; }

  public SupportedModes SupportedModes { get; set; }

  public GameDataVersion GameDataVersion { get; set; }

  public List<PlayerDataDto> Players { get; init; } = new();

  public List<ForceDataDto> Forces { get; init; } = new();

  public List<UpgradeDataDto> UpgradeData { get; init; } = new();

  public List<TechDataDto> TechData { get; init; } = new();

  public List<RandomUnitTable>? RandomUnitTables { get; init; } = new();

  public List<RandomItemTable>? RandomItemTables { get; init; } = new();
}