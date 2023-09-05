using System.Text.RegularExpressions;
using FluentAssertions;
using War3Net.Build;
using War3Net.Build.Object;

namespace Launcher.IntegrityChecker;

public sealed class ImportFileTests : IClassFixture<MapTestFixture>
{
  private readonly MapTestFixture _mapTestFixture;

  public ImportFileTests(MapTestFixture mapTestFixture)
  {
    _mapTestFixture = mapTestFixture;
  }
  
  [Theory]
  [MemberData(nameof(GetAllModels))]
  public void AllModels_AreInActiveUse(string relativePath)
  {
    var activeModels = GetModelsUsedInMap(_mapTestFixture.Map);
    activeModels.Should().Contain(relativePath);
  }

  public static IEnumerable<object[]> GetAllModels()
  {
    foreach (var pathData in MapDataProvider.GetMapData.AdditionalFiles)
    {
      if (pathData.RelativePath.EndsWith(".mdx") && !pathData.RelativePath.ToLower().EndsWith("_portrait.mdx")) //Todo: would be good to handle portraits
      {
        yield return new object[]
        {
          pathData.RelativePath
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