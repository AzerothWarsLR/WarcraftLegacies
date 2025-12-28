using Warcraft.Cartographer.Deserialization;

namespace Warcraft.Cartographer.Paths;

public sealed class MapDataPathOptions
{
  public required string RootPath { get; init; }

  public required string AbilityDataPath { get; init; }

  public required string BuffDataPath { get; init; }

  public required string DestructableDataPath { get; init; }

  public required string DoodadDataPath { get; init; }

  public required string DoodadsPath { get; init; }

  public required string ImportsPath { get; init; }

  public required string ItemDataPath { get; init; }

  public required string RegionsPath { get; init; }

  public required string SoundsPath { get; init; }

  public required string UnitDataPath { get; init; }

  public required string UnitsPath { get; init; }

  public required string UpgradeDataPath { get; init; }

  public required string EnvironmentPath { get; init; }

  public required string InfoPath { get; init; }

  public required string PathingMapPath { get; init; }

  public required string PreviewIconsPath { get; init; }

  public required string ShadowMapPath { get; init; }

  public required string MinimapPath { get; init; }

  public required string GameplayConstantsPath { get; init; }

  public required string GameInterfacePath { get; init; }

  /// <summary>
  /// Returns all map file paths that match any of the flags specified in <see cref="IncludeFromMap"/>.
  /// </summary>
  public IEnumerable<string> GetPathsFromIncludedFiles(IncludeFromMap include)
  {
    if (include.HasFlag(IncludeFromMap.All))
    {
      yield return RootPath;
      yield break;
    }

    foreach (var flag in Enum.GetValues<IncludeFromMap>())
    {
      if (flag == IncludeFromMap.All || !include.HasFlag(flag))
      {
        continue;
      }

      var path = flag switch
      {
        IncludeFromMap.Sounds => SoundsPath,
        IncludeFromMap.Environment => EnvironmentPath,
        IncludeFromMap.PathingMap => PathingMapPath,
        IncludeFromMap.PreviewIcons => PreviewIconsPath,
        IncludeFromMap.ShadowMap => ShadowMapPath,
        IncludeFromMap.Minimap => MinimapPath,
        IncludeFromMap.Regions => RegionsPath,
        IncludeFromMap.Imports => ImportsPath,
        IncludeFromMap.Info => InfoPath,
        IncludeFromMap.GameplayConstants => GameplayConstantsPath,
        IncludeFromMap.GameInterface => GameInterfacePath,

        IncludeFromMap.AbilityData => AbilityDataPath,
        IncludeFromMap.BuffData => BuffDataPath,
        IncludeFromMap.DestructableData => DestructableDataPath,
        IncludeFromMap.DoodadData => DoodadDataPath,
        IncludeFromMap.ItemData => ItemDataPath,
        IncludeFromMap.UnitData => UnitDataPath,
        IncludeFromMap.UpgradeData => UpgradeDataPath,

        IncludeFromMap.Doodads => DoodadsPath,
        IncludeFromMap.Units => UnitsPath,

        _ => null
      };

      if (path is not null)
      {
        yield return path;
      }
    }
  }
}
