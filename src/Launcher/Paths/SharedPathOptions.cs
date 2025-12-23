using System.IO;
using Launcher.Settings;

namespace Launcher.Paths;

public sealed class SharedPathOptions
{
  /// <summary>
  /// Creates a default <see cref="SharedPathOptions"/> based on highly opinionated path conventions.
  /// </summary>
  public static SharedPathOptions Create(string mapName)
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
        GameInterfacePath = Path.Combine(mapDataRootPath, PathConventions.MapData.GameplayConstants),
        SkinPath = Path.Combine(mapDataRootPath, PathConventions.MapData.GameInterface)
      }
    };
    return options;
  }

  /// <summary>
  /// Path to the folder in which to write the fully built map.
  /// </summary>
  public required string W3XFolderPath { get; init; }

  /// <summary>
  /// Path to the file in which to write published, ready-to-release maps.
  /// </summary>
  public required string PublishPath { get; init; }

  /// <summary>
  /// Location of the main .NET project containing the map's code.
  /// </summary>
  public required string CsProjPath { get; init; }

  /// <summary>
  /// Path to the preferred backup folder.
  /// </summary>
  public required string BackupPath { get; init; }

  /// <summary>
  /// Path to the folder the war3map.lua should be copied to for later inspection.
  /// </summary>
  public required string ScriptArtifactPath { get; init; }

  /// <summary>
  /// Path to the Warcraft III executable.
  /// </summary>
  public required string Warcraft3ExecutablePath { get; init; }

  /// <summary>
  ///  Folder path in which the map's main C# files are stored.
  /// </summary>
  public required string SourceProjectPath { get; init; }

  /// <summary>
  ///  Folder path in which the map's shared C# files are stored.
  /// </summary>
  public required string SharedProjectPath { get; init; }

  public required MapDataPathOptions MapDataPathOptions { get; init; }
}
