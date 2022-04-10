using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.Instances;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools
{
  /// <summary>
  /// A position where the beach meets the shore.
  /// </summary>
  public sealed class Shore
  {
    private static readonly List<Shore> ShoresByIndex = new();

    private static int Count => ShoresByIndex.Count;

    public Point Position { get; }

    public Shore(float x, float y)
    {
      Position = new Point(x, y);
      ShoresByIndex.Add(this);
    }

    public Shore(Point position)
    {
      Position = position;
      ShoresByIndex.Add(this);
    }

    public static Shore? GetNearestShore(Point position)
    {
      var i = 0;
      Shore? nearestShore = null;
      float nearestDistance = 1000000;
      while (true)
      {
        if (i == Count)
        {
          break;
        }

        var tempDistance = InstanceSystem.GetDistanceBetweenPointsEx(position, ShoresByIndex[i].Position);
        if (tempDistance < nearestDistance)
        {
          nearestDistance = tempDistance;
          nearestShore = ShoresByIndex[i];
        }

        i += 1;
      }

      return nearestShore;
    }
  }
}