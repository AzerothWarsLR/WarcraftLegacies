using System.Collections.Generic;

namespace WarcraftLegacies.Shared
{
  public static class ObjectLimitData
  {
    private const int Unlimited = 200;
    
    public static List<ObjectLimit> GetAllObjectLimits()
    {
      var allObjectLimits = new List<ObjectLimit>();
      allObjectLimits.AddRange(ScourgeObjectLimitData.GetAllObjectLimits());
      return allObjectLimits;
    }
  }
}