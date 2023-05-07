using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DesyncSafeAnalyzer
{
  [DiagnosticAnalyzer(LanguageNames.CSharp)]
  public class GetLocalPlayerAnalyzer : DiagnosticAnalyzer
  {
    private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
      "GetLocalPlayerAnalyzer",
      "Do not call GetLocalPlayer method",
      "Calling GetLocalPlayer method is not allowed",
      "Naming",
      DiagnosticSeverity.Error,
      true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
      context.EnableConcurrentExecution();
      context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
      context.RegisterSyntaxNodeAction(AnalyzeInvocation, SyntaxKind.InvocationExpression);
    }

    private static void AnalyzeInvocation(SyntaxNodeAnalysisContext context)
    {
      var invocation = context.Node as InvocationExpressionSyntax;

      if (!(invocation?.Expression is IdentifierNameSyntax memberAccess)) 
        return;

      if (!memberAccess.Identifier.ValueText.Contains("GetLocalPlayer")) 
        return;

      context.ReportDiagnostic(Diagnostic.Create(Rule, invocation.GetLocation()));
    }
  }
}