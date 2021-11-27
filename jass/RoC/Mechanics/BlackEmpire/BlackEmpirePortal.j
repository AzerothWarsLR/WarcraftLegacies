library BlackEmpirePortal requires GameSetup

  globals
    constant integer BLACKEMPIREPORTALSTATE_CLOSED = 0
    constant integer BLACKEMPIREPORTALSTATE_EXITONLY = 1
    constant integer BLACKEMPIREPORTALSTATE_OPEN = 2
  endglobals

  struct BlackEmpirePortal
    private static thistype array byIndex
    private static integer count = 0
    private static thistype objective //The portal that needs to be opened now

    private unit interiorWaygate
    private real interiorDestinationX
    private real interiorDestinationY
    private unit exteriorWaygate
    private destructable interiorPortal
    private ControlPoint nearbyControlPoint //This Control Point is the closest one to the exterior Waygate
    private BlackEmpirePortal next //The portal that needs to be opened after this one.
    private string name
    private integer portalState

    public method operator NearbyControlPoint takes nothing returns ControlPoint
      return this.nearbyControlPoint
    endmethod

    public method operator NearbyControlPoint= takes ControlPoint value returns nothing
      set this.nearbyControlPoint = value
    endmethod

    public method operator Name takes nothing returns string
      return this.name
    endmethod

    public method operator PortalState takes nothing returns integer
      return this.portalState
    endmethod

    public method operator PortalState= takes integer value returns nothing
      set this.portalState = value

      if this.portalState == BLACKEMPIREPORTALSTATE_CLOSED then
        call WaygateActivate(interiorWaygate, false)
        call WaygateActivate(exteriorWaygate, false)
        call SetDestructableAnimation(this.interiorPortal, "death")
        call SetUnitAnimation(this.exteriorWaygate, "death")
        call SetUnitVertexColor(this.interiorWaygate, 255, 50, 50, 255)
      endif

      if this.portalState == BLACKEMPIREPORTALSTATE_EXITONLY then
        call WaygateActivate(interiorWaygate, true)
        call WaygateActivate(exteriorWaygate, false)
        call SetDestructableAnimation(this.interiorPortal, "birth")
        call SetUnitAnimation(this.exteriorWaygate, "death")
        call SetUnitVertexColor(this.interiorWaygate, 150, 150, 255, 230)
      endif

      if this.portalState == BLACKEMPIREPORTALSTATE_OPEN then
        call WaygateActivate(interiorWaygate, true)
        call WaygateActivate(exteriorWaygate, true)
        call SetDestructableAnimation(this.interiorPortal, "birth")
        call SetUnitAnimation(this.exteriorWaygate, "birth")
        call SetUnitVertexColor(this.interiorWaygate, 255, 255, 255, 255)
      endif
    endmethod

    private method SetupWaygateDestinations takes nothing returns nothing
      call WaygateSetDestination(interiorWaygate, GetUnitX(exteriorWaygate), GetUnitY(exteriorWaygate))
      call WaygateSetDestination(exteriorWaygate, interiorDestinationX, interiorDestinationY)
    endmethod

    public method operator Next= takes BlackEmpirePortal value returns nothing
      set this.next = value
    endmethod

    //Progresses the current Portal objective to the next one.
    public static method GoToNext takes nothing returns nothing
      set thistype.objective = thistype.objective.next
    endmethod

    public static method operator Objective= takes thistype value returns nothing
      set thistype.objective = value
    endmethod

    public static method operator Objective takes nothing returns thistype
      return thistype.objective
    endmethod

    public static method create takes unit interiorWaygate, destructable interiorPortal, real interiorDestinationX, real interiorDestinationY, unit exteriorWaygate, string name returns thistype
      local thistype this = thistype.allocate()
      set this.interiorWaygate = interiorWaygate
      set this.interiorDestinationX = interiorDestinationX
      set this.interiorDestinationY = interiorDestinationY
      set this.exteriorWaygate = exteriorWaygate
      set this.interiorPortal = interiorPortal
      set this.name = name
      call this.SetupWaygateDestinations()
      set thistype.byIndex[thistype.count] = this
      set thistype.count = thistype.count + 1

      call FogModifierStart(CreateFogModifierRadius(Player(14), FOG_OF_WAR_VISIBLE, GetUnitX(exteriorWaygate), GetUnitY(exteriorWaygate), 700, true, true))
      set this.PortalState = BLACKEMPIREPORTALSTATE_CLOSED
      return this
    endmethod
  endstruct

endlibrary