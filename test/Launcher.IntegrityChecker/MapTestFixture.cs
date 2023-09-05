using CSharpLua;
using Launcher.Services;
using Launcher.Settings;
using Microsoft.CodeAnalysis;
using War3Net.Build;
using War3Net.Build.Extensions;

namespace Launcher.IntegrityChecker
{
  public sealed class MapTestFixture
  {
    public Map Map { get; }

    public IEnumerable<PathData> ImportedFiles { get; }

    public MapTestFixture()
    {
      (Map, ImportedFiles) = MapDataProvider.GetMapData;
      AdvancedMapBuilder.AddCSharpCode(Map, @"..\..\..\..\..\src\WarcraftLegacies.Source\", new CompilerSettings { });
    }
  }
}