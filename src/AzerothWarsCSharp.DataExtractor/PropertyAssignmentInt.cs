namespace AzerothWarsCSharp.DataExtractor
{
  public class PropertyAssignmentInt : IPropertyAssignment
  {
    private readonly int _value;
    private readonly string _propertyName;

    public string ToCode()
    {
      return $"{_propertyName} = {_value}";
    }

    public PropertyAssignmentInt(int value, string propertyName)
    {
      _value = value;
      _propertyName = propertyName;
    }
  }
}