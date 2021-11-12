using System.Collections.Generic;
using War3Api.Object;
using War3Net.Build.Object;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System;
using War3Net.Common.Extensions;
using System.Reflection;
using War3Api.Object.Enums;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace AzerothWarsCSharp.DataExtractor
{
  public class UnitFactoryGenerator : FactoryGenerator<Unit>
  {
    private readonly Unit _unit;
    private static readonly Dictionary<string, PropertyMetadata> _propertyMetaDatas = new()
    {
      { "ArtIconGameInterface", new PropertyMetadata("Icon") },
      { "ArtButtonPositionX", new PropertyMetadata(false) },
      { "ArtButtonPositionY", new PropertyMetadata(false) },
      { "TextTooltipExtended", new PropertyMetadata("Flavour") },
      { "TextTooltipBasic", new PropertyMetadata(false) },
      { "StatsRepairGoldCost", new PropertyMetadata(false) },
      { "StatsRepairLumberCost", new PropertyMetadata(false) },
      { "StatsRepairTime", new PropertyMetadata(false) },
      { "StatsGoldBountyAwardedNumberOfDice", new PropertyMetadata(false) },
      { "StatsGoldBountyAwardedBase", new PropertyMetadata(false) },
      { "StatsGoldBountyAwardedSidesPerDie", new PropertyMetadata(false) },
      { "TextTooltipAwaken", new PropertyMetadata(false) },
      { "TextTooltipRevive", new PropertyMetadata(false) },
      { "StatsBuildTime", new PropertyMetadata("BuildTime") },
      { "CombatDefenseBase", new PropertyMetadata("Armour") },
      { "StatsGoldCost", new PropertyMetadata("GoldCost") },
      { "StatsLumberCost", new PropertyMetadata("LumberCost") },
      { "ArtScalingValue", new PropertyMetadata("ScalingValue") },
      { "StatsHitPointsMaximumBase", new PropertyMetadata("HitPoints") },
      { "MovementSpeedBase", new PropertyMetadata("MovementSpeed") },
      { "ArtTintingColor3Blue", new PropertyMetadata("TintBlue") },
      { "ArtTintingColor2Green", new PropertyMetadata("TintGreen") },
      { "ArtTintingColor1Red", new PropertyMetadata("TintRed") },
      { "StatsPriority", new PropertyMetadata(false) },
      { "StatsManaInitialAmount", new PropertyMetadata("StartingMana") },
      { "StatsHitPointsRegenerationRate", new PropertyMetadata("HitPointRegenerationRate") },
    };

    private static readonly string _namespace = "AzerothWarsCSharp.Launcher";
    private static readonly string[] _usings = new[] {
      "AzerothWarsCSharp.Launcher.ObjectFactory.Units",
      "War3Api.Object.Enums"
    };
    private static ObjectDatabase _objectDatabase;

    public static string GetPropertyTranslatedName(PropertyInfo property)
    {
      if (_propertyMetaDatas.TryGetValue(property.Name, out PropertyMetadata metadata))
      {
        return metadata.Name;
      }
      return property.Name;
    }

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
          && PropertyIsModified(property)
          && (!_propertyMetaDatas.TryGetValue(property.Name, out var metadata) || metadata.Show == true)
        )
        {
          yield return property;
        }
      }
    }

    private IEnumerable<AssignmentExpressionSyntax> GetAssignmentExpressions()
    {
      foreach (var property in GetValuedProperties())
      {
        yield return AssignmentExpression(
          SyntaxKind.SimpleAssignmentExpression,
          IdentifierName(
            Identifier(
              $"{GetPropertyTranslatedName(property)}"
            )
          ),
          GenerateLiteralExpression(_unit, property)
        );
      }
    }
    
    private InitializerExpressionSyntax GetFactoryInitializer()
    {
      return InitializerExpression(
        SyntaxKind.ObjectInitializerExpression,
        SeparatedList<ExpressionSyntax>(
          GetAssignmentExpressions()
        )
      );
    }

    private SeparatedSyntaxList<VariableDeclaratorSyntax> GetInitializerVariables()
    {
      return SingletonSeparatedList(
        VariableDeclarator(
          Identifier("militiaFactory"))
            .WithInitializer(
          EqualsValueClause(
              ObjectCreationExpression(
                IdentifierName("UnitFactory"))
              .WithArgumentList(
                  ArgumentList(
                    SingletonSeparatedList(
                      Argument(
                          MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            IdentifierName("UnitType"),
                            IdentifierName($"{Enum.ToObject(typeof(UnitType), _unit.OldId)}"))))))
              .WithInitializer(GetFactoryInitializer())
          )
      )
    );
    }
    
    private StatementSyntax GetNewStatement()
    {
      return LocalDeclarationStatement(
        VariableDeclaration(
          IdentifierName(
            Identifier(
              TriviaList(
                Comment($"//{_unit.OldId.ToRawcode()}:{_unit.NewId.ToRawcode()}")),
            SyntaxKind.VarKeyword,
            "var",
            "var",
            TriviaList())))
    .WithVariables(GetInitializerVariables())
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
      yield return MethodDeclaration(
        ParseTypeName("void"),
        Identifier("Generate"))
          .AddModifiers(Token(SyntaxKind.StaticKeyword))
          .WithBody(Block(GetAllStatements()));
    }

    private static IEnumerable<MemberDeclarationSyntax> GetClasses()
    {
      yield return ClassDeclaration(
        default,
        new SyntaxTokenList(
            Token(SyntaxKind.PublicKeyword),
            Token(SyntaxKind.StaticKeyword)),
        Identifier("Generated"),
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
        yield return UsingDirective(IdentifierName(usingLabel));
      }
    }

    private static NamespaceDeclarationSyntax GetNamespace(IEnumerable<MemberDeclarationSyntax> classes, IEnumerable<UsingDirectiveSyntax> usings)
    {
      return NamespaceDeclaration(
        IdentifierName(_namespace),
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
      return nameSpace
        .NormalizeWhitespace()
        .ToString();
    }

    public UnitFactoryGenerator(Unit unit)
    {
      _unit = unit;
    }
  }
}
