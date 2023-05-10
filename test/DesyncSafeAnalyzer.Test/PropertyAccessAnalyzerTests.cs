using DesyncSafeAnalyzer.Analyzers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using Xunit;

namespace DesyncSafeAnalyzer.Test
{
  public sealed class PropertyAccessAnalyzerTests
  {
    public sealed class UnsafeFunctionParameterAnalyzerTests
    {
      [Fact]
      public async void SettingNormalPropertyFromDesyncSafeMethod_DiagnosesError()
      {
        const string sourceCode = @"
using System;

class DesyncSafeAttribute : Attribute {}

class Program
{
    public static int ExampleProperty { get; set; }

    [DesyncSafe]
    public static void Main()
    {
        ExampleProperty = 1;
    }
}
";

        var analyzerTest = new CSharpAnalyzerTest<PropertyAccessAnalyzer, MSTestVerifier>
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
        ).WithLocation(13, 9));
        await analyzerTest.RunAsync();
      }
      
      [Fact]
      public async void GettingDesynchronizablePropertyFromNonDesyncSafeMethod_DiagnosesError()
      {
        const string sourceCode = @"
using System;

class DesynchronizableAttribute : Attribute {}

class Test { 
  public int ExampleProperty { get; set; } = 0;
}

class Program
{
    [Desynchronizable]
    public static int ExampleProperty { get; set; }

    public static void Main()
    {
        var test = ExampleProperty;
        var beans = new Test();
        var x = beans.ExampleProperty;
    }
}
";

        var analyzerTest = new CSharpAnalyzerTest<PropertyAccessAnalyzer, MSTestVerifier>
        {
          TestState =
          {
            Sources = { sourceCode }
          }
        };
        analyzerTest.ExpectedDiagnostics.Add(new DiagnosticResult
        (
          "ZB006",
          DiagnosticSeverity.Error
        ).WithLocation(13, 9));
        await analyzerTest.RunAsync();
      }
    }
  }
}