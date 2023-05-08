using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using Xunit;

namespace DesyncSafeAnalyzer.Test
{
  public sealed class UnsafeFunctionParameterAnalyzerTests
  {
    [Fact]
    public async void InvokeForClient_NonDesyncSafeLambdaExpression_DiagnosesError()
    {
      const string sourceCode = @"
using System;

class Program
{
    public static void Main()
    {
        Program.InvokeForClient(() => { Beans(); }, string.Empty);
    }

    public static void Beans() {}

    public static void InvokeForClient(Action action, string nothing) {}
}
";

      var analyzerTest = new CSharpAnalyzerTest<UnsafeFunctionParameterAnalyzer, MSTestVerifier>
      {
        TestState =
        {
          Sources = { sourceCode }
        }
      };
      analyzerTest.ExpectedDiagnostics.Add(new DiagnosticResult
      (
        "ZB005",
        DiagnosticSeverity.Error
      ).WithLocation(8, 33));
      await analyzerTest.RunAsync();
    }

    [Fact]
    public async void InvokeForClient_NonDesyncSafeConcreteFunction_DiagnosesError()
    {
      const string sourceCode = @"
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

      var analyzerTest = new CSharpAnalyzerTest<UnsafeFunctionParameterAnalyzer, MSTestVerifier>
      {
        TestState =
        {
          Sources = { sourceCode }
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