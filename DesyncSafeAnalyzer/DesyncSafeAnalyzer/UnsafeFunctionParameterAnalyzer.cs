using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DesyncSafeAnalyzer
{
  [DiagnosticAnalyzer(LanguageNames.CSharp)]
  public class UnsafeFunctionParameterAnalyzer : DiagnosticAnalyzer
  {
    private static readonly DiagnosticDescriptor Rule1 = new DiagnosticDescriptor(
      "AN001",
      "Anonymous functions are not allowed",
      "Anonymous functions are not allowed as parameters to InvokeForClient method.",
      "Usage",
      DiagnosticSeverity.Error,
      true);

    private static readonly DiagnosticDescriptor Rule2 = new DiagnosticDescriptor(
      "AN002",
      "Unsafe use of Action parameter",
      "Actions passed as parameters to InvokeForClient method must be marked with the [DesyncSafe] attribute.",
      "Usage",
      DiagnosticSeverity.Error,
      true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule1, Rule2);

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

      if (argumentList.Arguments[0].Expression is AnonymousFunctionExpressionSyntax)
      {
        var diagnostic1 = Diagnostic.Create(Rule1, argumentList.Arguments[0].GetLocation());
        context.ReportDiagnostic(diagnostic1);
        return;
      }

      var actionArg = argumentList.Arguments[0].Expression as IdentifierNameSyntax;
      var actionSymbol = context.SemanticModel.GetSymbolInfo(actionArg).Symbol;

      if (!(actionSymbol is IMethodSymbol actionMethod))
        return;
      
      var desyncSafeAttribute =
        actionMethod.GetAttributes().FirstOrDefault(attr => attr.AttributeClass?.Name == "DesyncSafe");
      if (desyncSafeAttribute != null)
        return;

      var diagnostic2 = Diagnostic.Create(Rule2, actionArg?.GetLocation());
      context.ReportDiagnostic(diagnostic2);
    }
  }
}