using System.Linq;
using System.Reflection;
using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace War3Api.Object.SourceGenerator.Test;

public sealed class DtoGeneratorTests
{
  private const string BaseObjectTypeName = "BaseObject";
  private const string GeneratedClassName = "Launcher.DataTransferObjects.Generated.UnitDto";

  [Fact]
  public void GeneratesDto_ForClassInheritingFromBaseObject()
  {
    //Arrange
    const string sourceCode = $$"""
                                 namespace War3Api.Object;
                                 
                                 public class {{BaseObjectTypeName}}
                                 {
                                 }

                                 public class Unit : {{BaseObjectTypeName}}
                                 {
                                     public int Id { get; set; }
                                     public string Name { get; set; }
                                 }
                                 """;
      
    var compilation = CreateCompilation(sourceCode);
    var generator = new BaseObjectDtoSourceGenerator();
    var driver = CSharpGeneratorDriver.Create(generator);
    
    //Act
    driver.RunGeneratorsAndUpdateCompilation(compilation, out var newCompilation, out var diagnostics);
    
    //Verify
    diagnostics.Should().BeEmpty();
    var dtoClass = newCompilation.GetTypeByMetadataName(GeneratedClassName);
    dtoClass.Should().NotBeNull();
    var properties = dtoClass!.GetMembers().OfType<IPropertySymbol>().ToList();
    properties.Count.Should().Be(2);
    Assert.Contains(properties, p => p is { Name: "Id", Type.SpecialType: SpecialType.System_Int32 });
    Assert.Contains(properties, p => p is { Name: "Name", Type.SpecialType: SpecialType.System_String });
  }

  private static Compilation CreateCompilation(string source)
    => CSharpCompilation.Create("compilation",
      new[] { CSharpSyntaxTree.ParseText(source) },
      new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location) },
      new CSharpCompilationOptions(OutputKind.ConsoleApplication));
  
}