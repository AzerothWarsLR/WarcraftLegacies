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
public class BaseObjectDtoSourceGenerator : ISourceGenerator
{
  private const string BaseObjectTypeName = "War3Api.Object.BaseObject";
  private const string OutputNamespace = "War3Api.Object.DataTransferObjects";

  /// <inheritdoc />
  public void Initialize(GeneratorInitializationContext context)
  {
  }

  public void Execute(GeneratorExecutionContext context)
  {
    
    // Retrieve the syntax tree for the BaseObject class
    var baseObjectSymbol = context.Compilation.GetTypeByMetadataName(BaseObjectTypeName);
    if (baseObjectSymbol is null)
      return;

    foreach (var syntaxTree in context.Compilation.SyntaxTrees)
    {
      var semanticModel = context.Compilation.GetSemanticModel(syntaxTree);

      // Find classes that inherit from BaseObject
      var root = syntaxTree.GetRoot();
      var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

      foreach (var classDeclaration in classDeclarations)
      {
        var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration);
        if (classSymbol?.BaseType == null || !SymbolEqualityComparer.Default.Equals(classSymbol.BaseType, baseObjectSymbol)) 
          continue;
        
        // Generate a DTO class with the same properties
        var dtoClassName = $"{classSymbol.Name}Dto";
        var properties = classDeclaration.Members.ToArray();
 
        var dtoClass = ClassDeclaration(dtoClassName)
          .WithModifiers(TokenList(
            Token(SyntaxKind.PublicKeyword),
            Token(SyntaxKind.SealedKeyword)))
          .AddMembers(properties);

        var dtoNamespace = NamespaceDeclaration(ParseName(OutputNamespace))
          .AddUsings(UsingDirective(ParseName("System")))
          .AddMembers(dtoClass)
          .NormalizeWhitespace();
        
        context.AddSource($"{dtoClassName}.cs", dtoNamespace.GetText(Encoding.UTF8));
      }
    }
  }
}