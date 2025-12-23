using Launcher.Paths;

namespace Launcher.Services;

public sealed class W3XToMapDataConverterOptions
{
  public static W3XToMapDataConverterOptions Create(SharedPathOptions sharedPathOptions)
  {
    return new W3XToMapDataConverterOptions
    {
      Include = IncludeFiles.All,
      MapDataPathOptions = new MapDataPathOptions
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
        GameInterfacePath = sharedPathOptions.MapDataPathOptions.GameInterfacePath,
        SkinPath = sharedPathOptions.MapDataPathOptions.SkinPath
      }
    };
  }

  /// <summary>
  /// Map files that should be included in the map data export.
  /// </summary>
  public required IncludeFiles Include { get; set; }

  public required MapDataPathOptions MapDataPathOptions { get; init; }
}
