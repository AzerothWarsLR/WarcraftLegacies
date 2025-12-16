using AutoMapper;
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

      var autoMapperConfig = AutoMapperConfigurationProvider.GetConfiguration();
      var mapper = new Mapper(autoMapperConfig);
      var conversionService = new MapDataToMapConverter(mapper);
      var sharedPathOptions = SharedPathOptions.Create("WarcraftLegacies");
      _mapData = conversionService.ConvertToMapAndAdditionalFiles(sharedPathOptions.MapDataPath);

      return _mapData.Value;
    }
  }
}
