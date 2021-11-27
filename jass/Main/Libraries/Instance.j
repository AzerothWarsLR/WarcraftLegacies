//An instance is a region that is physically seperate from all other instances irrespective of its actual geographical location on the Warcraft map.

library Instance requires Math

    private struct Gate
      readonly real interiorX = 0
      readonly real interiorY = 0
      readonly real exteriorX = 0
      readonly real exteriorY = 0

      static method create takes real interiorX, real interiorY, real exteriorX, real exteriorY returns thistype
        local thistype this = thistype.allocate()

        set this.interiorX = interiorX
        set this.interiorY = interiorY
        set this.exteriorX = exteriorX
        set this.exteriorY = exteriorY

        return this
      endmethod
    endstruct

    function GetPointInstance takes real x, real y returns Instance
      local integer i = 0
      loop
      exitwhen i == Instance.instanceCount-1
        if IsPointInRegion(Instance.instancesByIndex[i].whichRegion, x, y) then
          return Instance.instancesByIndex[i]
        endif
        set i = i + 1
      endloop
      return 0
    endfunction

    struct Instance
      readonly static thistype array instancesByIndex
      readonly static integer instanceCount = 0
      readonly region whichRegion
      readonly integer gateCount = 0
      readonly Gate array gatesByIndex[10]
      private string name = null

      method operator Name takes nothing returns string
        return this.name
      endmethod

      method operator Name= takes string value returns nothing
        set this.name = value
      endmethod

      method getNearestGate takes real x1, real y2 returns Gate
        local integer i = 0
        local real distanceToNearestGate = 0
        local real tempReal = 0
        local Gate nearestGate = 0
        loop
        exitwhen i == this.gateCount
          set tempReal = GetDistanceBetweenPoints(x1, y2, this.gatesByIndex[i].interiorX, this.gatesByIndex[i].interiorY)
          if tempReal > distanceToNearestGate then
            set nearestGate = this.gatesByIndex[i]
            set distanceToNearestGate = tempReal
          endif
          set i = i + 1
        endloop
        return nearestGate
      endmethod

      method addGate takes real x1, real y1, real x2, real y2 returns nothing
        set this.gatesByIndex[gateCount] = Gate.create(x1, y1, x2, y2)
        set this.gateCount = this.gateCount + 1
      endmethod

      method addRect takes rect whichRect returns nothing
        call RegionAddRect(this.whichRegion, whichRect)
      endmethod

      static method create takes nothing returns thistype
        local thistype this = thistype.allocate()

        set this.whichRegion = CreateRegion()
        set thistype.instancesByIndex[thistype.instanceCount] = this
        set thistype.instanceCount = thistype.instanceCount + 1

        return this
      endmethod
    endstruct

    //Determines the virtual distance between two points which may or may not be in seperate Instances
    function GetDistanceBetweenPointsEx takes real x1, real y1, real x2, real y2 returns real
      local real sumDistance = 0
      local Instance instance1 = GetPointInstance(x1, y1)
      local Instance instance2 = GetPointInstance(x2, y2)

      //Both points are in the same Instance, so distance is geographical as normal
      if instance1 == instance2 then
        return GetDistanceBetweenPoints(x1, y1, x2, y2)
      endif
      //Point A or point B is in an Instance with no Gates, so it is infinitely far
      if instance1 != 0 or instance2 != 0 then
        if instance1.gatesByIndex[0] == 0 or instance2.gatesByIndex[0] == 0 then
          return -1.
        endif
      endif
      //Point A is in an Instance, so add the distance to the nearest interior Gate
      if instance1 != 0 then
        set sumDistance = sumDistance + GetDistanceBetweenPoints(x1, y1, instance1.getNearestGate(x1, y1).interiorX, instance2.getNearestGate(x1, y1).interiorY)
      endif
      //Point B is in an Instance, so add the distance to the nearest interior Gate
      if instance2 != 0 then
        set sumDistance = sumDistance + GetDistanceBetweenPoints(x2, y2, instance2.getNearestGate(x2, y2).interiorY, instance2.getNearestGate(x2, y2).interiorY)
      endif
      return sumDistance
    endfunction

endlibrary