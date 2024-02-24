using FluentAssertions;
using Xunit.Abstractions;

namespace Launcher.IntegrityChecker;

public sealed class ImportFileTests : IClassFixture<ImportFilesTestFixture>
{
  private readonly ImportFilesTestFixture _importFilesTestFixture;
  private readonly ITestOutputHelper _testOutputHelper;

  public ImportFileTests(ImportFilesTestFixture importFilesTestFixture, ITestOutputHelper testOutputHelper)
  {
    _importFilesTestFixture = importFilesTestFixture;
    _testOutputHelper = testOutputHelper;
  }

  [Theory]
  [MemberData(nameof(GetAllImportedModels))]
  public void AllModels_AreInActiveUse(string relativePath)
  {
    var activeModels = _importFilesTestFixture.ModelsUsedInMap;
    activeModels.Should().Contain(relativePath);
    
  }

  public IEnumerable<object[]> GetAllImportedModels()
  {
    var (map, additionalFiles) = MapDataProvider.GetMapData();
    _testOutputHelper.WriteLine($"Found data for {map.Info.MapName}");

    if (!additionalFiles.Any())
      throw new InvalidOperationException($"{nameof(MapDataProvider)} returned no additional files to test.");

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
}