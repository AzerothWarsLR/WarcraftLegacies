using FluentAssertions;

namespace Launcher.IntegrityChecker;

public sealed class ImportFileTests : IClassFixture<ImportFilesTestFixture>
{
  private readonly ImportFilesTestFixture _importFilesTestFixture;

  public ImportFileTests(ImportFilesTestFixture importFilesTestFixture)
  {
    _importFilesTestFixture = importFilesTestFixture;
  }
  
  [Fact]
  public void AllModels_AreInActiveUse()
  {
    var unusedModels = _importFilesTestFixture.ImportedModels
      .Where(model => !_importFilesTestFixture.ModelsUsedInMap.Contains(model));
    
    unusedModels.Should().BeEmpty();
  }
}