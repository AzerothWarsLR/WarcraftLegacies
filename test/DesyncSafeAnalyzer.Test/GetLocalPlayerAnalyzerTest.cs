using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using Xunit;

namespace DesyncSafeAnalyzer.Test
{
  public sealed class GetLocalPlayerAnalyzerTest
  {
    private const string SourceCode = @"

class Program
{
    public static void Main()
    {
        GetLocalPlayer();
    }

    public static void GetLocalPlayer() {}
}
";
  
    [Fact]
    public async void SingleUseOfGetLocalPlayer_DisplaysError()
    {
      var analyzerTest = new CSharpAnalyzerTest<GetLocalPlayerAnalyzer, MSTestVerifier>
      {
        TestState =
        {
          Sources = { SourceCode }
        }
      };
      analyzerTest.ExpectedDiagnostics.Add(new DiagnosticResult
      (
        "ZB000",
        DiagnosticSeverity.Error
      ).WithLocation(7, 9));
      await analyzerTest.RunAsync();
    }
  }
}