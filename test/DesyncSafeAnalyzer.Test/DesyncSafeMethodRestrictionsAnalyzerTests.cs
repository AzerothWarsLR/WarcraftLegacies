using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using Xunit;

namespace DesyncSafeAnalyzer.Test
{
  public sealed class DesyncSafeMethodRestrictionsAnalyzerTests
  {
    private const string SourceCode = @"

using System;

class Program
{
    [DesyncSafe]
    public static void Main()
    {
        GetLocalPlayer();
    }

    public static void GetLocalPlayer() {}
}

class DesyncSafeAttribute : Attribute { }
";
  
    [Fact]
    public async void CallingNonDesyncSafeMethodFromDesyncSafeMethod_DisplaysError()
    {
      var analyzerTest = new CSharpAnalyzerTest<DesyncSafeMethodRestrictionsAnalyzer, MSTestVerifier>
      {
        TestState =
        {
          Sources = { SourceCode }
        }
      };
      analyzerTest.ExpectedDiagnostics.Add(new DiagnosticResult
      (
        "ZB001",
        DiagnosticSeverity.Error
      ).WithLocation(10, 9));
      await analyzerTest.RunAsync();
    }
  }
}