//Just records a bunch of locations that are considered "shores" for the purposes of determing where the nearest shore is.

namespace AzerothWarsCSharp.Source.Main.Libraries
{
  public class Shore{


    readonly static thistype[] shoresByIndex;
    readonly static int shoreCount = 0;

    readonly float x = 0;
    readonly float y = 0;

    static integer Count( ){
      ;type.shoreCount;
    }

    static thistype ByIndex(int i ){
      ;type.shoresByIndex[i];
    }

    thistype (float x, float y ){


      this.x = x;
      this.y = y;
      thistype.shoresByIndex[shoreCount] = this;
      thistype.shoreCount = thistype.shoreCount + 1;

      ;;
    }


    static Shore GetNearestShore(float x, float y ){
      int i = 0;
      Shore nearestShore = 0;
      float nearestDistance = 1000000;
      float tempDistance = 0;
      while(true){
        if ( i == Shore.shoreCount){ break; }
        tempDistance = GetDistanceBetweenPointsEx(x, y, Shore.shoresByIndex[i].x, Shore.shoresByIndex[i].y);
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
