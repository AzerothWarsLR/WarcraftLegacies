using Launcher.Services;
using War3Net.Build;

namespace Launcher.IntegrityChecker
{
  public sealed class MapTestFixture
  {
    public Map Map { get; }

    public IEnumerable<PathData> ImportedFiles { get; }

    public MapTestFixture()
    {
      (Map, ImportedFiles) = MapDataProvider.GetMapData;
    }
  }
}