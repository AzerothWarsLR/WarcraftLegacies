namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public class Herald{

  
    private const int HERALD_ID = FourCC(u02E);
    private const string DEATH_EFFECT = "Abilities\\Spells\\Items\\AIre\\AIreTarget.mdl";
  


    //! runtextmacro AIDS()
    private static thistype _instance = 0 ;//There can only be one Herald.
    private BlackEmpirePortal _linkedPortal ;//Each Herald keeps a BlackEmpirePortal active, but only while alive.

    public static thistype operator Instance( ){
      ;type.instance;
    }

    private void UnlinkToPortal( ){
      if (_linkedPortal.PortalState == BLACKEMPIREPORTALSTATE_EXITONLY){
        _linkedPortal.PortalState = BLACKEMPIREPORTALSTATE_CLOSED;
      }
      _linkedPortal = 0;
    }

    private void LinkToPortal(BlackEmpirePortal whichPortal ){
      _linkedPortal = whichPortal;
      _linkedPortal.PortalState = BLACKEMPIREPORTALSTATE_EXITONLY;
    }

    private void AIDS_onCreate( ){
      if (_instance == 0){
        _instance = this;
      }else {
        BJDebugMsg("ERROR: there can only be one " + GetObjectName(HERALD_ID));
        return;
      }
      LinkToPortal(BlackEmpirePortal.Objective);
      BlzSetUnitName(this.unit, "Herald of " + _linkedPortal.Name);
    }

    private void AIDS_onDestroy( ){
      if (this == _instance){
        ReturnToNyalotha();
        UnlinkToPortal();
        _instance = 0;
      }
    }

    private static bool AIDS_filter(unit u ){
      if (GetUnitTypeId(u) == HERALD_ID){
        return true;
      }
      return false;
    }


    private static void OnHeraldDeath( ){
      DestroyEffect(AddSpecialEffect(DEATH_EFFECT, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit())));
      RemoveUnit(GetTriggerUnit());
    }

    public static void Setup( ){
      RegisterUnitTypeDiesAction(HERALD_ID,  OnHeraldDeath);
    }

  }
}
