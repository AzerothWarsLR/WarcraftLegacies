namespace AzerothWarsCSharp.Source.RoC.Mechanics.BlackEmpire
{
  public class Herald{

  
    private const int HERALD_ID = FourCC(u02E);
    private const string DEATH_EFFECT = "Abilities\\Spells\\Items\\AIre\\AIreTarget.mdl";
  


    //! runtextmacro AIDS()
    private static thistype instance = 0 ;//There can only be one Herald.
    private BlackEmpirePortal linkedPortal ;//Each Herald keeps a BlackEmpirePortal active, but only while alive.

    public static thistype operator Instance( ){
      ;type.instance;
    }

    private void UnlinkToPortal( ){
      if (this.linkedPortal.PortalState == BLACKEMPIREPORTALSTATE_EXITONLY){
        this.linkedPortal.PortalState = BLACKEMPIREPORTALSTATE_CLOSED;
      }
      this.linkedPortal = 0;
    }

    private void LinkToPortal(BlackEmpirePortal whichPortal ){
      this.linkedPortal = whichPortal;
      this.linkedPortal.PortalState = BLACKEMPIREPORTALSTATE_EXITONLY;
    }

    private void AIDS_onCreate( ){
      if (instance == 0){
        instance = this;
      }else {
        BJDebugMsg("ERROR: there can only be one " + GetObjectName(HERALD_ID));
        return;
      }
      this.LinkToPortal(BlackEmpirePortal.Objective);
      BlzSetUnitName(this.unit, "Herald of " + this.linkedPortal.Name);
    }

    private void AIDS_onDestroy( ){
      if (this == instance){
        ReturnToNyalotha();
        this.UnlinkToPortal();
        instance = 0;
      }
    }

    private static boolean AIDS_filter(unit u ){
      if (GetUnitTypeId(u) == HERALD_ID){
        return true;
      }
      return false;
    }


    private static void OnHeraldDeath( ){
      DestroyEffect(AddSpecialEffect(DEATH_EFFECT, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit())));
      RemoveUnit(GetTriggerUnit());
    }

    private static void OnInit( ){
      RegisterUnitTypeDiesAction(HERALD_ID,  OnHeraldDeath);
    }

  }
}
