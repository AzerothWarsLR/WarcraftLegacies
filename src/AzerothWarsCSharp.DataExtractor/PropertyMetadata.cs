namespace AzerothWarsCSharp.DataExtractor
{
  public readonly struct PropertyMetadata
  {
    public readonly string Name { get; }
    public readonly bool Show { get; }

    public PropertyMetadata(bool show)
    {
      Name = null;
      Show = show;
    }

    public PropertyMetadata(string name)
    {
      Name = name;
      Show = true;
    }
  }
}