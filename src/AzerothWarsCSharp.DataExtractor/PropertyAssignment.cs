namespace AzerothWarsCSharp.DataExtractor
{
  public abstract class PropertyAssignment<T>
  {
    public string PropertyName { get; set; }
    public abstract T Value { get; set; }
  }
}