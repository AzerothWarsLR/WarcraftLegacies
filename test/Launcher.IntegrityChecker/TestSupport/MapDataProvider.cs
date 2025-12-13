using AutoMapper;
using Launcher.Services;
using Launcher.Settings;
using War3Net.Build;

namespace Launcher.IntegrityChecker.TestSupport;

public static class MapDataProvider
{
  private static (Map, IEnumerable<PathData>)? _mapData;

  public static (Map Map, IEnumerable<PathData> AdditionalFiles) GetMapData(AppSettings appSettings)
  {
    {
      if (_mapData != null)
      {
        return _mapData.Value;
      }

      var mapDataDirectory = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.MapData, "WarcraftLegacies");
      var autoMapperConfig = AutoMapperConfigurationProvider.GetConfiguration();
      var mapper = new Mapper(autoMapperConfig);
      var conversionService = new MapDataToMapConverter(mapper);
      _mapData = conversionService.ConvertToMapAndAdditionalFiles(mapDataDirectory);

      return _mapData.Value;
    }
  }
}
