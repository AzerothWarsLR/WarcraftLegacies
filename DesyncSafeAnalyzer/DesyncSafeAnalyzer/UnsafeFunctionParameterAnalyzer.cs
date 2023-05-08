using System.Collections.Generic;
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
    private const string DesyncSafeAttributeName = "DesyncSafe";
    
    private static readonly DiagnosticDescriptor AnonymousFunctionRule = new DiagnosticDescriptor(
      "ZB003",
      "Unsafe use of Action parameter",
      "Lambda expressions passed to InvokeForClient should only contain functions marked with the [DesyncSafe] attribute.",
      "Usage",
      DiagnosticSeverity.Warning,
      true);

    private static readonly DiagnosticDescriptor ConcreteFunctionRule = new DiagnosticDescriptor(
      "ZB004",
      "Unsafe use of Action parameter",
      "Concrete function passed to InvokeForClient must be marked with the [DesyncSafe] attribute.",
      "Usage",
      DiagnosticSeverity.Error,
      true);

    private static readonly DiagnosticDescriptor AnonymousFunctionContainsUnsafeMethod =
      new DiagnosticDescriptor(
        id: "ZB005",
        title: "Anonymous function contains unsafe method",
        messageFormat: "Anonymous function passed to 'InvokeForClient' contains a method that is not marked as [DesyncSafe]",
        category: "Usage",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(AnonymousFunctionRule, ConcreteFunctionRule, AnonymousFunctionContainsUnsafeMethod);

    public override void Initialize(AnalysisContext context)
    {
      context.EnableConcurrentExecution();
      context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
      context.RegisterSyntaxNodeAction(AnalyzeInvocation, SyntaxKind.InvocationExpression);
      context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.Argument);
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
        actionMethod.GetAttributes().FirstOrDefault(attr => attr.AttributeClass.Name.Contains("DesyncSafe"));
      if (desyncSafeAttribute != null)
        return;

      var diagnostic2 = Diagnostic.Create(ConcreteFunctionRule, actionArg?.GetLocation());
      context.ReportDiagnostic(diagnostic2);
    }
    
    private static void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
    {
      var argumentSyntax = (ArgumentSyntax)context.Node;

      if (!(argumentSyntax.Expression is LambdaExpressionSyntax lambda))
        return;

      if (!(argumentSyntax.Parent is ArgumentListSyntax argumentList))
        return;

      if (!(argumentList.Parent is InvocationExpressionSyntax parentInvocation))
        return;

      if (!(parentInvocation.Expression is MemberAccessExpressionSyntax parentIdentifierNameSyntax) ||
          parentIdentifierNameSyntax.Name.Identifier.Text != "InvokeForClient")
        return;

      var containsUnsafeMethod = ContainsUnsafeMethod(lambda);

      if (!containsUnsafeMethod) 
        return;
      
      var diagnostic = Diagnostic.Create(
        AnonymousFunctionContainsUnsafeMethod,
        argumentSyntax.GetLocation());

      context.ReportDiagnostic(diagnostic);
    }

    private static bool ContainsUnsafeMethod(SyntaxNode lambdaExpressionSyntax)
    {
      var descendantMethods = lambdaExpressionSyntax.DescendantNodes().OfType<MethodDeclarationSyntax>();

      return descendantMethods.Any(method => !method.AttributeLists
        .Any(attributeList => attributeList.Attributes
          .Any(attribute => attribute.Name.ToString().Contains(DesyncSafeAttributeName))));
    }
    
    private static bool HasDesyncSafeAttribute(ISymbol typeSymbol) =>
      typeSymbol.GetAttributes().Any(attr => attr.AttributeClass.Name.Contains(DesyncSafeAttributeName));
  }
}