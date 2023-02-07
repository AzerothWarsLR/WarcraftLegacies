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
    var foundStand = false;
    var foundDeath = false;
    
    foreach (var sequence in modelToTest.Sequences)
    {
      var token = sequence.GetToken();
      switch (token)
      {
        case "stand":
          foundStand = true;
          break;
        case "death":
          foundDeath = true;
          break;
      }
    }

    if (!modelToTest.Info.Name.Contains("_portrait", StringComparison.InvariantCultureIgnoreCase))
    {
      foundStand.Should().BeTrue("the model should have a stand animation");
      foundDeath.Should().BeTrue("the model should have a death animation");
    }
  }
}