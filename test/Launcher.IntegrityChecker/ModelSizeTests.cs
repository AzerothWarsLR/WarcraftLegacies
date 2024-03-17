using System.Text;
using FastMDX;
using Launcher.Services;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Launcher.IntegrityChecker
{
  public sealed class ModelSizeTests : IClassFixture<MapTestFixture>
  {
    private readonly MapTestFixture _mapTestFixture;

    public ModelSizeTests(MapTestFixture mapTestFixture, ITestOutputHelper testOutputHelper)
    {
      _mapTestFixture = mapTestFixture;
    }
    
    [Fact]
    public void AllModelSizes_HavePolygonsUnder_UpperLimit()
    {
      var failedTestResults = GetAllImportedModels()
        .Select(x => TestModel(x, 3000))
        .Where(x => !x.Passed)
        .ToArray();

      if (!failedTestResults.Any())
        return;
      
      var exceptionMessageBuilder = new StringBuilder();
      
      foreach (var testResult in failedTestResults) 
        exceptionMessageBuilder.AppendLine(testResult.Details);
      
      throw new XunitException(exceptionMessageBuilder.ToString());
    }

    private static TestResult TestModel(PathData path, int polygonCountLimit)
    {
      try
      {
        var mdx = new MDX(path.AbsolutePath);

        if (mdx.Geosets == null)
          return new TestResult
          {
            Passed = true,
            Details = $"{path.RelativePath} has no geosets."
          };

        var animationNames = mdx.Sequences.Select(x => x.Name);
        if (!animationNames.Contains("walk"))
          return new TestResult
          {
            Passed = true,
            Details = $"{path.RelativePath} is not a unit model."
          };

        var polygonCount = mdx.Geosets.SelectMany(x => x.VertexNormals).Count();

        if (polygonCount > polygonCountLimit)
        {
          return new TestResult
          {
            Passed = false,
            Details = $"{path.RelativePath} has an excessive polygon count of {polygonCount}."
          };
        }

        return new TestResult
        {
          Passed = true
        };
      }
      catch (Exception)
      {
        return new TestResult
        {
          Passed = true
        };
      }
    }

    private IEnumerable<PathData> GetAllImportedModels()
    {
      var additionalFiles = _mapTestFixture.AdditionalFiles;

      if (!additionalFiles.Any())
        throw new InvalidOperationException($"{nameof(MapDataProvider)} returned no additional files to test.");

      foreach (var pathData in MapDataProvider.GetMapData().AdditionalFiles)
        if (pathData.AbsolutePath.IsModelPath())
          yield return pathData;
    }

    private readonly struct TestResult
    {
      public required bool Passed { get; init; }
      
      public string? Details { get; init; }
    }
  }
}