namespace Launcher.Paths;

public static class PathConventions
{
  public const string MapsPath = "maps";

  public const string MapDataPath = "mapdata";

  public const string BackupsPath = $"{MapsPath}/backups";

  public const string ArtifactsPath = "artifacts";

  public const string SrcPath = "src";

  public const string PublishedPath = $"{MapsPath}/published";

  public const string SourceProjectSuffix = ".Source";

  public const string SharedProjectSuffix = ".Shared";

  public static class MapData
  {
    public const string ShadowMap = "ShadowMap.json";
    public const string PreviewIcons = "PreviewIcons.json";
    public const string PathingMap = "PathingMap.json";
    public const string Info = "Info.json";
    public const string Environment = "Environment.json";

    public const string UnitData = "UnitData/";
    public const string DoodadData = "DoodadData/";
    public const string AbilityData = "AbilityData/";
    public const string UpgradeData = "UpgradeData/";
    public const string ItemData = "ItemData/";
    public const string DestructableData = "DestructableData/";
    public const string BuffData = "BuffData/";

    public const string Sounds = "Sounds/";
    public const string Regions = "Regions/";
    public const string Units = "Units/";
    public const string Doodads = "Doodads/";

    public const string Imports = "Imports/";

    public const string Script = "war3map.lua";
    public const string Minimap = "war3mapMap.blp";
    public const string GameplayConstants = "war3mapMisc.txt";
    public const string GameInterface = "war3mapSkin.txt";
  }
}
