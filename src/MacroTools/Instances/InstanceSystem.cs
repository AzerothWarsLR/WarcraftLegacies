using System.Collections.Generic;
using MacroTools.Libraries;
using WCSharp.Shared.Data;
using static War3Api.Common;

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
    /// <returns>The distance between two points, taking into account Instance entrances and exits. If one Instance</returns>
    public static float GetDistanceBetweenPointsEx(Point positionA, Point positionB)
    {
      float sumDistance = 0;
      var instance1 = GetPointInstance(positionA);
      var instance2 = GetPointInstance(positionB);

      //Both points are in the same Instance, so distance is geographical as normal
      if (instance1 == instance2)
      {
        return MathEx.GetDistanceBetweenPoints(positionA, positionB);
      }

      //Point A or point B is in an Instance with no Gates, so it is infinitely far
      if (instance1 != null || instance2 != null)
      {
        if (instance1.GateCount == 0 || instance2.GateCount == 0)
        {
          return -1;
        }
      }

      //Point A is in an Instance, so add the distance to the nearest interior Gate
      if (instance1 != null)
      {
        sumDistance += MathEx.GetDistanceBetweenPoints(positionA, instance2.GetNearestGate(positionB).InteriorPosition);
      }

      //Point B is in an Instance, so add the distance to the nearest interior Gate
      if (instance1 != null)
      {
        sumDistance += MathEx.GetDistanceBetweenPoints(positionB, instance2.GetNearestGate(positionB).InteriorPosition);
      }

      return sumDistance;
    }
    
    public static void Register(Instance instance)
    {
      RegisteredInstances.Add(instance);
    }
  }
}