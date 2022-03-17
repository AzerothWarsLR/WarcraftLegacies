//Just records a bunch of locations that are considered "shores" for the purposes of determing where the nearest shore is.

using System.Collections.Generic;

namespace AzerothWarsCSharp.Source.Main.Libraries
{
  public class Shore{
    private static List<Shore> shoresByIndex = new();

    readonly float x;
    readonly float y;

    public static int Count => shoresByIndex.Count;

    public static Shore ByIndex(int i )
    {
      return shoresByIndex[i];
    }

    public Shore(float x, float y ){
      this.x = x;
      this.y = y;
      shoresByIndex.Add(this);
    }
    
    public static Shore GetNearestShore(float x, float y ){
      var i = 0;
      Shore nearestShore = null;
      float nearestDistance = 1000000;
      while(true){
        if ( i == Count){ break; }
        var tempDistance = Instance.GetDistanceBetweenPointsEx(x, y, Shore.shoresByIndex[i].x, Shore.shoresByIndex[i].y);
        if (tempDistance < nearestDistance){
          nearestDistance = tempDistance;
          nearestShore = Shore.shoresByIndex[i];
        }
        i = i + 1;
      }
      return nearestShore;
    }

  }
}
