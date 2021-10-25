namespace AzerothWarsCSharp.DataExtractor
{
  public readonly struct PropertyMetadata
  {
    public readonly string Name { get; }
    public readonly PropertyValueType Type { get; }
    public readonly bool Show { get; }

    public PropertyMetadata(string name, PropertyValueType type, bool show = true)
    {
      Name = name;
      Type = type;
      Show = show;
    }
  }
}