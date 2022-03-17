//Units spawned at Demon Gates spawn at the Focal Demon Gate instead, if one exists.
public class FocalDemonGate{

  
    private const int GATE_UNITTYPE = FourCC(n0AP);
    private const float FACING_OFFSET = -45 ;//Demon gate model is spun around weirdly so this reverses that for code
    private const float SPAWN_DISTANCE = 300 ;//How far away from the gate to spawn units
  


    //! runtextmacro AIDS()
    private static thistype instance = 0;


    float operator RallyX( ){
      location rally = GetUnitRallyPoint(this.unit);
      float x = GetLocationX(rally);
      RemoveLocation(rally);
      rally = null;
      return x;
    }

    float operator RallyY( ){
      location rally = GetUnitRallyPoint(this.unit);
      float y = GetLocationY(rally);
      RemoveLocation(rally);
      rally = null;
      return y;
    }

    float operator SpawnX( ){
      return GetPolarOffsetX(GetUnitX(this.unit), SPAWN_DISTANCE, GetUnitFacing(this.unit) + FACING_OFFSET);
    }

    float operator SpawnY( ){
      return GetPolarOffsetY(GetUnitY(this.unit), SPAWN_DISTANCE, GetUnitFacing(this.unit) + FACING_OFFSET);
    }

    boolean operator Alive( ){
      return UnitAlive(this.unit);
    }

    static thistype operator Instance( ){
      ;type.instance;
    }



      KillUnit(thistype.instance.unit);
      thistype.instance = this;
    }

    private static boolean AIDS_filter(unit u ){
      if (GetUnitTypeId(u) == GATE_UNITTYPE){
        return true;
      }
      return false;
    }

    private void AIDS_onCreate( ){

      IssuePointOrder(this.unit, "setrally", this.SpawnX, this.SpawnY);
    }

    private void AIDS_onDestroy( ){
      if (thistype.instance == this){
        thistype.instance = 0;
      }
    }




  }

  private static void OnInit( ){

  }

}
