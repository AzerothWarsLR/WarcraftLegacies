using System.Text.Json;
using System.Text.Json.Serialization;
using ModelTester;
using WarcraftLegacies.Test.Extensions;

namespace WarcraftLegacies.Test;

/// <summary>
/// Test every model in the game for major issues.
/// </summary>
public sealed class TestAllModels
{
  private readonly Dictionary<string, ModelAnnotation> _modelAnnotations;

  public TestAllModels()
  {
    var options = new JsonSerializerOptions
    {
      WriteIndented = true,
      Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
    };

    _modelAnnotations =
      JsonSerializer.Deserialize<Dictionary<string, ModelAnnotation>>(
        File.ReadAllText("../../../ModelAnnotations.json"), options) ??
      throw new Exception("Failed to read ModelAnnotations");
  }

  [Theory]
  [MemberData(nameof(AllModels))]
  public void TestModel(ModelPath modelPath)
  {
    var modelName = Path.GetFileName(modelPath.FilePath);
    _modelAnnotations.TryGetValue(modelName, out var modelAnnotation);
    var annotatedModel = new AnnotatedModel(new MDX(modelPath.FilePath), modelAnnotation); 
    TestSequences(annotatedModel);
  }

  public static IEnumerable<object[]> AllModels =>
    Directory.EnumerateFiles(
        @"..\..\..\..\..\maps\source.w3x\war3mapImported", "*.mdx", SearchOption.AllDirectories)
      .Select(file => new object[] { new ModelPath(file) });

  private static void TestSequences(AnnotatedModel annotatedModel)
  {
    var hasStandAnimation = false;
    var hasDeathAnimation = false;

    foreach (var sequence in annotatedModel.Model.Sequences)
    {
      var token = sequence.GetToken();
      switch (token)
      {
        case "stand":
          hasStandAnimation = true;
          break;
        case "death":
          hasDeathAnimation = true;
          break;
      }
    }

    if (!annotatedModel.Model.Info.Name.Contains("_portrait", StringComparison.OrdinalIgnoreCase))
    {
      hasStandAnimation.Should().BeTrue("the model should have a stand animation");
      hasDeathAnimation.Should().BeTrue("the model should have a death animation");
    }
  }
}