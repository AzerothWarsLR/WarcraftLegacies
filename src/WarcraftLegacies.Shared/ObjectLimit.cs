using WarcraftLegacies.Shared.Extensions;

namespace WarcraftLegacies.Shared
{
  public sealed class ObjectLimit
  {
    public string ObjectTypeId { get; }
    public int Limit { get; }

    public ObjectLimit(string objectTypeId, int limit)
    {
      ObjectTypeId = objectTypeId;
      Limit = limit;
    }

    public ObjectLimit(int objectTypeId, int limit)
    {
      ObjectTypeId = objectTypeId.IdToFourCc();
      Limit = limit;
    }

    public void Deconstruct(out string objectTypeId, out int limit)
    {
      objectTypeId = ObjectTypeId;
      limit = Limit;
    }
  }
}