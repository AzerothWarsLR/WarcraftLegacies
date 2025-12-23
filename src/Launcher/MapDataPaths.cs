using System.Collections.Generic;

namespace Launcher;

public static class MapDataPaths
{
  public const string ShadowMapPath = "ShadowMap.json";
  public const string PreviewIconsPath = "PreviewIcons.json";
  public const string PathingMapPath = "PathingMap.json";
  public const string InfoPath = "Info.json";
  public const string EnvironmentPath = "Environment.json";

  public const string UnitDataDirectoryPath = "UnitData";
  public const string DoodadDataDirectoryPath = "DoodadData";
  public const string AbilityDataDirectoryPath = "AbilityData";
  public const string UpgradeDataDirectoryPath = "UpgradeData";
  public const string ItemDataDirectoryPath = "ItemData";
  public const string DestructableDataDirectoryPath = "DestructableData";
  public const string BuffDataDirectoryPath = "BuffData";

  public const string SoundsDirectoryPath = "Sounds";
  public const string RegionsDirectoryPath = "Regions";
  public const string UnitsDirectoryPath = "Units";
  public const string DoodadsDirectoryPath = "Doodads";

  public const string ImportsPath = "Imports";

  public const string ScriptPath = "war3map.lua";
  public const string MinimapPath = "war3mapMap.blp";
  public const string GameplayConstantsPath = "war3mapMisc.txt";
  public const string GameInterfacePath = "war3mapSkin.txt";

  /// <summary>
  /// Gets the paths to all files that need to be included in a map but which can't be serialized, such as plain text
  /// files or images.
  /// </summary>
  public static IEnumerable<string> GetUnserializableFilePaths()
  {
    yield return MinimapPath;
    yield return GameplayConstantsPath;
  }
}
