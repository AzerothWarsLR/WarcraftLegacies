using System.Text.RegularExpressions;
using FluentAssertions;
using Launcher.IntegrityChecker.TestSupport;
using Launcher.Settings;
using War3Net.Build;
using War3Net.Build.Object;

namespace Launcher.IntegrityChecker;

public sealed class ImportedModelTests(MapTestFixture mapTestFixture) : IClassFixture<MapTestFixture>
{
  [Fact]
  public void AllModels_AreInActiveUse()
  {
    var excludedModels = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "war3mapimported\\orbofwind.mdx", };

    var (_, additionalFiles) = MapDataProvider.GetMapData(AppSettings.Load());

    var importedModels = additionalFiles
      .Where(f => f.RelativePath.IsModelPath())
      .Select(f => f.RelativePath.NormalizeModelPath())
      .Where(path => !excludedModels.Contains(path))
      .OrderBy(x => x)
      .ToList();

    var activeModels = GetModelsUsedInMap(mapTestFixture.Map).OrderBy(x => x).ToHashSet();

    var unusedModels = importedModels
      .Where(model => !activeModels.Contains(model))
      .ToList();

    unusedModels.Should().BeEmpty(
      "every imported model should be used by an ability, doodad, buff, destructable, or script.{0}",
      unusedModels.Count != 0
        ? $" Unused models: {string.Join(", ", unusedModels)}"
        : string.Empty);
  }

  private static IEnumerable<string> GetModelsUsedInMap(Map map)
  {
    return GetModelsUsedByUnits(map.UnitObjectData)
      .Concat(GetModelsUsedByAbilities(map.AbilityObjectData))
      .Concat(GetModelsUsedByDoodads(map.DoodadObjectData))
      .Concat(GetModelsUsedByBuffs(map.BuffObjectData))
      .Concat(GetModelsUsedByDestructables(map.DestructableObjectData))
      .Concat(GetModelsUsedByScript(map.Script))
      .Select(x => x.NormalizeModelPath());
  }

  private static List<string> GetModelsUsedByUnits(UnitObjectData unitObjectData)
  {
    return unitObjectData.BaseUnits
      .Concat(unitObjectData.NewUnits)
      .SelectMany(x => x.Modifications)
      .Where(IsModelField)
      .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
      .ToList();
  }

  private static List<string> GetModelsUsedByAbilities(AbilityObjectData abilityObjectData)
  {
    return abilityObjectData.BaseAbilities
      .Concat(abilityObjectData.NewAbilities)
      .SelectMany(x => x.Modifications)
      .Where(IsModelField)
      .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
      .ToList();
  }

  private static List<string> GetModelsUsedByDoodads(DoodadObjectData doodadObjectData)
  {
    return doodadObjectData.BaseDoodads
      .Concat(doodadObjectData.NewDoodads)
      .SelectMany(x => x.Modifications)
      .Where(IsModelField)
      .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
      .ToList();
  }

  private static List<string> GetModelsUsedByDestructables(DestructableObjectData destructableObjectData)
  {
    return destructableObjectData.BaseDestructables
      .Concat(destructableObjectData.NewDestructables)
      .SelectMany(x => x.Modifications)
      .Where(IsModelField)
      .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
      .ToList();
  }

  private static List<string> GetModelsUsedByBuffs(BuffObjectData buffObjectData)
  {
    return buffObjectData.BaseBuffs
      .Concat(buffObjectData.NewBuffs)
      .SelectMany(x => x.Modifications)
      .Where(IsModelField)
      .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
      .ToList();
  }

  private static IEnumerable<string> GetModelsUsedByScript(string? mapScript)
  {
    var matches = Regex.Matches(mapScript, @"[\[""].*\.md[xl][\]""]");
    foreach (var model in matches.ToList())
    {
      yield return model.Value
        .Replace("[", "")
        .Replace("]", "")
        .Replace(@"""", "")
        .Replace(".mdl", ".mdx");
    }
  }

  private static bool IsModelField(ObjectDataModification modification) =>
    modification.Type == ObjectDataType.String && modification.ValueAsString.IsModelPath();
}
