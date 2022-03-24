using System;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public class BlackEmpirePortal
  {
    private const int BLACKEMPIREPORTALSTATE_CLOSED = 0;
    private const int BLACKEMPIREPORTALSTATE_EXITONLY = 1;
    private const int BLACKEMPIREPORTALSTATE_OPEN = 2;


    private static thistype[] _byIndex;
    private static int _count = 0;
    private static thistype _objective; //The portal that needs to be opened now
    private unit _exteriorWaygate;
    private float _interiorDestinationX;
    private float _interiorDestinationY;

    private unit _interiorWaygate;
    private string _name;

    private ControlPoint _nearbyControlPoint; //This Control Point is the closest one to the exterior Waygate
    private BlackEmpirePortal _next; //The portal that needs to be opened after this one.
    private BlackEmpirePortalState _portalState;

    private NearbyControlPoint()
    {
      ;._nearbyControlPoint;
    }

    private Name()
    {
      ;._name;
    }

    private Objective()
    {
      ;
      type.objective;
    }
    this.

    private SetupWaygateDestinations();

    private FogModifierStart(CreateFogModifierRadius
    private GetUnitX(exteriorWaygate),

    private GetUnitY(exteriorWaygate), 700, true, true));
      this.

    public BlackEmpirePortalState PortalState
    {
      get { return _portalState; }
      set
      {
        _portalState = value;

        switch (_portalState)
        {
          case BlackEmpirePortalState.Closed:
            WaygateActivate(_interiorWaygate, false);
            WaygateActivate(_exteriorWaygate, false);

            SetUnitAnimation(_exteriorWaygate, "death");
            SetUnitVertexColor(_interiorWaygate, 255, 50, 50, 255);
            break;
          case BlackEmpirePortalState.ExitOnly:
            WaygateActivate(_interiorWaygate, true);
            WaygateActivate(_exteriorWaygate, false);

            SetUnitAnimation(_exteriorWaygate, "death");
            SetUnitVertexColor(_interiorWaygate, 150, 150, 255, 230);
            break;
          case BlackEmpirePortalState.Open:
            WaygateActivate(_interiorWaygate, true);
            WaygateActivate(_exteriorWaygate, true);

            SetUnitAnimation(_exteriorWaygate, "birth");
            SetUnitVertexColor(_interiorWaygate, 255, 255, 255, 255);
            break;
          default:
            throw new ArgumentOutOfRangeException(nameof(PortalState), "Invalid portal state.");
        }
      }

      private

    public ControlPoint operator

    public void operator NearbyControlPoint=(ControlPoint value ) {
      _nearbyControlPoint = value;
    }

    public string operator

    private void SetupWaygateDestinations()
    {
      WaygateSetDestination(_interiorWaygate, GetUnitX(_exteriorWaygate), GetUnitY(_exteriorWaygate));
      WaygateSetDestination(_exteriorWaygate, _interiorDestinationX, _interiorDestinationY);
    }

    public void operator Next=(BlackEmpirePortal value ) {
      _next = value;
    }

    //Progresses the current Portal objective to the next one.
    public static void GoToNext()
    {
      thistype.objective = thistype.objective.next;
    }

    public static void operator Objective=(thistype value ) {
      thistype.objective = value;
    }

    public static thistype operator interiorWaygate=interiorWaygate;
    this.interiorDestinationX=interiorDestinationX;
    this.interiorDestinationY=interiorDestinationY;
    this.exteriorWaygate=exteriorWaygate;
    this.interiorPortal=interiorPortal;
    this.name=name;
    this.
    thistype.byIndex[thistype.count] = this;
    thistype.count=thistype.count+ 1;(14),FOG_OF_WAR_VISIBLE,PortalState=BLACKEMPIREPORTALSTATE_CLOSED;
  }
}


}