using FluentAssertions;
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
    var activeModels = GetModelsUsedByUnits(_mapTestFixture.Map.UnitSkinObjectData);
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

  private static IEnumerable<string> GetModelsUsedByUnits(UnitObjectData unitObjectData)
  {
    var modelFields = new[] { 1818520949, 1831952757 };
    List<SimpleObjectModification> allUnits = new();
    allUnits.AddRange(unitObjectData.BaseUnits);
    allUnits.AddRange(unitObjectData.NewUnits);
    
    return allUnits
      .SelectMany(x => x.Modifications)
      .Where(x => modelFields.Contains(x.Id))
      .Select(x => x.ValueAsString.Replace(".mdl", ".mdx"))
      .ToList();
  }
}