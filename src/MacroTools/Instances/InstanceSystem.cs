using System.Collections.Generic;
using MacroTools.Libraries;
using WCSharp.Shared.Data;

namespace MacroTools.Instances
{
  public static class InstanceSystem
  {
    private static readonly List<Instance> RegisteredInstances = new();
    
    /// <summary>
    /// Returns the <see cref="Instance"/> a given point is in, if any.
    /// </summary>
    public static Instance? GetPointInstance(Point position)
    {
      foreach (var instance in RegisteredInstances)
      {
        if (IsPointInRegion(instance.Region, position.X, position.Y))
        {
          return instance;
        }
      }

      return null;
    }
    
    /// <summary>
    /// Determines the virtual distance between two points which may or may not be in seperate <see cref="Instance"/>s.
    /// </summary>
    /// <returns>The distance between two points, taking into account Instance entrances and exits. If one
    /// <see cref="Instance"/> has no <see cref="Gate"/>s, rendering it inaccessible, returns -1 instead.</returns>
    public static float GetDistanceBetweenPointsEx(Point positionA, Point positionB)
    {
      var instanceA = GetPointInstance(positionA);
      var instanceB = GetPointInstance(positionB);

      //Both points are in the same Instance, so distance is geographical as normal
      if (instanceA == instanceB)
        return MathEx.GetDistanceBetweenPoints(positionA, positionB);

      float sumDistance = 0;
      
      //Point A is in an Instance, so add the distance to the nearest interior Gate
      if (instanceA != null && instanceA.TryGetNearestGate(positionA, out var nearestGateA))
        sumDistance += MathEx.GetDistanceBetweenPoints(positionA, nearestGateA.InteriorPosition);
      else
        return -1;

      //Point B is in an Instance, so add the distance to the nearest interior Gate
      if (instanceB != null && instanceB.TryGetNearestGate(positionB, out var nearestGateB))
        sumDistance += MathEx.GetDistanceBetweenPoints(positionB, nearestGateB.InteriorPosition);
      else
        return -1;

      return sumDistance;
    }
    
    public static void Register(Instance instance)
    {
      RegisteredInstances.Add(instance);
    }
  }
}