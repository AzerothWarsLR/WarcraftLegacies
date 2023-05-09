using System.Collections.Immutable;
using System.Linq;
using DesyncSafeAnalyzer.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DesyncSafeAnalyzer.Analyzers
{
  [DiagnosticAnalyzer(LanguageNames.CSharp)]
  public sealed class PropertyAccessAnalyzer : DiagnosticAnalyzer
  {
    private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
      "ZB004",
      "Property access may cause desynchronization",
      "Functions marked with the [DesyncSafe] attribute cannot set properties that are not marked with the [Desynchronizable] attribute.",
      "Usage",
      DiagnosticSeverity.Error,
      true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
      ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
      context.EnableConcurrentExecution();
      context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
      context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.SimpleAssignmentExpression);
    }

    private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
    {
      var assignment = (AssignmentExpressionSyntax)context.Node;

      // Check if the left-hand side of the assignment is a property
      if (!(context.SemanticModel.GetSymbolInfo(assignment.Left).Symbol is IPropertySymbol propertySymbol))
        return;

      // Check if the property is marked with the Desynchronizable attribute
      if (propertySymbol.GetAttributes().Any(ad => ad.AttributeClass.Name == "Desynchronizable"))
        return;

      // Check if the method containing the assignment is marked with the DesyncSafe attribute
      if (!(context.ContainingSymbol is IMethodSymbol methodSymbol) || !methodSymbol.GetAttributes().Any(ad => ad.AttributeClass.Name == nameof(DesyncSafeAttribute)))
        return;

      // Report a diagnostic if the property is being set but is not marked with the Desynchronizable attribute
      var diagnostic = Diagnostic.Create(Rule, assignment.GetLocation());
      context.ReportDiagnostic(diagnostic);
    }
  }
}