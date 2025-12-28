using War3Net.Build;
using Warcraft.Cartographer.Deserialization;
using Warcraft.Cartographer.Paths;
using WarcraftLegacies.CLI.Settings;

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

      var sharedPathOptions = DefaultOptionsFactory.CreateSharedPathOptions("WarcraftLegacies");
      var conversionService = new MapDataToMapConverter(DefaultOptionsFactory.CreateMapDataToMapConverterOptions((SharedPathOptions)sharedPathOptions));
      _mapData = conversionService.ConvertToMapAndAdditionalFiles();

      return _mapData.Value;
    }
  }
}
