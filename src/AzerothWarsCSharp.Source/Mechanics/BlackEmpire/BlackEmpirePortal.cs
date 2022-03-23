using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public class BlackEmpirePortal{

  
    const int BLACKEMPIREPORTALSTATE_CLOSED = 0;
    const int BLACKEMPIREPORTALSTATE_EXITONLY = 1;
    const int BLACKEMPIREPORTALSTATE_OPEN = 2;
  


    private static thistype[] _byIndex;
    private static int _count = 0;
    private static thistype _objective ;//The portal that needs to be opened now

    private unit _interiorWaygate;
    private float _interiorDestinationX;
    private float _interiorDestinationY;
    private unit _exteriorWaygate;

    private ControlPoint _nearbyControlPoint ;//This Control Point is the closest one to the exterior Waygate
    private BlackEmpirePortal _next ;//The portal that needs to be opened after this one.
    private string _name;
    private int _portalState;

    public ControlPoint operator NearbyControlPoint( ){
      ;._nearbyControlPoint;
    }

    public void operator NearbyControlPoint=(ControlPoint value ){
      _nearbyControlPoint = value;
    }

    public string operator Name( ){
      ;._name;
    }

    public integer operator PortalState( ){
      ;._portalState;
    }

    public void operator PortalState=(int value ){
      _portalState = value;

      if (_portalState == BLACKEMPIREPORTALSTATE_CLOSED){
        WaygateActivate(_interiorWaygate, false);
        WaygateActivate(_exteriorWaygate, false);

        SetUnitAnimation(_exteriorWaygate, "death");
        SetUnitVertexColor(_interiorWaygate, 255, 50, 50, 255);
      }

      if (_portalState == BLACKEMPIREPORTALSTATE_EXITONLY){
        WaygateActivate(_interiorWaygate, true);
        WaygateActivate(_exteriorWaygate, false);

        SetUnitAnimation(_exteriorWaygate, "death");
        SetUnitVertexColor(_interiorWaygate, 150, 150, 255, 230);
      }

      if (_portalState == BLACKEMPIREPORTALSTATE_OPEN){
        WaygateActivate(_interiorWaygate, true);
        WaygateActivate(_exteriorWaygate, true);

        SetUnitAnimation(_exteriorWaygate, "birth");
        SetUnitVertexColor(_interiorWaygate, 255, 255, 255, 255);
      }
    }

    private void SetupWaygateDestinations( ){
      WaygateSetDestination(_interiorWaygate, GetUnitX(_exteriorWaygate), GetUnitY(_exteriorWaygate));
      WaygateSetDestination(_exteriorWaygate, _interiorDestinationX, _interiorDestinationY);
    }

    public void operator Next=(BlackEmpirePortal value ){
      _next = value;
    }

    //Progresses the current Portal objective to the next one.
    public static void GoToNext( ){
      thistype.objective = thistype.objective.next;
    }

    public static void operator Objective=(thistype value ){
      thistype.objective = value;
    }

    public static thistype operator Objective( ){
      ;type.objective;
    }



    this.interiorWaygate = interiorWaygate;
    this.interiorDestinationX = interiorDestinationX;
    this.interiorDestinationY = interiorDestinationY;
    this.exteriorWaygate = exteriorWaygate;
    this.interiorPortal = interiorPortal;
    this.name = name;
    this.SetupWaygateDestinations();
    thistype.byIndex[thistype.count] = this;
    thistype.count = thistype.count + 1;

    FogModifierStart(CreateFogModifierRadius(Player(14), FOG_OF_WAR_VISIBLE, GetUnitX(exteriorWaygate), GetUnitY(exteriorWaygate), 700, true, true));
      this.PortalState = BLACKEMPIREPORTALSTATE_CLOSED;
    
  }
}


}
