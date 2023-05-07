using System;
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
      "AN001",
      "Unsafe use of Action parameter",
      "Lambda expressions passed to InvokeForClient should only contain functions marked with the [DesyncSafe] attribute.",
      "Usage",
      DiagnosticSeverity.Warning,
      true);

    private static readonly DiagnosticDescriptor ConcreteFunctionRule = new DiagnosticDescriptor(
      "AN002",
      "Unsafe use of Action parameter",
      "Concrete function passed to InvokeForClient must be marked with the [DesyncSafe] attribute.",
      "Usage",
      DiagnosticSeverity.Error,
      true);

    private static readonly DiagnosticDescriptor AnonymousFunctionContainsUnsafeMethod =
      new DiagnosticDescriptor(
        id: "AN003",
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
      CheckAnonymousRule(context);
      CheckConcreteRule(context);
    }

    private static void CheckAnonymousRule(SyntaxNodeAnalysisContext context)
    {
      if (!(context.Node is InvocationExpressionSyntax invocation) ||
          !(invocation.Expression is MemberAccessExpressionSyntax memberAccess) ||
          memberAccess.Name.Identifier.Text != "InvokeForClient")
        return;

      var argumentList = invocation.ArgumentList;
      var actionArg = argumentList.Arguments[0].Expression as IdentifierNameSyntax;
      var actionSymbol = context.SemanticModel.GetSymbolInfo(actionArg).Symbol;

      if (!(actionSymbol is IMethodSymbol actionMethod)) 
        return;
      
      var unsafeFunctions = new List<string>();
      foreach (var parameter in actionMethod.Parameters)
      {
        if (!(parameter.Type is INamedTypeSymbol namedType) ||
            namedType.ConstructedFrom.ToString() != "System.Action`1" ||
            namedType.TypeArguments.Length != 1) 
          continue;
          
        var functionType = namedType.TypeArguments[0];
        if (!HasDesyncSafeAttribute(functionType)) 
          unsafeFunctions.Add(parameter.Name);
      }

      if (!unsafeFunctions.Any()) 
        return;
      
      var message =
        $"The following functions within the '{actionArg.Identifier.Text}' parameter are not marked with the [DesyncSafe] attribute: {string.Join(", ", unsafeFunctions)}.";
      var diagnostic = Diagnostic.Create(AnonymousFunctionRule, actionArg.GetLocation(), message);
      context.ReportDiagnostic(diagnostic);
    }

    private static void CheckConcreteRule(SyntaxNodeAnalysisContext context)
    {
      if (!(context.Node is InvocationExpressionSyntax invocation) ||
          !(invocation.Expression is MemberAccessExpressionSyntax memberAccess) ||
          memberAccess.Name.Identifier.Text != "InvokeForClient")
        return;

      var argumentList = invocation.ArgumentList;
      var actionArg = argumentList.Arguments[0].Expression as IdentifierNameSyntax;
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

      if (!(argumentSyntax.Expression is LambdaExpressionSyntax lambdaExpressionSyntax))
        return;

      if (!(argumentSyntax.Parent is ArgumentListSyntax argumentListSyntax))
        return;

      if (!(argumentListSyntax.Parent is InvocationExpressionSyntax invocationExpressionSyntax))
        return;

      if (!(invocationExpressionSyntax.Expression is IdentifierNameSyntax identifierNameSyntax) ||
          identifierNameSyntax.Identifier.ValueText != "InvokeForClient")
        return;

      var containsUnsafeMethod = ContainsUnsafeMethod(lambdaExpressionSyntax);

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