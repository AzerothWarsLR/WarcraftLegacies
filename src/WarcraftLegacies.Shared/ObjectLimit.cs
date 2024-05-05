namespace WarcraftLegacies.Shared
{
  public sealed class ObjectLimit
  {
    public int ObjectTypeId { get; }
    public int Limit { get; }

    public ObjectLimit(int objectTypeId, int limit)
    {
      ObjectTypeId = objectTypeId;
      Limit = limit;
    }
    
    public void Deconstruct(out int objectTypeId, out int limit)
    {
      objectTypeId = ObjectTypeId;
      limit = Limit;
    }
  }
}