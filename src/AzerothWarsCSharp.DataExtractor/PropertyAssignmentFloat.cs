namespace AzerothWarsCSharp.DataExtractor
{
  public class PropertyAssignmentFloat : PropertyAssignment<float>, IPropertyAssignment
  {
    public override float Value { get; set; }

    public string ToCode()
    {
      return @$"{PropertyName} = {Value}";
    }
  }
}