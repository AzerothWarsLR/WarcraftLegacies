namespace AzerothWarsCSharp.DataExtractor
{
  public class PropertyAssignmentString : PropertyAssignment<string>, IPropertyAssignment
  {
    public override string Value { get; set; }

    public string ToCode()
    {
      return @$"{PropertyName} = @""{Value}""";
    }
  }
}