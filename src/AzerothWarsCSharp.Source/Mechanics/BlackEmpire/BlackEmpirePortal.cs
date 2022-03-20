using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public class BlackEmpirePortal{

  
    const int BLACKEMPIREPORTALSTATE_CLOSED = 0;
    const int BLACKEMPIREPORTALSTATE_EXITONLY = 1;
    const int BLACKEMPIREPORTALSTATE_OPEN = 2;
  


    private static thistype[] byIndex;
    private static int count = 0;
    private static thistype objective ;//The portal that needs to be opened now

    private unit interiorWaygate;
    private float interiorDestinationX;
    private float interiorDestinationY;
    private unit exteriorWaygate;

    private ControlPoint nearbyControlPoint ;//This Control Point is the closest one to the exterior Waygate
    private BlackEmpirePortal next ;//The portal that needs to be opened after this one.
    private string name;
    private int portalState;

    public ControlPoint operator NearbyControlPoint( ){
      ;.nearbyControlPoint;
    }

    public void operator NearbyControlPoint=(ControlPoint value ){
      nearbyControlPoint = value;
    }

    public string operator Name( ){
      ;.name;
    }

    public integer operator PortalState( ){
      ;.portalState;
    }

    public void operator PortalState=(int value ){
      portalState = value;

      if (portalState == BLACKEMPIREPORTALSTATE_CLOSED){
        WaygateActivate(interiorWaygate, false);
        WaygateActivate(exteriorWaygate, false);

        SetUnitAnimation(exteriorWaygate, "death");
        SetUnitVertexColor(interiorWaygate, 255, 50, 50, 255);
      }

      if (portalState == BLACKEMPIREPORTALSTATE_EXITONLY){
        WaygateActivate(interiorWaygate, true);
        WaygateActivate(exteriorWaygate, false);

        SetUnitAnimation(exteriorWaygate, "death");
        SetUnitVertexColor(interiorWaygate, 150, 150, 255, 230);
      }

      if (portalState == BLACKEMPIREPORTALSTATE_OPEN){
        WaygateActivate(interiorWaygate, true);
        WaygateActivate(exteriorWaygate, true);

        SetUnitAnimation(exteriorWaygate, "birth");
        SetUnitVertexColor(interiorWaygate, 255, 255, 255, 255);
      }
    }

    private void SetupWaygateDestinations( ){
      WaygateSetDestination(interiorWaygate, GetUnitX(exteriorWaygate), GetUnitY(exteriorWaygate));
      WaygateSetDestination(exteriorWaygate, interiorDestinationX, interiorDestinationY);
    }

    public void operator Next=(BlackEmpirePortal value ){
      next = value;
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
    ;;
  }
}


}
