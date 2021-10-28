namespace AzerothWarsCSharp.DataExtractor
{
  public class PropertyAssignmentFloat : IPropertyAssignment
  {
    private readonly float _value;
    private readonly string _propertyName;

    public string ToCode()
    {
      return @$"{_propertyName} = {_value}f";
    }

    public PropertyAssignmentFloat(float value, string propertyName)
    {
      _value = value;
      _propertyName = propertyName;
    }
  }
}