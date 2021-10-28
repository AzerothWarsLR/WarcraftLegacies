namespace AzerothWarsCSharp.DataExtractor
{
  public class PropertyAssignmentBool : IPropertyAssignment
  {
    private readonly int _value;
    private readonly string _propertyName;

    public string ToCode()
    {
      if (_value == 1)
      {
        return @$"{_propertyName} = true";
      }
      return @$"{_propertyName} = false";
    }

    public PropertyAssignmentBool(int value, string propertyName)
    {
      _value = value;
      _propertyName = propertyName;
    }
  }
}