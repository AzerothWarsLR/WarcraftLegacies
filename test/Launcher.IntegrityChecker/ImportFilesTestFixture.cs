using System.Text.RegularExpressions;
using Launcher.Services;
using Launcher.Settings;
using War3Net.Build;
using War3Net.Build.Object;

namespace Launcher.IntegrityChecker
{
  public sealed class ImportFilesTestFixture
  {
    public Map Map { get; }

    public IEnumerable<PathData> ImportedFiles { get; }
    
    public HashSet<string> ModelsUsedInMap { get; }

    public ImportFilesTestFixture()
    {
      (Map, ImportedFiles) = MapDataProvider.GetMapData;
      AdvancedMapBuilder.AddCSharpCode(Map, @"..\..\..\..\..\src\WarcraftLegacies.Source\", new CompilerSettings());
      ModelsUsedInMap = GetModelsUsedInMap(Map).ToHashSet();
    }

    private static IEnumerable<string> GetModelsUsedInMap(Map map)
    {
      return GetModelsUsedByUnits(map.UnitSkinObjectData)
        .Concat(GetModelsUsedByAbilities(map.AbilitySkinObjectData))
        .Concat(GetModelsUsedByDoodads(map.DoodadObjectData))
        .Concat(GetModelsUsedByBuffs(map.BuffSkinObjectData))
        .Concat(GetModelsUsedByDestructables(map.DestructableSkinObjectData))
        .Concat(GetModelsUsedByScript(map.Script));
    }

    private static IEnumerable<string> GetModelsUsedByUnits(UnitObjectData unitObjectData)
    {
      var modelFields = new[] { 1818520949, 1831952757 };

      return unitObjectData.BaseUnits
        .Concat(unitObjectData.NewUnits)
        .SelectMany(x => x.Modifications)
        .Where(x => modelFields.Contains(x.Id))
        .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
        .ToList();
    }

    private static IEnumerable<string> GetModelsUsedByAbilities(AbilityObjectData abilityObjectData)
    {
      var modelFields = new[] { 1952543585, 1952543841, 1952543585 };

      return abilityObjectData.BaseAbilities
        .Concat(abilityObjectData.NewAbilities)
        .SelectMany(x => x.Modifications)
        .Where(x => modelFields.Contains(x.Id))
        .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
        .ToList();
    }

    private static IEnumerable<string> GetModelsUsedByDoodads(DoodadObjectData doodadObjectData)
    {
      var modelFields = new[] { 1818846820 };

      return doodadObjectData.BaseDoodads
        .Concat(doodadObjectData.NewDoodads)
        .SelectMany(x => x.Modifications)
        .Where(x => modelFields.Contains(x.Id))
        .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
        .ToList();
    }
    
    private static IEnumerable<string> GetModelsUsedByDestructables(DestructableObjectData destructableObjectData)
    {
      var modelFields = new[] { 1818846818 };

      return destructableObjectData.BaseDestructables
        .Concat(destructableObjectData.NewDestructables)
        .SelectMany(x => x.Modifications)
        .Where(x => modelFields.Contains(x.Id))
        .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
        .ToList();
    }

    private static IEnumerable<string> GetModelsUsedByBuffs(BuffObjectData buffObjectData)
    {
      var modelFields = new[] { 1952543846 };

      return buffObjectData.BaseBuffs
        .Concat(buffObjectData.NewBuffs)
        .SelectMany(x => x.Modifications)
        .Where(x => modelFields.Contains(x.Id))
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
  }
}