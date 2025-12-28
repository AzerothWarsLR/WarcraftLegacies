using System.IO;
using Warcraft.Cartographer.Deserialization;
using Warcraft.Cartographer.Paths;

namespace WarcraftLegacies.CLI.Settings;

public static class DefaultOptionsFactory
{
  /// <summary>
  /// Creates a default <see cref="AdvancedMapBuilderOptions"/> from a set of path options shared with the whole project.
  /// </summary>
  public static AdvancedMapBuilderOptions CreateAdvancedMapBuilderOptions(SharedPathOptions sharedPathOptions)
  {
    var settings = AppSettings.Current;
    var options = new AdvancedMapBuilderOptions
    {
      W3XFolderPath = sharedPathOptions.W3XFolderPath,
      PublishedMapPath = sharedPathOptions.PublishPath,
      CsProjPath = sharedPathOptions.CsProjPath,
      BackupPath = sharedPathOptions.BackupPath,
      ScriptArtifactPath = sharedPathOptions.ScriptArtifactPath,
      Warcraft3ExecutablePath = sharedPathOptions.Warcraft3ExecutablePath,
      Version = settings.MapSettings.Version
    };
    return options;
  }

  /// <summary>
  /// Creates a default <see cref="AdvancedMapBuilderOptions"/> from a set of path options shared with the whole project,
  /// using the map name to derive some paths.
  /// </summary>
  public static AdvancedMapBuilderOptions CreateAdvancedMapBuilderOptions(string mapName)
  {
    var sharedPathOptions = CreateSharedPathOptions(mapName);
    return CreateAdvancedMapBuilderOptions(sharedPathOptions);
  }

  /// <summary>
  /// Creates a default <see cref="SharedPathOptions"/> based on highly opinionated path conventions.
  /// </summary>
  public static SharedPathOptions CreateSharedPathOptions(string mapName)
  {
    var settings = AppSettings.Current;
    var rootPath = settings.CompilerSettings.RootPath;
    var mapDataRootPath = Path.Combine(rootPath, PathConventions.MapDataPath, mapName);
    var options = new SharedPathOptions
    {
      W3XFolderPath = Path.Combine(rootPath, PathConventions.MapsPath, $"{mapName}.w3x"),
      PublishPath = Path.Combine(rootPath, PathConventions.PublishedPath, $"{mapName}.w3x"),
      CsProjPath = Path.Combine(rootPath, PathConventions.SrcPath, $"{mapName}{PathConventions.SourceProjectSuffix}", $"{mapName}{PathConventions.SourceProjectSuffix}.csproj"),
      BackupPath = Path.Combine(rootPath, PathConventions.BackupsPath),
      ScriptArtifactPath = Path.Combine(rootPath, PathConventions.ArtifactsPath),
      Warcraft3ExecutablePath = settings.CompilerSettings.Warcraft3ExecutablePath,
      SourceProjectPath = Path.Combine(rootPath, PathConventions.SrcPath, $"{mapName}{PathConventions.SourceProjectSuffix}"),
      SharedProjectPath = Path.Combine(rootPath, PathConventions.SrcPath, $"{mapName}{PathConventions.SharedProjectSuffix}"),
      MapDataPathOptions = new MapDataPathOptions
      {
        RootPath = mapDataRootPath,
        AbilityDataPath = Path.Combine(mapDataRootPath, PathConventions.MapData.AbilityData),
        BuffDataPath = Path.Combine(mapDataRootPath, PathConventions.MapData.BuffData),
        DestructableDataPath = Path.Combine(mapDataRootPath, PathConventions.MapData.DestructableData),
        DoodadDataPath = Path.Combine(mapDataRootPath, PathConventions.MapData.DoodadData),
        DoodadsPath = Path.Combine(mapDataRootPath, PathConventions.MapData.Doodads),
        ImportsPath = Path.Combine(mapDataRootPath, PathConventions.MapData.Imports),
        ItemDataPath = Path.Combine(mapDataRootPath, PathConventions.MapData.ItemData),
        RegionsPath = Path.Combine(mapDataRootPath, PathConventions.MapData.Regions),
        SoundsPath = Path.Combine(mapDataRootPath, PathConventions.MapData.Sounds),
        UnitDataPath = Path.Combine(mapDataRootPath, PathConventions.MapData.UnitData),
        UnitsPath = Path.Combine(mapDataRootPath, PathConventions.MapData.Units),
        UpgradeDataPath = Path.Combine(mapDataRootPath, PathConventions.MapData.UpgradeData),
        EnvironmentPath = Path.Combine(mapDataRootPath, PathConventions.MapData.Environment),
        InfoPath = Path.Combine(mapDataRootPath, PathConventions.MapData.Info),
        PathingMapPath = Path.Combine(mapDataRootPath, PathConventions.MapData.PathingMap),
        PreviewIconsPath = Path.Combine(mapDataRootPath, PathConventions.MapData.PreviewIcons),
        ShadowMapPath = Path.Combine(mapDataRootPath, PathConventions.MapData.ShadowMap),
        MinimapPath = Path.Combine(mapDataRootPath, PathConventions.MapData.Minimap),
        GameplayConstantsPath = Path.Combine(mapDataRootPath, PathConventions.MapData.GameplayConstants),
        GameInterfacePath = Path.Combine(mapDataRootPath, PathConventions.MapData.GameInterface)
      }
    };
    return options;
  }

  public static MapDataToMapConverterOptions CreateMapDataToMapConverterOptions(SharedPathOptions sharedPathOptions)
  {
    return new MapDataToMapConverterOptions
    {
      MapDataPaths = new MapDataPathOptions
      {
        RootPath = sharedPathOptions.MapDataPathOptions.RootPath,
        AbilityDataPath = sharedPathOptions.MapDataPathOptions.AbilityDataPath,
        BuffDataPath = sharedPathOptions.MapDataPathOptions.BuffDataPath,
        DestructableDataPath = sharedPathOptions.MapDataPathOptions.DestructableDataPath,
        DoodadDataPath = sharedPathOptions.MapDataPathOptions.DoodadDataPath,
        DoodadsPath = sharedPathOptions.MapDataPathOptions.DoodadsPath,
        ImportsPath = sharedPathOptions.MapDataPathOptions.ImportsPath,
        ItemDataPath = sharedPathOptions.MapDataPathOptions.ItemDataPath,
        RegionsPath = sharedPathOptions.MapDataPathOptions.RegionsPath,
        SoundsPath = sharedPathOptions.MapDataPathOptions.SoundsPath,
        UnitDataPath = sharedPathOptions.MapDataPathOptions.UnitDataPath,
        UnitsPath = sharedPathOptions.MapDataPathOptions.UnitsPath,
        UpgradeDataPath = sharedPathOptions.MapDataPathOptions.UpgradeDataPath,
        EnvironmentPath = sharedPathOptions.MapDataPathOptions.EnvironmentPath,
        InfoPath = sharedPathOptions.MapDataPathOptions.InfoPath,
        PathingMapPath = sharedPathOptions.MapDataPathOptions.PathingMapPath,
        PreviewIconsPath = sharedPathOptions.MapDataPathOptions.PreviewIconsPath,
        ShadowMapPath = sharedPathOptions.MapDataPathOptions.ShadowMapPath,
        MinimapPath = sharedPathOptions.MapDataPathOptions.MinimapPath,
        GameplayConstantsPath = sharedPathOptions.MapDataPathOptions.GameplayConstantsPath,
        GameInterfacePath = sharedPathOptions.MapDataPathOptions.GameInterfacePath
      }
    };
  }
}
