using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DesyncSafeAnalyzer
{
  [DiagnosticAnalyzer(LanguageNames.CSharp)]
  public class UnsafeAnonymousFunctionParameterAnalyzer : DiagnosticAnalyzer
  {
    private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
      "AN001",
      "Anonymous functions are not allowed",
      "Anonymous functions are not allowed as parameters to InvokeForClient method. Pass in a concre method instead.",
      "Usage",
      DiagnosticSeverity.Error,
      true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
      context.EnableConcurrentExecution();
      context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
      context.RegisterSyntaxNodeAction(AnalyzeInvocation, SyntaxKind.InvocationExpression);
    }

    private static void AnalyzeInvocation(SyntaxNodeAnalysisContext context)
    {
      if (!(context.Node is InvocationExpressionSyntax invocation) ||
          !(invocation.Expression is MemberAccessExpressionSyntax memberAccess) ||
          memberAccess.Name.Identifier.Text != "InvokeForClient") 
        return;
    
      var argumentList = invocation.ArgumentList;
      if (!(argumentList.Arguments[0].Expression is AnonymousFunctionExpressionSyntax)) 
        return;
    
      var diagnostic = Diagnostic.Create(Rule, argumentList.Arguments[0].GetLocation());
      context.ReportDiagnostic(diagnostic);
    }
  }
}