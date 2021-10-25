using System.Text;
using War3Api.Object;

namespace AzerothWarsCSharp.DataExtractor
{
  public class PropertyAssignmentTechs : PropertyAssignment<Tech>, IPropertyAssignment
  {
    public override Tech Value { get; set; }

    public string ToCode()
    {
      var stringBuilder = new StringBuilder();
      var split = Value.ToString().Split(",");
      stringBuilder.Append($"{PropertyName} = new[] {{ ");
      var i = 0;
      foreach (var id in split)
      {
        i++;
        stringBuilder.Append(@$"objectDatabase.TryGetTech(""{id}"")");
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