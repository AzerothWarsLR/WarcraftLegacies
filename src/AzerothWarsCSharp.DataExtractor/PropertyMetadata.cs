namespace AzerothWarsCSharp.DataExtractor
{
  public struct PropertyMetadata
  {
    public string Name { get; }
    public PropertyValueType Type { get; }

    public PropertyMetadata(string name, PropertyValueType type)
    {
      Name = name;
      Type = type;
    }
  }
}