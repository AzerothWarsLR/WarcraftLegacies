using AutoMapper;
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

      var autoMapperConfig = AutoMapperConfigurationProvider.GetConfiguration();
      var mapper = new Mapper(autoMapperConfig);
      var sharedPathOptions = SharedPathOptions.Create("WarcraftLegacies");
      var conversionService = new MapDataToMapConverter(sharedPathOptions, mapper);
      _mapData = conversionService.ConvertToMapAndAdditionalFiles();

      return _mapData.Value;
    }
  }
}
