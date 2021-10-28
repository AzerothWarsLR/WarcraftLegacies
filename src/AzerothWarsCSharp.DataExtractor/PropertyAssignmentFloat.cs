namespace AzerothWarsCSharp.DataExtractor
{
  public class PropertyAssignmentFloat : IPropertyAssignment
  {
    private readonly string _value;
    private readonly string _propertyName;

    public string ToCode()
    {
      return @$"{_propertyName} = {_value}";
    }

    public PropertyAssignmentFloat(string value, string propertyName)
    {
      _value = value;
      _propertyName = propertyName;
    }
  }
}