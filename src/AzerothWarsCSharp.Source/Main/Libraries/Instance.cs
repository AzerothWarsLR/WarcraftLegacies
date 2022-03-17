//An instance is a region that is physically seperate from all other instances irrespective of its actual geographical location on the Warcraft map.

public class Instance{


      readonly float interiorX = 0;
      readonly float interiorY = 0;
      readonly float exteriorX = 0;
      readonly float exteriorY = 0;

       thistype (float interiorX, float interiorY, float exteriorX, float exteriorY ){


        this.interiorX = interiorX;
        this.interiorY = interiorY;
        this.exteriorX = exteriorX;
        this.exteriorY = exteriorY;

        ;;
      }


    static Instance GetPointInstance(float x, float y ){
      int i = 0;
      while(true){
      if ( i == Instance.instanceCount-1){ break; }
        if (IsPointInRegion(Instance.instancesByIndex[i].whichRegion, x, y)){
          return Instance.instancesByIndex[i];
        }
        i = i + 1;
      }
      return 0;
    }


      readonly static thistype[] instancesByIndex;
      readonly static int instanceCount = 0;
      readonly region whichRegion;
      readonly int gateCount = 0;
      readonly Gate[] gatesByIndex[10];
      private string name = null;

      string operator Name( ){
        ;.name;
      }

      void operator Name=(string value ){
        this.name = value;
      }

      Gate getNearestGate(float x1, float y2 ){
        int i = 0;
        float distanceToNearestGate = 0;
        float tempReal = 0;
        Gate nearestGate = 0;
        while(true){
        if ( i == this.gateCount){ break; }
          tempReal = GetDistanceBetweenPoints(x1, y2, this.gatesByIndex[i].interiorX, this.gatesByIndex[i].interiorY);
          if (tempReal > distanceToNearestGate){
            nearestGate = this.gatesByIndex[i];
            distanceToNearestGate = tempReal;
          }
          i = i + 1;
        }
        return nearestGate;
      }

      void addGate(float x1, float y1, float x2, float y2 ){
        this.gatesByIndex[gateCount] = Gate.create(x1, y1, x2, y2);
        this.gateCount = this.gateCount + 1;
      }

      void addRect(rect whichRect ){
        RegionAddRect(this.whichRegion, whichRect);
      }

       thistype ( ){


        this.whichRegion = CreateRegion();
        thistype.instancesByIndex[thistype.instanceCount] = this;
        thistype.instanceCount = thistype.instanceCount + 1;

        ;;
      }


    //Determines the virtual distance between two points which may or may not be in seperate Instances
    static float GetDistanceBetweenPointsEx(float x1, float y1, float x2, float y2 ){
      float sumDistance = 0;
      Instance instance1 = GetPointInstance(x1, y1);
      Instance instance2 = GetPointInstance(x2, y2);

      //Both points are in the same Instance, so distance is geographical as normal
      if (instance1 == instance2){
        return GetDistanceBetweenPoints(x1, y1, x2, y2);
      }
      //Point A or point B is in an Instance with no Gates, so it is infinitely far
      if (instance1 != 0 || instance2 != 0){
        if (instance1gatesByIndex[0] == 0 || instance2gatesByIndex[0] == 0){
          return -1;
        }
      }
      //Point A is in an Instance, so add the distance to the nearest interior Gate
      if (instance1 != 0){
        sumDistance = sumDistance + GetDistanceBetweenPoints(x1, y1, instance1getNearestGate(x1, y1).interiorX, instance2getNearestGate(x1, y1).interiorY);
      }
      //Point B is in an Instance, so add the distance to the nearest interior Gate
      if (instance2 != 0){
        sumDistance = sumDistance + GetDistanceBetweenPoints(x2, y2, instance2getNearestGate(x2, y2).interiorY, instance2getNearestGate(x2, y2).interiorY);
      }
      return sumDistance;
    }

}
