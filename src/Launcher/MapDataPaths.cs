namespace Launcher
{
  public static class MapDataPaths
  {
    public const string CustomTextTriggersPath = "CustomTextTriggers.json";
    public const string ShadowMapPath = "ShadowMap.json";
    public const string PreviewIconsPath = "PreviewIcons.json";
    public const string PathingMapPath = "PathingMap.json";
    public const string ImportedFilesPath = "ImportedFiles.json";
    public const string InfoPath = "Info.json";
    public const string EnvironmentPath = "Environment.json";

    public const string UnitDataDirectoryPath = "UnitData";
    public const string DoodadDataDirectoryPath = "DoodadData";
    public const string AbilityDataDirectoryPath = "AbilityData";
    public const string UpgradeDataDirectoryPath = "UpgradeData";
    public const string ItemDataDirectoryPath = "ItemData";
    public const string DestructableDataDirectoryPath = "DestructableData";
    public const string BuffDataDirectoryPath = "BuffData";

    public const string SkinDataDirectorySubPath = "Skin";
    public const string CoreDataDirectorySubPath = "Core";

    public const string SoundsDirectoryPath = "Sounds";
    public const string RegionsDirectoryPath = "Regions";
    public const string UnitsDirectoryPath = "Units";
    public const string DoodadsDirectoryPath = "Doodads";
    public const string TriggerStringsDirectoryPath = "TriggerStrings";
    
    public const string ImportsPath = "Imports";

    public const string ScriptPath = "Script.lua";

    /// <summary>
    /// Some positional data is seperated into different files based on position on the map.
    /// Chunk size determines how large those square chunks should be.
    /// </summary>
    public const int ChunkSize = 512;
  }
}