using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace DesyncSafeAnalyzer
{
  [DiagnosticAnalyzer(LanguageNames.CSharp)]
  public class DesyncSafeMethodRestrictionsAnalyzer : DiagnosticAnalyzer
  {
    private const string Category = "Usage";
    private const string Title = "DesyncSafe method restrictions";
    private const string Message = "Cannot call a non-DesyncSafe method from a DesyncSafe method.";

    private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
      "ZB001",
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
      
      if (!callerMethodAttributes.Any(attr => attr.AttributeClass.Name == "DesyncSafeAttribute"))
        return;

      if (MethodIsDesyncSafe(context, invocation))
        return;

      var methodName = methodSymbol.ToDisplayString(MethodDisplayFormat);
      var diagnostic = Diagnostic.Create(Rule, invocation.GetLocation(), methodName);
      context.ReportDiagnostic(diagnostic);
    }

    private static bool MethodIsDesyncSafe(SyntaxNodeAnalysisContext context, InvocationExpressionSyntax invocation)
    {
      var methodSymbol = context.SemanticModel.GetSymbolInfo(invocation).Symbol;
      var methodAttributes = methodSymbol.GetAttributes();

      if (invocation.Expression is IdentifierNameSyntax identifier &&
          SafeFunctions.Contains(identifier.Identifier.ValueText))
        return true;
      
      return methodAttributes.Any(attr => attr.AttributeClass.Name == "DesyncSafeAttribute");
    }
    
    private static readonly List<string> SafeFunctions = new List<string>
    {
      "BlzSetSpecialEffectColor",
      "BlzSetSpecialEffectColorByPlayer",
      "StartSound"
    };
  }
}