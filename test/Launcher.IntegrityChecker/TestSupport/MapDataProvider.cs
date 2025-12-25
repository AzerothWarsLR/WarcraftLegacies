using Launcher.Paths;
using Launcher.Services;
using War3Net.Build;

namespace Launcher.IntegrityChecker.TestSupport;

public static class MapDataProvider
{
  private static (Map, IEnumerable<PathData>)? _mapData;

  public static (Map Map, IEnumerable<PathData> AdditionalFiles) GetMapData()
  {
    {
      if (_mapData != null)
      {
        return _mapData.Value;
      }

      var sharedPathOptions = SharedPathOptions.Create("WarcraftLegacies");
      var conversionService = new MapDataToMapConverter(MapDataToMapConverterOptions.Create(sharedPathOptions));
      _mapData = conversionService.ConvertToMapAndAdditionalFiles();

      return _mapData.Value;
    }
  }
}
