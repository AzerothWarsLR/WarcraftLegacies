namespace AzerothWarsCSharp.DataExtractor
{
  public class PropertyAssignmentString : IPropertyAssignment
  {
    private readonly string _value;
    private readonly string _propertyName;

    public string ToCode()
    {
      return @$"{_propertyName} = @""{_value}""";
    }

    public PropertyAssignmentString(string value, string propertyName)
    {
      _value = value;
      _propertyName = propertyName;
    }
  }
}