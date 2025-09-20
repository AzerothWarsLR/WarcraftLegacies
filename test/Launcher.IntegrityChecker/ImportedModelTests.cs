using System.Text.RegularExpressions;
using FluentAssertions;
using Launcher.IntegrityChecker.TestSupport;
using War3Net.Build;
using War3Net.Build.Object;

namespace Launcher.IntegrityChecker;

public sealed class ImportedModelTests : IClassFixture<MapTestFixture>
{
  private readonly MapTestFixture _mapTestFixture;

  public ImportedModelTests(MapTestFixture mapTestFixture)
  {
    _mapTestFixture = mapTestFixture;
  }

  [Theory]
  [MemberData(nameof(GetAllImportedModels))]
  public void AllModels_AreInActiveUse(string relativePath)
  {
    var excludedModels = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
      "war3mapimported\\orbofwind.mdx",
    };

    if (excludedModels.Contains(relativePath))
    {
      return;
    }


    var activeModels = GetModelsUsedInMap(_mapTestFixture.Map).OrderBy(x => x).ToHashSet();
    activeModels.Contains(relativePath).Should().BeTrue($"the model {relativePath} exists in the map so it should be used by an ability, doodad, buff, destructable, or script");
  }

  public static IEnumerable<object[]> GetAllImportedModels()
  {
    var (_, additionalFiles) = MapDataProvider.GetMapData();

    if (!additionalFiles.Any())
    {
      throw new InvalidOperationException($"{nameof(MapDataProvider)} returned no additional files to test.");
    }

    foreach (var pathData in MapDataProvider.GetMapData().AdditionalFiles)
    {
      if (pathData.RelativePath.IsModelPath())
      {
        yield return new object[]
        {
          pathData.RelativePath.NormalizeModelPath()
        };
      }
    }
  }

  private static IEnumerable<string> GetModelsUsedInMap(Map map)
  {
    return GetModelsUsedByUnits(map.UnitSkinObjectData)
      .Concat(GetModelsUsedByAbilities(map.AbilitySkinObjectData))
      .Concat(GetModelsUsedByDoodads(map.DoodadObjectData))
      .Concat(GetModelsUsedByBuffs(map.BuffSkinObjectData))
      .Concat(GetModelsUsedByDestructables(map.DestructableSkinObjectData))
      .Concat(GetModelsUsedByScript(map.Script))
      .Select(x => x.NormalizeModelPath());
  }

  private static IEnumerable<string> GetModelsUsedByUnits(UnitObjectData unitObjectData)
  {
    return unitObjectData.BaseUnits
      .Concat(unitObjectData.NewUnits)
      .SelectMany(x => x.Modifications)
      .Where(IsModelField)
      .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
      .ToList();
  }

  private static IEnumerable<string> GetModelsUsedByAbilities(AbilityObjectData abilityObjectData)
  {
    return abilityObjectData.BaseAbilities
      .Concat(abilityObjectData.NewAbilities)
      .SelectMany(x => x.Modifications)
      .Where(IsModelField)
      .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
      .ToList();
  }

  private static IEnumerable<string> GetModelsUsedByDoodads(DoodadObjectData doodadObjectData)
  {
    return doodadObjectData.BaseDoodads
      .Concat(doodadObjectData.NewDoodads)
      .SelectMany(x => x.Modifications)
      .Where(IsModelField)
      .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
      .ToList();
  }

  private static IEnumerable<string> GetModelsUsedByDestructables(DestructableObjectData destructableObjectData)
  {
    return destructableObjectData.BaseDestructables
      .Concat(destructableObjectData.NewDestructables)
      .SelectMany(x => x.Modifications)
      .Where(IsModelField)
      .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
      .ToList();
  }

  private static IEnumerable<string> GetModelsUsedByBuffs(BuffObjectData buffObjectData)
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
