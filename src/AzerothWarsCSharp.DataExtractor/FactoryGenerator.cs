using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Reflection;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace AzerothWarsCSharp.DataExtractor
{
  public abstract class FactoryGenerator<T>
  {
    private readonly Dictionary<Type, SyntaxKind> _objectDataTypeToSyntaxKind = new()
    {
      { typeof(float), SyntaxKind.NumericLiteralExpression },
      { typeof(int), SyntaxKind.NumericLiteralExpression },
      { typeof(string), SyntaxKind.StringLiteralExpression },
      { typeof(bool), SyntaxKind.TrueLiteralExpression },
      { typeof(char), SyntaxKind.CharacterLiteralExpression }
    };

    protected LiteralExpressionSyntax GenerateLiteralExpression(T subject, PropertyInfo property)
    {
      var syntaxKind = _objectDataTypeToSyntaxKind[property.PropertyType];
      var propertyValue = property.GetValue(subject);

      var literalToken = property.GetValue(subject) switch
      {
        int => Literal((int)propertyValue),
        float => Literal((float)propertyValue),
        bool => Literal((string)propertyValue),
        string => Literal((string)propertyValue),
        _ => Literal((string)propertyValue),
      };

      return LiteralExpression(
            syntaxKind,
            literalToken
          );
    }
  }
}
