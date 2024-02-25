using System.Text;
using Launcher.Extensions;
using Launcher.Services;
using Launcher.Settings;
using War3Api.Object;
using War3Net.Build;

namespace Launcher.IntegrityChecker
{
  /// <summary>
  /// Provides a fully constructed Warcraft Legacies map.
  /// </summary>
  public sealed class MapTestFixture
  {
    public Map Map { get; }
    
    public ObjectDatabase ObjectDatabase { get; }
    
    public string UncompiledScript { get; }

    public MapTestFixture()
    {
      (Map, _) = MapDataProvider.GetMapData();
      ObjectDatabase = Map.GetObjectDatabaseFromMap();
      AdvancedMapBuilder.AddCSharpCode(Map, "../../../../../src/WarcraftLegacies.Source/", new CompilerSettings());

      var scriptBuilder = new StringBuilder();
      var allScriptFiles = Directory.EnumerateFiles("../../../../../src/WarcraftLegacies.Source/", "*.cs",
        SearchOption.AllDirectories).ToList();
      allScriptFiles.Remove("../../../../../src/WarcraftLegacies.Source/Constants.cs");
      foreach (var fileName in allScriptFiles) 
        scriptBuilder.Append(File.ReadAllText(fileName));

      UncompiledScript = scriptBuilder.ToString();
    }
  }
}