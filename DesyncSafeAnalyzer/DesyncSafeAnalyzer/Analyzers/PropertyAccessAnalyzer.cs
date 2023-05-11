using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DesyncSafeAnalyzer.Analyzers
{
  [DiagnosticAnalyzer(LanguageNames.CSharp)]
  public sealed class PropertyAccessAnalyzer : DiagnosticAnalyzer
  {
    private const string DiagnosticId = "ZB005";
    private const string Category = "Usage";

    private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
      DiagnosticId,
      "Do not access or modify properties from functions with the [DesyncSafe] attribute",
      "Do not access property '{0}' from a function marked as [DesyncSafe]",
      Category,
      DiagnosticSeverity.Error,
      isEnabledByDefault: true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
      context.EnableConcurrentExecution();
      context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
      context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.PropertyDeclaration);
    }

    private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
    {
      var propertyDeclaration = (PropertyDeclarationSyntax)context.Node;

      var referencingMethods = GetReferencingMethods(propertyDeclaration, context.Compilation);
      foreach (var referencingMethod in referencingMethods)
      {
        if (HasDesyncSafeAttribute(referencingMethod))
          context.ReportDiagnostic(Diagnostic.Create(Rule, referencingMethod.Identifier.GetLocation(),
            propertyDeclaration.Identifier));
      }
    }

    private static bool HasDesyncSafeAttribute(MethodDeclarationSyntax methodDeclaration)
    {
      return methodDeclaration.AttributeLists
        .SelectMany(list => list.Attributes)
        .Any(attribute =>
          attribute.Name.ToString() == "DesyncSafe");
    }

    private static IEnumerable<MethodDeclarationSyntax> GetReferencingMethods(PropertyDeclarationSyntax propertyDeclaration, Compilation compilation)
    {
      var symbol = compilation.GetSemanticModel(propertyDeclaration.SyntaxTree).GetDeclaredSymbol(propertyDeclaration);
      if (symbol == null) 
        return Enumerable.Empty<MethodDeclarationSyntax>();
      
      var referencingMethods = compilation.SyntaxTrees
        .SelectMany(tree => tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>())
        .Where(method =>
          method.Body != null && // Skip methods without a body
          method.Body.DescendantNodes().OfType<IdentifierNameSyntax>().Any(identifier =>
            SymbolEqualityComparer.Default.Equals(compilation.GetSemanticModel(method.SyntaxTree).GetSymbolInfo(identifier).Symbol, symbol)));
      return referencingMethods;
    }
  }
}