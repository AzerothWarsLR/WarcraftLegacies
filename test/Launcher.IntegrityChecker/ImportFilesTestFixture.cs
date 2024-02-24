using System.Text.RegularExpressions;
using Launcher.Services;
using Launcher.Settings;
using War3Net.Build;
using War3Net.Build.Object;

namespace Launcher.IntegrityChecker
{
  public sealed class ImportFilesTestFixture
  {
    public HashSet<string> ModelsUsedInMap { get; }

    public ImportFilesTestFixture()
    {
      var (map, _) = MapDataProvider.GetMapData();
      AdvancedMapBuilder.AddCSharpCode(map, "../../../../../src/WarcraftLegacies.Source/", new CompilerSettings());
      ModelsUsedInMap = GetModelsUsedInMap(map).OrderBy(x => x).ToHashSet();
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
        yield return model.Value
          .Replace("[", "")
          .Replace("]", "")
          .Replace(@"""", "")
          .Replace(".mdl", ".mdx");
    }

    private static bool IsModelField(ObjectDataModification modification) =>
      modification.Type == ObjectDataType.String && modification.ValueAsString.IsModelPath();
  }
}