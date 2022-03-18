using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Main.Libraries
{
  /// <summary>
  /// An instance is a region that is physically seperate from all other instances irrespective of its actual geographical location on the Warcraft map.
  /// </summary>
  public class Instance
  {
    readonly static thistype[] instancesByIndex;
    readonly static int instanceCount = 0;
    readonly War3Api.Common.region whichRegion;
    readonly int gateCount;
    readonly Gate[] gatesByIndex[10];
    private string name;

    public string Name { get; set; }

    void operator Name=(string value ) {
      name = value;
    }

    Gate getNearestGate(float x1, float y2)
    {
      var i = 0;
      float distanceToNearestGate = 0;
      float tempReal = 0;
      Gate nearestGate = 0;
      while (true)
      {
        if (i == gateCount)
        {
          break;
        }

        tempReal = GetDistanceBetweenPoints(x1, y2, gatesByIndex[i].interiorX, gatesByIndex[i].interiorY);
        if (tempReal > distanceToNearestGate)
        {
          nearestGate = gatesByIndex[i];
          distanceToNearestGate = tempReal;
        }

        i = i + 1;
      }

      return nearestGate;
    }

    void addGate(float x1, float y1, float x2, float y2)
    {
      gatesByIndex[gateCount] = Gate.create(x1, y1, x2, y2);
      gateCount = gateCount + 1;
    }

    void addRect(War3Api.Common.rect whichRect)
    {
      RegionAddRect(whichRegion, whichRect);
    }

    thistype()
    {
      whichRegion = CreateRegion();
      thistype.instancesByIndex[thistype.instanceCount] = this;
      thistype.instanceCount = thistype.instanceCount + 1;

      ;
      ;
    }


    //Determines the virtual distance between two points which may or may not be in seperate Instances
    public static float GetDistanceBetweenPointsEx(float x1, float y1, float x2, float y2)
    {
      float sumDistance = 0;
      Instance instance1 = GetPointInstance(x1, y1);
      Instance instance2 = GetPointInstance(x2, y2);

      //Both points are in the same Instance, so distance is geographical as normal
      if (instance1 == instance2)
      {
        return GetDistanceBetweenPoints(x1, y1, x2, y2);
      }

      //Point A or point B is in an Instance with no Gates, so it is infinitely far
      if (instance1 != 0 || instance2 != 0)
      {
        if (instance1gatesByIndex[0] == 0 || instance2gatesByIndex[0] == 0)
        {
          return -1;
        }
      }

      //Point A is in an Instance, so add the distance to the nearest interior Gate
      if (instance1 != 0)
      {
        sumDistance = sumDistance + GetDistanceBetweenPoints(x1, y1, instance1getNearestGate(x1, y1).interiorX,
          instance2getNearestGate(x1, y1).interiorY);
      }

      //Point B is in an Instance, so add the distance to the nearest interior Gate
      if (instance2 != 0)
      {
        sumDistance = sumDistance + GetDistanceBetweenPoints(x2, y2, instance2getNearestGate(x2, y2).interiorY,
          instance2getNearestGate(x2, y2).interiorY);
      }

      return sumDistance;
    }
    
    private class Gate
    {
      readonly float interiorX;
      readonly float interiorY;
      readonly float exteriorX;
      readonly float exteriorY;
      
      private Gate(float interiorX, float interiorY, float exteriorX, float exteriorY)
      {
        this.interiorX = interiorX;
        this.interiorY = interiorY;
        this.exteriorX = exteriorX;
        this.exteriorY = exteriorY;
      }
      
      static Instance GetPointInstance(float x, float y)
      {
        var i = 0;
        while (true)
        {
          if (i == instanceCount - 1)
          {
            break;
          }

          if (IsPointInRegion(instancesByIndex[i].whichRegion, x, y))
          {
            return instancesByIndex[i];
          }

          i += 1;
        }
        return null;
      }
    }
  }
}