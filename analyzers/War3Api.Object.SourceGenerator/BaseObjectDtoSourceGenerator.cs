using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace War3Api.Object.SourceGenerator;

/// <summary>
/// Generates a data transfer object for all objects inheriting from War3Api.Object.BaseObject.
/// </summary>
[Generator]
public class BaseObjectDtoSourceGenerator : ISourceGenerator
{
  private const string BaseObjectTypeName = "War3Api.Object.BaseObject";

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
 
        var dtoClass = SyntaxFactory.ClassDeclaration(dtoClassName)
          .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
          .AddMembers(properties);

        var dtoNamespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("Launcher.DataTransferObjects.Generated"))
          .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")))
          .AddMembers(dtoClass)
          .NormalizeWhitespace();
        
        context.AddSource($"{dtoClassName}.cs", dtoNamespace.GetText(Encoding.UTF8));
      }
    }
  }
}