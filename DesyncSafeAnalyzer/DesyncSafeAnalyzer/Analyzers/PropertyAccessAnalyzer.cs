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
    private static readonly DiagnosticDescriptor NonDesynchronizableAccessRule = new DiagnosticDescriptor(
      "ZB005",
      "Property access may cause desynchronization",
      "Functions marked with the [DesyncSafe] attribute cannot set properties that are not marked with the [Desynchronizable] attribute.",
      "Usage",
      DiagnosticSeverity.Error,
      true);
    
    private static readonly DiagnosticDescriptor DesynchronizableAccessRule = new DiagnosticDescriptor(
      "ZB006",
      "Property access may cause desynchronization",
      "Functions not marked with the [DesyncSafe] attribute cannot get properties that are marked with the [Desynchronizable] attribute.",
      "Usage",
      DiagnosticSeverity.Error,
      true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
      ImmutableArray.Create(NonDesynchronizableAccessRule, DesynchronizableAccessRule);

    public override void Initialize(AnalysisContext context)
    {
      context.EnableConcurrentExecution();
      context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
      context.RegisterSyntaxNodeAction(AnalyzeNonDesynchronizableAttribute, SyntaxKind.SimpleAssignmentExpression);
      context.RegisterSyntaxNodeAction(AnalyzeDesynchronizableAttribute, SyntaxKind.SimpleMemberAccessExpression);
    }

    private static void AnalyzeNonDesynchronizableAttribute(SyntaxNodeAnalysisContext context)
    {
      var assignment = (AssignmentExpressionSyntax)context.Node;
      
      if (!(context.SemanticModel.GetSymbolInfo(assignment.Left).Symbol is IPropertySymbol propertySymbol))
        return;
      
      if (propertySymbol.GetAttributes().Any(ad => ad.AttributeClass.Name == nameof(DesynchronizableAttribute)))
        return;
      
      if (!(context.ContainingSymbol is IMethodSymbol methodSymbol) || !methodSymbol.GetAttributes().Any(ad => ad.AttributeClass.Name == nameof(DesyncSafeAttribute)))
        return;
      
      var diagnostic = Diagnostic.Create(NonDesynchronizableAccessRule, assignment.GetLocation());
      context.ReportDiagnostic(diagnostic);
    }

    private static void AnalyzeDesynchronizableAttribute(SyntaxNodeAnalysisContext context)
    {
      if (!(context.Node is MemberAccessExpressionSyntax memberAccess))
        return;

      if (!(memberAccess.Expression is IdentifierNameSyntax identifierName))
        return;

      if (!(context.SemanticModel.GetSymbolInfo(identifierName).Symbol is IPropertySymbol propertySymbol))
        return;

      if (!propertySymbol.GetAttributes().Any(attr => attr.AttributeClass?.Name == "DesynchronizableAttribute"))
        return;

      var enclosingMethod = memberAccess.Ancestors().OfType<MethodDeclarationSyntax>().FirstOrDefault();
      if (enclosingMethod == null)
        return;

      if (enclosingMethod.AttributeLists.SelectMany(al => al.Attributes).Any(attr => attr.Name.ToString() == "DesyncSafeAttribute")) 
        return;
      
      var diagnostic = Diagnostic.Create(DesynchronizableAccessRule, memberAccess.GetLocation(), propertySymbol.Name);
      context.ReportDiagnostic(diagnostic);
    }
  }
}