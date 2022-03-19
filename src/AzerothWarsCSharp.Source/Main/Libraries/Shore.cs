//Just records a bunch of locations that are considered "shores" for the purposes of determing where the nearest shore is.

using System.Collections.Generic;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Main.Libraries
{
  /// <summary>
  /// A position where the beach meets the shore.
  /// </summary>
  public sealed class Shore{
    private static readonly List<Shore> ShoresByIndex = new();
    
    public static int Count => ShoresByIndex.Count;

    public static Shore ByIndex(int i )
    {
      return ShoresByIndex[i];
    }

    public Point Position { get; }
    
    public Shore(Point position)
    {
      Position = position;
      ShoresByIndex.Add(this);
    }
    
    public static Shore GetNearestShore(float x, float y ){
      var i = 0;
      Shore nearestShore = null;
      float nearestDistance = 1000000;
      while(true){
        if ( i == Count){ break; }
        var tempDistance = Instance.GetDistanceBetweenPointsEx(x, y, ShoresByIndex[i].x, ShoresByIndex[i].y);
        if (tempDistance < nearestDistance){
          nearestDistance = tempDistance;
          nearestShore = ShoresByIndex[i];
        }
        i += 1;
      }
      return nearestShore;
    }

  }
}
