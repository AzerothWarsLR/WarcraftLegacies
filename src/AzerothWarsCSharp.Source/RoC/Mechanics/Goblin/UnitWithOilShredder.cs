namespace AzerothWarsCSharp.Source.RoC.Mechanics.Goblin
{
  public class UnitWithFuelShredder{

  
    private const int UNIT_TYPE = FourCC(n062);
    private const int TICK_RATE = 1;
  


    //! runtextmacro AIDS()
    private float tick;

    private static boolean AIDS_filter(unit u ){
      if (GetUnitTypeId(u) == UNIT_TYPE){
        return true;
      }
      return false;
    }

    private void AIDS_onCreate( ){
      tick = 0;
      this.startPeriodic();
    }

    private void AIDS_onDestroy( ){
      this.tick = 0;
      this.stopPeriodic();
    }

    private void unfreeze( ){
      PauseUnit(this.unit, false);
      SetUnitTimeScalePercent( this.unit, 10000 );
    }

    private void freeze( ){
      PauseUnit(this.unit, true);
      SetUnitTimeScalePercent( this.unit, 000 );
    }

    private void periodic( ){
      tick = tick + 1;
      if (tick == TICK_RATE * T32_FPS){
        if (GetUnitState(this.unit, UNIT_STATE_MANA) < 1){
          this.freeze();
        }else if (GetUnitState(this.unit, UNIT_STATE_MANA) > 50 || !UnitAlive(this.unit)){
          this.unfreeze();
        }
        tick = 0;
      }
    }




  }
}
