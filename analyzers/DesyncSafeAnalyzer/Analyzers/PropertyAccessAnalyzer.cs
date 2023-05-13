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

    private static readonly DiagnosticDescriptor Rule = new(
      DiagnosticId,
      "Do not modify properties from functions with the [DesyncSafe] attribute",
      "DesyncSafe function {0} cannot modify synchronized property {1}",
      Category,
      DiagnosticSeverity.Error,
      isEnabledByDefault: true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
      context.EnableConcurrentExecution();
      context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze |
                                             GeneratedCodeAnalysisFlags.ReportDiagnostics);
      context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.SimpleAssignmentExpression);
    }

    private static void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
    {
      var assignmentExpression = (AssignmentExpressionSyntax)context.Node;

      var identifier = GetAssignedPropertyIdentifier(assignmentExpression);
      if (identifier == null)
        return;

      var symbol = context.SemanticModel.GetSymbolInfo(identifier).Symbol;

      if (symbol?.Kind != SymbolKind.Field &&
          (symbol?.Kind != SymbolKind.Property || ((IPropertySymbol)symbol).SetMethod == null)) return;

      var containingMethod = identifier.FirstAncestorOrSelf<MethodDeclarationSyntax>();
      var desyncSafeAttribute = containingMethod?.AttributeLists
        .SelectMany(list => list.Attributes)
        .FirstOrDefault(attr => attr.Name.ToString() == "DesyncSafe");

      if (desyncSafeAttribute == null)
        return;

      var diagnostic = Diagnostic.Create(Rule, identifier.GetLocation(), containingMethod?.Identifier, symbol.Name);
      context.ReportDiagnostic(diagnostic);
    }
    
    /// <summary>
    /// Gets the property being assigned within a property assignment.
    /// </summary>
    private static IdentifierNameSyntax? GetAssignedPropertyIdentifier(AssignmentExpressionSyntax assignmentExpression)
    {
      var leftOperand = assignmentExpression.Left;
      return leftOperand switch
      {
        MemberAccessExpressionSyntax { Name: IdentifierNameSyntax propertySyntax } => propertySyntax,
        IdentifierNameSyntax propertySyntax => propertySyntax,
        _ => null
      };
    }
  }
}