//Just records a bunch of locations that are considered "shores" for the purposes of determing where the nearest shore is. 

library Shore requires Instance

  struct Shore
    readonly static thistype array shoresByIndex
    readonly static integer shoreCount = 0

    readonly real x = 0
    readonly real y = 0

    static method Count takes nothing returns integer
      return thistype.shoreCount
    endmethod

    static method ByIndex takes integer i returns thistype
      return thistype.shoresByIndex[i]
    endmethod

    static method create takes real x, real y returns thistype
      local thistype this = thistype.allocate()

      set this.x = x
      set this.y = y
      set thistype.shoresByIndex[shoreCount] = this
      set thistype.shoreCount = thistype.shoreCount + 1

      return this
    endmethod
  endstruct

  function GetNearestShore takes real x, real y returns Shore
    local integer i = 0
    local Shore nearestShore = 0
    local real nearestDistance = 1000000
    local real tempDistance = 0
    loop
    exitwhen i == Shore.shoreCount
      set tempDistance = GetDistanceBetweenPointsEx(x, y, Shore.shoresByIndex[i].x, Shore.shoresByIndex[i].y)
      if tempDistance < nearestDistance then
        set nearestDistance = tempDistance
        set nearestShore = Shore.shoresByIndex[i]
      endif
      set i = i + 1
    endloop
    return nearestShore
  endfunction

endlibrary