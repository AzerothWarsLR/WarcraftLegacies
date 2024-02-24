using FluentAssertions;

namespace Launcher.IntegrityChecker;

public sealed class ImportFileTests : IClassFixture<ImportFilesTestFixture>
{
  private readonly ImportFilesTestFixture _importFilesTestFixture;

  public ImportFileTests(ImportFilesTestFixture importFilesTestFixture)
  {
    _importFilesTestFixture = importFilesTestFixture;
  }
  
  [Theory]
  [MemberData(nameof(GetAllImportedModels))]
  public void AllModels_AreInActiveUse(string relativePath)
  {
    var activeModels = _importFilesTestFixture.ModelsUsedInMap;
    activeModels.Should().Contain(relativePath);
  }

  public static IEnumerable<object[]> GetAllImportedModels()
  {
    var (_, additionalFiles) = MapDataProvider.GetMapData();

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