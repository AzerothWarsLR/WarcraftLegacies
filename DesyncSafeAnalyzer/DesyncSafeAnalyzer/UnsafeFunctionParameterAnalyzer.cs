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
    private const string DesyncSafeAttributeName = "DesyncSafeAttribute";

    private static readonly DiagnosticDescriptor LambdaExpressionRule = new DiagnosticDescriptor(
      "ZB003",
      "Unsafe use of InvokeForClient",
      "Lambda expressions passed to InvokeForClient can only call native desync-safe functions or custom functions marked with the [DesyncSafe] attribute.",
      "Usage",
      DiagnosticSeverity.Error,
      true);

    private static readonly DiagnosticDescriptor ConcreteFunctionRule = new DiagnosticDescriptor(
      "ZB004",
      "Unsafe use of InvokeForClient",
      "Concrete function passed to InvokeForClient must be marked with the [DesyncSafe] attribute.",
      "Usage",
      DiagnosticSeverity.Error,
      true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
      ImmutableArray.Create(LambdaExpressionRule, ConcreteFunctionRule);

    public override void Initialize(AnalysisContext context)
    {
      context.EnableConcurrentExecution();
      context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
      context.RegisterSyntaxNodeAction(AnalyzeInvocation, SyntaxKind.InvocationExpression);
      context.RegisterSyntaxNodeAction(AnalyzeLambdaExpressions, SyntaxKind.ParenthesizedLambdaExpression,
        SyntaxKind.SimpleLambdaExpression);
    }

    private static void AnalyzeInvocation(SyntaxNodeAnalysisContext context)
    {
      CheckConcreteRule(context);
    }

    private static void CheckConcreteRule(SyntaxNodeAnalysisContext context)
    {
      if (!(context.Node is InvocationExpressionSyntax invocation) ||
          !(invocation.Expression is MemberAccessExpressionSyntax memberAccess) ||
          memberAccess.Name.Identifier.Text != "InvokeForClient")
        return;

      var argumentList = invocation.ArgumentList;
      var actionExpression = argumentList.Arguments[0].Expression;

      if (!(actionExpression is IdentifierNameSyntax actionArg))
        return;

      var actionSymbol = context.SemanticModel.GetSymbolInfo(actionArg).Symbol;

      if (!(actionSymbol is IMethodSymbol actionMethod))
        return;

      var desyncSafeAttribute =
        actionMethod.GetAttributes().FirstOrDefault(attr => attr.AttributeClass.Name == DesyncSafeAttributeName);
      if (desyncSafeAttribute != null)
        return;

      var diagnostic2 = Diagnostic.Create(ConcreteFunctionRule, actionArg?.GetLocation());
      context.ReportDiagnostic(diagnostic2);
    }

    private static void AnalyzeLambdaExpressions(SyntaxNodeAnalysisContext context)
    {
      var lambda = (LambdaExpressionSyntax)context.Node;

      // Check if the lambda is an argument to InvokeForClient.
      var invokeForClientInvocation = lambda.Ancestors()
        .OfType<InvocationExpressionSyntax>()
        .FirstOrDefault(invocation => invocation.Expression is MemberAccessExpressionSyntax identifier &&
                                      identifier.Name.Identifier.ValueText.Contains("InvokeForClient"));

      if (invokeForClientInvocation == null)
      {
        return;
      }

      // Collect all invoked method symbols within the lambda.
      var invokedMethodSymbols = lambda.DescendantNodes()
        .OfType<InvocationExpressionSyntax>()
        .Select(invocation => context.SemanticModel.GetSymbolInfo(invocation.Expression).Symbol)
        .OfType<IMethodSymbol>()
        .ToList();

      // Check if any invoked methods are missing the DesyncSafe attribute.
      var violatingMethods = invokedMethodSymbols
        .Where(method => !(method.GetAttributes().Any(attribute => attribute.AttributeClass.Name == DesyncSafeAttributeName) 
                         || DesyncSafeNatives.IsSafe(method.Name)))
        .ToList();

      if (!violatingMethods.Any())
        return;

      var location = lambda.GetLocation();
      foreach (var method in violatingMethods)
      {
        var diagnostic = Diagnostic.Create(LambdaExpressionRule, location, method.Name);
        context.ReportDiagnostic(diagnostic);
      }
    }
  }
}