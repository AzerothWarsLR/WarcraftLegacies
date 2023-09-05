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
    var activeModels = GetModelsUsedByObjects(_mapTestFixture.Map);
    activeModels.Should().Contain(relativePath);
  }

  public static IEnumerable<object[]> GetAllModels()
  {
    foreach (var pathData in MapDataProvider.GetMapData.AdditionalFiles)
    {
      if (pathData.RelativePath.EndsWith(".mdx"))
      {
        yield return new object[]
        {
          pathData.RelativePath
        };
      }
    }
  }

  private static IEnumerable<string> GetModelsUsedByObjects(Map map)
  {
    return GetModelsUsedByUnits(map.UnitSkinObjectData)
      .Concat(GetModelsUsedByAbilities(map.AbilitySkinObjectData));
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
}