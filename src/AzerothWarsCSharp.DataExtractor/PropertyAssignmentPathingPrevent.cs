using System.Text;

namespace AzerothWarsCSharp.DataExtractor
{
  public class PropertyAssignmentPathingPrevent : PropertyAssignment<string>, IPropertyAssignment
  {
    public override string Value { get; set; }

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
      var split = Value.ToString().Split(",");
      stringBuilder.Append($"{PropertyName} = new[] {{ ");
      var i = 0;
      foreach (var id in split)
      {
        i++;
        stringBuilder.Append(@$"PathingPrevent.{CapitalizeFirstLetter(id)}");
        if (i < split.Length)
        {
          stringBuilder.Append(", ");
        }
      }
      stringBuilder.Append($" }}");
      return stringBuilder.ToString();
    }
  }
}