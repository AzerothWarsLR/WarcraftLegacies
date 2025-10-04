using System.Text;
using Launcher.Extensions;
using Launcher.Services;
using Launcher.Settings;
using War3Api.Object;
using War3Net.Build;
using War3Net.CodeAnalysis.Jass.Extensions;

namespace Launcher.IntegrityChecker.TestSupport;

/// <summary>
/// Provides a fully constructed Warcraft Legacies map.
/// </summary>
public sealed class MapTestFixture
{
  private static readonly int[] _utilityUnitIds =
  [
      Constants.UNIT_U00X_DUMMY_CASTER
  ];

  public Map Map { get; }

  public ObjectDatabase ObjectDatabase { get; }

  public string UncompiledScript { get; }

  public InaccessibleObjectCollection InaccessibleObjects { get; }

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
    {
      scriptBuilder.Append(File.ReadAllText(fileName));
    }

    UncompiledScript = scriptBuilder.ToString();

    InaccessibleObjects = GetInaccessibleObjects();
  }

  private InaccessibleObjectCollection GetInaccessibleObjects()
  {
    var inaccessibleObjects = new InaccessibleObjectCollection(
      ObjectDatabase.GetUnits().Where(u => !IsUtilityUnit(u)).ToList(),
      ObjectDatabase.GetUpgrades().ToList(),
      ObjectDatabase.GetAbilities().ToList(),
      ObjectDatabase.GetItems().ToList());

    var preplacedUnitIds = Map.Units!.Units.Select(x => x.TypeId).ToHashSet();
    var preplacedUnitTypes = ObjectDatabase.GetUnits().Where(x => preplacedUnitIds.Contains(x.NewId)).ToList();

    foreach (var preplacedUnit in preplacedUnitTypes)
    {
      inaccessibleObjects.RemoveWithChildren(preplacedUnit);
    }

    var objectsInScript = inaccessibleObjects
      .GetAllObjects()
      .Where(x => UncompiledScript.Contains(x.GetReadableId(), StringComparison.InvariantCultureIgnoreCase))
      .ToList();

    foreach (var objectInScript in objectsInScript)
    {
      inaccessibleObjects.RemoveWithChildren(objectInScript);
    }

    return inaccessibleObjects;
  }

  private static bool IsUtilityUnit(Unit unit)
  {
    return _utilityUnitIds.Contains(unit.NewId.InvertEndianness());
  }
}
