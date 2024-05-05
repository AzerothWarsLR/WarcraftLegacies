using System.Collections.Generic;
using WarcraftLegacies.Shared.Extensions;

namespace WarcraftLegacies.Shared
{
  public sealed class ObjectLimitRepository
  {
    private readonly Dictionary<string, int> _objectLimits = new();
    
    public ObjectLimitRepository()
    {
      AddFactionObjectLimits(ScourgeObjectLimitData.GetAllObjectLimits());
    }

    public bool TryGetObjectLimit(int objectTypeId, out int limit)
    {
      return _objectLimits.TryGetValue(objectTypeId.IdToFourCc(), out limit);
    }
    
    private void AddFactionObjectLimits(IEnumerable<ObjectLimit> factionObjectLimits)
    {
      foreach (var (objectTypeId, limit) in factionObjectLimits) 
        _objectLimits.Add(objectTypeId.IdToFourCc(true), limit);
    }
  }
}