using AutoMapper;
using Launcher.Services;
using War3Net.Build;

namespace Launcher.IntegrityChecker
{
  public static class MapDataProvider
  {
    private static (Map, IEnumerable<PathData>)? _mapData;

    public static (Map Map, IEnumerable<PathData> AdditionalFiles) GetMapData()
    {
      {
        if (_mapData != null)
          return _mapData.Value;

        const string mapDataDirectory = "../../../../../mapdata/WarcraftLegacies";
        var autoMapperConfig = new AutoMapperConfigurationProvider().GetConfiguration();
        var mapper = new Mapper(autoMapperConfig);
        var conversionService = new MapDataToMapConverter(mapper, new JsonModifierProvider());
        _mapData = conversionService.ConvertToMapAndAdditionalFiles(mapDataDirectory);

        return _mapData.Value;
      }
    }
  }
}