using System.Text;
using War3Api.Object;
using War3Net.CodeAnalysis.Jass.Extensions;
using Warcraft.Cartographer.Deserialization;
using Warcraft.Cartographer.Extensions;
using Warcraft.Integrity;
using WarcraftLegacies.CLI.Settings;

namespace WarcraftLegacies.Map.Tests.TestSupport;

/// <summary>
/// Provides a fully constructed Warcraft Legacies map.
/// </summary>
public sealed class MapTestFixture
{
  private static readonly int[] _utilityUnitIds =
  [
      Units.UNIT_U00X_DUMMY_CASTER
  ];

  // Abilities rooted by Items that are not yet monitored.
  private static readonly int[] _rootedAbilityUnitIds =
  [
    // Asal
    1818325825,
    // AIse
    1702054209,
    // ANsa
    1634946625,
    // AIdf
    1717848385
  ];

  public War3Net.Build.Map Map { get; }

  public ObjectDatabase ObjectDatabase { get; }

  public string UncompiledScript { get; }

  public UnreachableObjectCollection UnreachableObjects { get; }

  public MapTestFixture()
  {
    (Map, _) = MapDataProvider.GetMapData();
    ObjectDatabase = Map.GetObjectDatabaseFromMap();
    var sharedPathOptions = DefaultOptionsFactory.CreateSharedPathOptions("WarcraftLegacies");
    var advancedMapBuilder = new AdvancedMapBuilder(DefaultOptionsFactory.CreateAdvancedMapBuilderOptions(sharedPathOptions));
    advancedMapBuilder.AddCSharpCode(Map);

    var scriptBuilder = new StringBuilder();

    var allScriptFiles = Directory
      .EnumerateFiles(sharedPathOptions.SourceProjectPath, "*.cs", SearchOption.AllDirectories)
      .Where(f => !f.EndsWith(".g.cs", StringComparison.OrdinalIgnoreCase))
      .ToList();

    foreach (var fileName in allScriptFiles)
    {
      scriptBuilder.Append(File.ReadAllText(fileName));
    }

    UncompiledScript = scriptBuilder.ToString();

    UnreachableObjects = GetUnreachableObjects();
  }

  private UnreachableObjectCollection GetUnreachableObjects()
  {
    var unreachableObjects = new UnreachableObjectCollection(
      ObjectDatabase.GetUnits().Where(u => !IsUtilityUnit(u)).ToList(),
      ObjectDatabase.GetUpgrades().ToList(),
      ObjectDatabase.GetAbilities().Where(a => !IsRootedAbility(a)).ToList(),
      ObjectDatabase.GetItems().ToList(),
      ObjectDatabase.GetDoodads().ToList());

    RemovePreplacedUnits(unreachableObjects);
    RemovePreplacedDoodads(unreachableObjects);

    var referencedIds = GetAllFourCcs([UncompiledScript]);

    foreach (var obj in unreachableObjects.GetAllObjects().Where(x => referencedIds.Contains(x.GetReadableId())))
    {
      unreachableObjects.RemoveWithChildren(obj);
    }

    return unreachableObjects;
  }

  /// <summary>
  /// Identifies preplaced units on the map and removes them, and their children, from the <see cref="UnreachableObjectCollection"/>.
  /// </summary>
  private void RemovePreplacedUnits(UnreachableObjectCollection unreachableObjects)
  {
    var preplacedUnitIds = Map.Units!.Units.Select(x => x.TypeId).ToHashSet();
    var preplacedUnitTypes = ObjectDatabase.GetUnits().Where(x => preplacedUnitIds.Contains(x.GetId())).ToList();
    foreach (var preplacedUnit in preplacedUnitTypes)
    {
      unreachableObjects.RemoveWithChildren(preplacedUnit);
    }
  }

  /// <summary>
  /// Identifies preplaced doodads on the map and removes them, and their children, from the <see cref="UnreachableObjectCollection"/>.
  /// </summary>
  private void RemovePreplacedDoodads(UnreachableObjectCollection unreachableObjects)
  {
    var preplacedDoodadIds = Map.Doodads!.Doodads.Select(x => x.TypeId).ToHashSet();
    var preplacedDoodadTypeIds = ObjectDatabase.GetDoodads().Where(x => preplacedDoodadIds.Contains(x.GetId())).ToList();
    foreach (var preplacedDoodadTypeId in preplacedDoodadTypeIds)
    {
      unreachableObjects.RemoveWithChildren(preplacedDoodadTypeId);
    }
  }

  private static bool IsUtilityUnit(Unit unit)
  {
    return _utilityUnitIds.Contains(unit.NewId.InvertEndianness());
  }

  private static bool IsRootedAbility(Ability ability)
  {
    return _rootedAbilityUnitIds.Contains(ability.GetId());
  }

  private static HashSet<string> GetAllFourCcs(params IEnumerable<string>[] texts)
  {
    // TODO: A reachable fourcc whose uppercase form collides with an unreachable fourcc will produce a false negative
    // The result is case-insensitive because generated constants uppercase the fourcc.
    var result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    foreach (var text in texts.SelectMany(x => x))
    {
      foreach (var match in MapDataRegex.ParseFourCcs().EnumerateMatches(text))
      {
        result.Add(text.Substring(match.Index, match.Length));
      }
    }

    return result;
  }
}
