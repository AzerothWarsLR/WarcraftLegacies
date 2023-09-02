using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace War3Api.Object.SourceGenerator;

/// <summary>
/// Generates a data transfer object for all objects inheriting from War3Api.Object.BaseObject.
/// </summary>
[Generator]
public sealed class BaseObjectDtoSourceGenerator : ISourceGenerator
{
  private const string BaseObjectTypeName = "War3Api.Object.BaseObject";
  private const string OutputNamespace = "War3Api.Object.DataTransferObjects";

  /// <inheritdoc />
  public void Initialize(GeneratorInitializationContext context)
  {
  }

  public void Execute(GeneratorExecutionContext context)
  {
    var baseObjectSymbol = context.Compilation.GetTypeByMetadataName(BaseObjectTypeName);
    if (baseObjectSymbol is null)
      return;

    foreach (var syntaxTree in context.Compilation.SyntaxTrees)
    {
      var semanticModel = context.Compilation.GetSemanticModel(syntaxTree);
      
      var root = syntaxTree.GetRoot();
      var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

      foreach (var classDeclaration in classDeclarations)
      {
        var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration);
        GenerateDtoClass(context, classSymbol);
        GenerateMapperClass(context, classSymbol);
      }
      
    }
  }

  private static void GenerateDtoClass(GeneratorExecutionContext context, INamespaceOrTypeSymbol classSymbol)
  {
    var dtoClassName = $"{classSymbol.Name}Dto";

    var dtoClass = ClassDeclaration(dtoClassName)
      .WithModifiers(TokenList(
        Token(SyntaxKind.PublicKeyword),
        Token(SyntaxKind.SealedKeyword)))
      .AddSimplifiedCopiedProperties(classSymbol);

    var dtoNamespace = WrapDeclarationInNamespace(dtoClass);

    context.AddSource($"DataTransferObjects/{dtoClassName}.cs", dtoNamespace.GetText(Encoding.UTF8));
  }
  
  private static void GenerateMapperClass(GeneratorExecutionContext context, ISymbol classSymbol)
  {
    var mapperClassName = $"{classSymbol.Name}DtoMapper";

    var dtoClass = ClassDeclaration(mapperClassName)
      .WithModifiers(TokenList(
        Token(SyntaxKind.PublicKeyword),
        Token(SyntaxKind.SealedKeyword)))
      .WithMembers(
        SingletonList<MemberDeclarationSyntax>(
          MethodDeclaration(
              IdentifierName("UnitDto"),
              Identifier("UnitToUnitDto"))
            .WithModifiers(
              TokenList(
                Token(SyntaxKind.PublicKeyword)))
            .WithParameterList(
              ParameterList(
                SingletonSeparatedList(
                  Parameter(
                      Identifier("unit"))
                    .WithType(
                      IdentifierName("Unit")))))
            .WithBody(
              Block(
                SingletonList<StatementSyntax>(
                  ReturnStatement(
                    ObjectCreationExpression(
                        IdentifierName("UnitDto"))
                      .WithInitializer(
                        InitializerExpression(
                          SyntaxKind.ObjectInitializerExpression,
                          SeparatedList<ExpressionSyntax>(
                            new SyntaxNodeOrToken[]{
                              AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                IdentifierName("Art"),
                                ConditionalExpression(
                                  MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    IdentifierName("unit"),
                                    IdentifierName("IsArtModified")),
                                  MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    IdentifierName("unit"),
                                    IdentifierName("Art")),
                                  LiteralExpression(
                                    SyntaxKind.NullLiteralExpression))),
                              Token(SyntaxKind.CommaToken)})))))))));

    var dtoNamespace = WrapDeclarationInNamespace(dtoClass);

    context.AddSource($"Mappers/{mapperClassName}.cs", dtoNamespace.GetText(Encoding.UTF8));
  }

  private static NamespaceDeclarationSyntax WrapDeclarationInNamespace(MemberDeclarationSyntax declaration)
  {
    return NamespaceDeclaration(ParseName(OutputNamespace))
      .AddUsings(UsingDirective(ParseName("System")))
      .AddMembers(declaration)
      .NormalizeWhitespace();
  }
}

internal static class RoslynGeneratorExtensions{
  /// <summary>
  /// Copies all properties from <paramref name="classSymbol"/>, reduces them down to auto-properties, and adds them
  /// to <paramref name="classDeclarationSyntax"/>.
  /// </summary>
  internal static ClassDeclarationSyntax AddSimplifiedCopiedProperties(this ClassDeclarationSyntax classDeclarationSyntax, INamespaceOrTypeSymbol classSymbol)
  {
    var classProperties = classSymbol.GetMembers().OfType<IPropertySymbol>().ToList();
    var classPropertyNames = classProperties.Select(x => x.Name).ToList();
    
    return classProperties
      .Where(property => IsValidPropertyToCopy(property, classPropertyNames))
      .Select(property => PropertyDeclaration(ParseTypeName(property.Type.ToDisplayString()), property.Name)
        .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)))
        .WithAccessorList(AccessorList(List(new[]
        {
          AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
            .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)),
          AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
            .WithSemicolonToken(Token(SyntaxKind.SemicolonToken))
        }))))
      .Aggregate(classDeclarationSyntax, (current, propertySyntax) => current.AddMembers(propertySyntax));
  }

  /// <summary>
  /// A property is valid to copy if it doesn't end with "Modified",
  /// and there are no other Properties representing a raw version of itself.
  /// </summary>
  private static bool IsValidPropertyToCopy(ISymbol property, ICollection<string> otherPropertyNames)
  {
    var propertyName = property.Name;
    return propertyName != "Modifications" && !propertyName.EndsWith("Modified") && !otherPropertyNames.Contains($"{propertyName}Raw");
  }
}