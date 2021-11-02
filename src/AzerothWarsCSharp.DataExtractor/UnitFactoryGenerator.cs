using System.Collections.Generic;
using War3Api.Object;
using War3Net.Build.Object;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System;
using War3Net.Common.Extensions;
using System.Reflection;

namespace AzerothWarsCSharp.DataExtractor
{
  public class UnitFactoryGenerator
  {
    private readonly Unit _unit;

    private static string _namespace = "AzerothWarsCSharp.Launcher";
    private static readonly string[] _usings = new[] {
      "AzerothWarsCSharp.Launcher.ObjectFactory.Abilities",
      "AzerothWarsCSharp.Launcher.ObjectFactory.Abilities.Human",
      "AzerothWarsCSharp.Launcher.ObjectFactory.Units",
      "System.Drawing",
      "War3Api.Object",
    };
    private static ObjectDatabase _objectDatabase;

    /// <summary>
    /// Checks if the property has a value set.
    /// </summary>
    /// <param name="property"></param>
    /// <returns></returns>
    private bool PropertyIsModified(PropertyInfo property)
    {
      var checkProperty = typeof(Unit).GetProperty($"Is{property.Name}Modified");
      return checkProperty != null && (bool)checkProperty.GetValue(_unit) == true;
    }

    /// <summary>
    /// Returns all properties which have a setter, a value, and no corresponding raw version.
    /// </summary>
    /// <returns></returns>
    private IEnumerable<PropertyInfo> GetValuedProperties()
    {
      var properties = typeof(Unit).GetProperties();
      foreach (var property in properties)
      {
        if (property.SetMethod != null 
          && property.SetMethod.IsPublic 
          && typeof(Unit).GetProperty($"{property.Name}Raw") == null
          && PropertyIsModified(property))
        {
          yield return property;
        }
      }
    }

    private IEnumerable<AssignmentExpressionSyntax> GetAssignmentExpressions()
    {
      foreach (var property in GetValuedProperties())
      {
        yield return SyntaxFactory.AssignmentExpression(
          SyntaxKind.SimpleAssignmentExpression,
          SyntaxFactory.IdentifierName(property.Name),
          SyntaxFactory.LiteralExpression(
            SyntaxKind.StringLiteralExpression,
            SyntaxFactory.Literal(property.GetValue(_unit).ToString())
          )
        );
      }
    }

    private StatementSyntax GetNewStatement()
    {
      return SyntaxFactory.LocalDeclarationStatement(
        SyntaxFactory.VariableDeclaration(
          SyntaxFactory.IdentifierName(
            SyntaxFactory.Identifier(
              SyntaxFactory.TriviaList(
                SyntaxFactory.Comment($"//{_unit.OldId.ToRawcode()}:{_unit.NewId.ToRawcode()}")),
            SyntaxKind.VarKeyword,
            "var",
            "var",
            SyntaxFactory.TriviaList())))
    .WithVariables(
            SyntaxFactory.SingletonSeparatedList(
              SyntaxFactory.VariableDeclarator(
                SyntaxFactory.Identifier("militiaFactory"))
                  .WithInitializer(
                SyntaxFactory.EqualsValueClause(
                    SyntaxFactory.ObjectCreationExpression(
                      SyntaxFactory.IdentifierName("UnitFactory"))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList(
                          SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Argument(
                                SyntaxFactory.MemberAccessExpression(
                                  SyntaxKind.SimpleMemberAccessExpression,
                                  SyntaxFactory.IdentifierName("UnitType"),
                                  SyntaxFactory.IdentifierName($"{Enum.ToObject(typeof(UnitType), _unit.OldId)}"))))))
                    .WithInitializer(
                      SyntaxFactory.InitializerExpression(
                        SyntaxKind.ObjectInitializerExpression,
                        SyntaxFactory.SeparatedList<ExpressionSyntax>(
                          GetAssignmentExpressions()
                        )
                      )
                    )
                )
            )
          )
        )
      );
    }

    private static IEnumerable<StatementSyntax> GetAllStatements()
    {
      var allUnits = _objectDatabase.GetUnits();
      foreach (var unit in allUnits)
      {
        var unitFactoryGenerator = new UnitFactoryGenerator(unit);
        yield return unitFactoryGenerator.GetNewStatement();
      }
    }

    private static IEnumerable<MethodDeclarationSyntax> GetMethods()
    {
      yield return SyntaxFactory.MethodDeclaration(
        SyntaxFactory.ParseTypeName("void"),
        SyntaxFactory.Identifier("Generate"))
          .AddModifiers(SyntaxFactory.Token(SyntaxKind.StaticKeyword))
          .WithBody(SyntaxFactory.Block(GetAllStatements()));
    }

    private static IEnumerable<MemberDeclarationSyntax> GetClasses()
    {
      yield return SyntaxFactory.ClassDeclaration(
        default,
        new SyntaxTokenList(
            SyntaxFactory.Token(SyntaxKind.PublicKeyword),
            SyntaxFactory.Token(SyntaxKind.StaticKeyword)),
        SyntaxFactory.Identifier("Generated"),
        null,
        null,
        default,
        new SyntaxList<MemberDeclarationSyntax>(GetMethods())
      );
    }

    private static IEnumerable<UsingDirectiveSyntax> GetUsingDirectives()
    {
      foreach (var usingLabel in _usings)
      {
        yield return SyntaxFactory.UsingDirective(SyntaxFactory.IdentifierName(usingLabel));
      }
    }

    private static NamespaceDeclarationSyntax GetNamespace(IEnumerable<MemberDeclarationSyntax> classes, IEnumerable<UsingDirectiveSyntax> usings)
    {
      return SyntaxFactory.NamespaceDeclaration(
        SyntaxFactory.IdentifierName(_namespace),
        new SyntaxList<ExternAliasDirectiveSyntax>(),
        new SyntaxList<UsingDirectiveSyntax>(usings),
        new SyntaxList<MemberDeclarationSyntax>(classes)
        );
    }

    public static string ToCodeAll(ObjectData objectData)
    {
      var objectDatabase = new ObjectDatabase();
      objectDatabase.AddObjects(objectData);
      _objectDatabase = objectDatabase;

      var nameSpace = GetNamespace(GetClasses(), GetUsingDirectives());
      return nameSpace.NormalizeWhitespace().ToString();
    }

    public UnitFactoryGenerator(Unit unit)
    {
      _unit = unit;
    }
  }
}
