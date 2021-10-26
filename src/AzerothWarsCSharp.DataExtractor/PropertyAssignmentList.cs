using System.Text;

namespace AzerothWarsCSharp.DataExtractor
{
  public class PropertyAssignmentList : IPropertyAssignment
  {
    public readonly string _value;
    private readonly string _propertyName;
    public readonly string _methodName;

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
      var split = _value.ToString().Split(",");
      stringBuilder.Append($"{_propertyName} = new[] {{ ");
      var i = 0;
      foreach (var id in split)
      {
        i++;
        stringBuilder.Append(@$"{_methodName}.{CapitalizeFirstLetter(id)}");
        if (i < split.Length)
        {
          stringBuilder.Append(", ");
        }
      }
      stringBuilder.Append($" }}");
      return stringBuilder.ToString();
    }

    public PropertyAssignmentList(string value, string propertyName, string methodName)
    {
      _value = value;
      _propertyName = propertyName;
      _methodName = methodName;
    }
  }
}