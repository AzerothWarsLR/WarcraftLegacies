using ModelTester;
using ModelTester.Objects;
using Xunit.Abstractions;

namespace WarcraftLegacies.Test;

public class UnitTest1
{
  private readonly ITestOutputHelper _testOutputHelper;

  public UnitTest1(ITestOutputHelper testOutputHelper)
  {
    _testOutputHelper = testOutputHelper;
  }

  [Fact]
  public void TestModel()
  {
    var mdx = new MDX(@"C:\Users\zakar\RiderProjects\WarcraftLegacies\maps\source.w3x\war3mapImported\AdmiralsEliteGuard.mdx");
    TestSequences(mdx);
  }

  private void TestSequences(MDX modelToTest)
  {
    foreach (var sequence in modelToTest.Sequences)
      TestSequence(sequence);
  }

  private void TestSequence(Sequence sequence)
  {
    _testOutputHelper.WriteLine(sequence.Name);
  }
}