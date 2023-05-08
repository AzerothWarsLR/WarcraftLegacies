using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using Xunit;

namespace DesyncSafeAnalyzer.Test
{
  public sealed class UnsafeFunctionParameterAnalyzerTests
  {
    private const string SourceCode = @"
using System;

class Program
{
    public static void Main()
    {
        Program.InvokeForClient(Beans, string.Empty);
    }

    public static void Beans() {}

    public static void InvokeForClient(Action action, string nothing) {}
}
";
  
    [Fact]
    public async void PassingNonDesyncSafeFunctionToInvokeForClient_DiagnosesError()
    {
      var analyzerTest = new CSharpAnalyzerTest<UnsafeFunctionParameterAnalyzer, MSTestVerifier>
      {
        TestState =
        {
          Sources = { SourceCode }
        }
      };
      analyzerTest.ExpectedDiagnostics.Add(new DiagnosticResult
      (
        "ZB004",
        DiagnosticSeverity.Error
      ).WithLocation(8, 33));
      await analyzerTest.RunAsync();
    }
  }
}