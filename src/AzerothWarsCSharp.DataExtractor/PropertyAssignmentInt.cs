namespace AzerothWarsCSharp.DataExtractor
{
  public class PropertyAssignmentInt : PropertyAssignment<int>, IPropertyAssignment
  {
    public override int Value { get; set; }

    public string ToCode()
    {
      return $"{PropertyName} = {Value}";
    }
  }
}