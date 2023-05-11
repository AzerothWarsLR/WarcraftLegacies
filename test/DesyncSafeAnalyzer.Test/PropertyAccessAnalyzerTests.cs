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
    [Fact]
    public async void SetOwnPropertyFromDesyncSafeMethod_DiagnosesError()
    {
      const string sourceCode = @"
using System;

class DesyncSafeAttribute : Attribute {}

class OtherObject {
    public int ExampleProperty { get; set; }
}

class Program
{
    [DesyncSafe]
    public static void Main()
    {
        var x = new OtherObject();
        x.ExampleProperty = 1;
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
      ).WithLocation(16, 9));
      await analyzerTest.RunAsync();
    }
    
    [Fact]
    public async void SetExternalPropertyFromDesyncSafeMethod_DiagnosesError()
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
    public async void GetPropertyFromDesyncSafeMethod_RaisesNoError()
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
        var x = ExampleProperty;
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
      await analyzerTest.RunAsync();
    }
  }
}