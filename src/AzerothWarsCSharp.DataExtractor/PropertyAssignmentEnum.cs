using System.Text;

namespace AzerothWarsCSharp.DataExtractor
{
  public class PropertyAssignmentEnum : IPropertyAssignment
  {
    private readonly string _value;
    private readonly string _propertyName;
    private readonly string _methodName;

    private static string CapitalizeFirstLetter(string str)
    {
      if (str.Length == 1)
      {
        return char.ToUpper(str[0]).ToString();
      }
      else
      {
        return char.ToUpper(str[0]) + str.Substring(1);
      }
    }

    public string ToCode()
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.Append($"{_propertyName} = ");
      stringBuilder.Append(@$"{_methodName}.{CapitalizeFirstLetter(_value)}");
      return stringBuilder.ToString();
    }

    public PropertyAssignmentEnum(string value, string propertyName, string methodName)
    {
      _value = value;
      _propertyName = propertyName;
      _methodName = methodName;
    }
  }
}