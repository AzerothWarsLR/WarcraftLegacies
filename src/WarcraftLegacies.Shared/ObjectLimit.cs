using WarcraftLegacies.Shared.Extensions;
using System;

namespace WarcraftLegacies.Shared
{
  public sealed class ObjectLimit
  {
    public string ObjectTypeId { get; }
    public int Limit { get; }
    
    [Obsolete("Use the version that takes in two integers instead.")]
    public ObjectLimit(string objectTypeId, int limit)
    {
      ObjectTypeId = objectTypeId.Reverse();
      Limit = limit;
    }

    public ObjectLimit(int objectTypeId, int limit)
    {
      ObjectTypeId = objectTypeId.IdToFourCc(true);
      Limit = limit;
    }

    public void Deconstruct(out string objectTypeId, out int limit)
    {
      objectTypeId = ObjectTypeId;
      limit = Limit;
    }
  }
}