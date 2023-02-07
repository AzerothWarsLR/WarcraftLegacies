using ModelTester;
using WarcraftLegacies.Test.Extensions;

namespace WarcraftLegacies.Test;

/// <summary>
/// Test every model in the game for major issues.
/// </summary>
public sealed class TestAllModels
{
  [Theory]
  [MemberData(nameof(AllModels))]
  public void TestModel(ModelPath modelPath)
  {
    var mdx = new MDX(modelPath.FilePath);
    TestSequences(mdx);
  }

  public static IEnumerable<object[]> AllModels =>
    Directory.EnumerateFiles(
      @"..\..\..\..\..\maps\source.w3x\war3mapImported", "*.mdx", SearchOption.AllDirectories)
      .Select(file => new object[] { new ModelPath(file) });

  private static void TestSequences(MDX modelToTest)
  {
    var hasStandAnimation = false;
    var hasDeathAnimation = false;
    
    foreach (var sequence in modelToTest.Sequences)
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

    if (!modelToTest.Info.Name.Contains("_portrait", StringComparison.OrdinalIgnoreCase))
    {
      hasStandAnimation.Should().BeTrue("the model should have a stand animation");
      hasDeathAnimation.Should().BeTrue("the model should have a death animation");
    }
  }
}