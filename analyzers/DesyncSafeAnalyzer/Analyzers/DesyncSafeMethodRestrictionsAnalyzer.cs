using System.Collections.Immutable;
using System.Linq;
using DesyncSafeAnalyzer.Tools;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DesyncSafeAnalyzer.Analyzers
{
  [DiagnosticAnalyzer(LanguageNames.CSharp)]
  public sealed class DesyncSafeMethodRestrictionsAnalyzer : DiagnosticAnalyzer
  {
    private const string Category = "Desynchronizations";
    private const string Title = "DesyncSafe functions restrictions";
    private const string Message = "DesyncSafe functions can only call desync-safe natives or other DesyncSafe functions; {0} is not desync-safe.";

    private static readonly DiagnosticDescriptor Rule = new(
      "ZB001",
      Title,
      Message,
      Category,
      DiagnosticSeverity.Error,
      isEnabledByDefault: true);

    private static readonly SymbolDisplayFormat MethodDisplayFormat = new(
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

    private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
    {
      var invocation = (InvocationExpressionSyntax)context.Node;
      var methodSymbol = context.SemanticModel.GetSymbolInfo(invocation).Symbol;

      if (methodSymbol == null)
        return;
      
      var callerMethodSymbol = invocation.Ancestors().OfType<MethodDeclarationSyntax>().FirstOrDefault();
      if (callerMethodSymbol == null)
        return;
      
      var callerMethodAttributes = context.SemanticModel.GetDeclaredSymbol(callerMethodSymbol).GetAttributes();
      
      if (!callerMethodAttributes.Any(attr => attr.AttributeClass.Name == nameof(DesyncSafeAttribute)))
        return;

      if (Shared.IsMethodDesyncSafe(context.SemanticModel.GetSymbolInfo(invocation).Symbol as IMethodSymbol))
        return;

      var methodName = methodSymbol.ToDisplayString(MethodDisplayFormat);
      var diagnostic = Diagnostic.Create(Rule, invocation.GetLocation(), methodName);
      context.ReportDiagnostic(diagnostic);
    }
  }
}