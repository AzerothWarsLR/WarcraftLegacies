namespace AzerothWarsCSharp.DataExtractor
{
  public readonly struct PropertyMetadata
  {
    public readonly string Name { get; }
    public readonly bool Show { get; }

    public PropertyMetadata(string name, bool show = true)
    {
      Name = name;
      Show = show;
    }
  }
}