using Launcher.Services;
using Launcher.Settings;
using War3Net.Build;

namespace Launcher.IntegrityChecker
{
  /// <summary>
  /// Provides a fully constructed Warcraft Legacies map.
  /// </summary>
  public sealed class MapTestFixture
  {
    public Map Map { get; }

    public MapTestFixture()
    {
      (Map, _) = MapDataProvider.GetMapData();
      AdvancedMapBuilder.AddCSharpCode(Map, "../../../../../src/WarcraftLegacies.Source/", new CompilerSettings());
    }
  }
}