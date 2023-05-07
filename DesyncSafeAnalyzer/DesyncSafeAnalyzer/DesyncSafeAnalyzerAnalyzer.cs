using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace DesyncSafeAnalyzer
{
  [DiagnosticAnalyzer(LanguageNames.CSharp)]
  public class DesyncSafeAnalyzer : DiagnosticAnalyzer
  {
    private const string Category = "Usage";
    private const string Title = "DesyncSafe method usage warning";
    private const string Message = "Calling a DesyncSafe method from a non-DesyncSafe method.";

    private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
      "DS001",
      Title,
      Message,
      Category,
      DiagnosticSeverity.Error,
      isEnabledByDefault: true);

    private static readonly SymbolDisplayFormat MethodDisplayFormat =
      new SymbolDisplayFormat(
        typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
        genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
        parameterOptions: SymbolDisplayParameterOptions.IncludeName | SymbolDisplayParameterOptions.IncludeType,
        memberOptions: SymbolDisplayMemberOptions.IncludeParameters,
        miscellaneousOptions: SymbolDisplayMiscellaneousOptions.UseSpecialTypes);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
      context.EnableConcurrentExecution();
      context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze |
                                             GeneratedCodeAnalysisFlags.ReportDiagnostics);
      context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.InvocationExpression);
    }

    private void AnalyzeNode(SyntaxNodeAnalysisContext context)
    {
      var invocation = (InvocationExpressionSyntax)context.Node;
      var methodSymbol = context.SemanticModel.GetSymbolInfo(invocation).Symbol;

      if (methodSymbol == null)
      {
        return;
      }
      
      var calledMethodAttributes = methodSymbol.GetAttributes();
      var callerMethodSymbol = invocation.Ancestors().OfType<MethodDeclarationSyntax>().FirstOrDefault();
      if (callerMethodSymbol == null)
        return;
      
      var callerMethodAttributes = context.SemanticModel.GetDeclaredSymbol(callerMethodSymbol).GetAttributes();
      if (callerMethodAttributes.Any(attr => attr.AttributeClass.Name.Contains("DesyncSafe")))
        return;
      
      if (!calledMethodAttributes.Any(attr => attr.AttributeClass.Name.Contains("DesyncSafe")))
        return;
      
      var methodName = methodSymbol.ToDisplayString(MethodDisplayFormat);
      var diagnostic = Diagnostic.Create(Rule, invocation.GetLocation(), methodName);
      context.ReportDiagnostic(diagnostic);
    }
  }
}