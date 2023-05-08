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
    public async void InvokeForClient_LambdaExpressionCallingNonDesyncSafeFunction_DiagnosesError()
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
        "ZB003",
        DiagnosticSeverity.Error
      ).WithLocation(8, 33));
      await analyzerTest.RunAsync();
    }
    
    [Fact]
    public async void InvokeForClient_LambdaExpressionCallingDesyncSafeCustomFunction_NoDiagnosis()
    {
      const string sourceCode = @"
using System;

class DesyncSafeAttribute : Attribute {}

class Program
{
    public static void Main()
    {
        Program.InvokeForClient(() => { Beans(); }, string.Empty);
    }

    [DesyncSafe]
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
      await analyzerTest.RunAsync();
    }

    [Fact]
    public async void InvokeForClient_LambdaExpressionCallingDesyncSafeNative_NoDiagnosis()
    {
      const string sourceCode = @"
using System;

class DesyncSafeAttribute : Attribute {}

class Program
{
    public static void Main()
    {
        Program.InvokeForClient(() => { StartSound(); }, string.Empty);
    }

    public static void StartSound() {}

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
      await analyzerTest.RunAsync();
    }
    
    [Fact]
    public async void InvokeForClient_ConcreteFunctionNonDesyncSafe_DiagnosesError()
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