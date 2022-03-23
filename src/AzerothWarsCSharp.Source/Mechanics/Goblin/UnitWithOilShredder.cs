namespace AzerothWarsCSharp.Source.Mechanics.Goblin
{
  public class UnitWithFuelShredder{

  
    private const int UNIT_TYPE = FourCC(n062);
    private const int TICK_RATE = 1;
  


    //! runtextmacro AIDS()
    private float _tick;

    private static bool AIDS_filter(unit u ){
      if (GetUnitTypeId(u) == UNIT_TYPE){
        return true;
      }
      return false;
    }

    private void AIDS_onCreate( ){
      _tick = 0;
      this.startPeriodic();
    }

    private void AIDS_onDestroy( ){
      _tick = 0;
      this.stopPeriodic();
    }

    private void Unfreeze( ){
      PauseUnit(this.unit, false);
      SetUnitTimeScalePercent( this.unit, 10000 );
    }

    private void Freeze( ){
      PauseUnit(this.unit, true);
      SetUnitTimeScalePercent( this.unit, 000 );
    }

    private void Periodic( ){
      _tick = _tick + 1;
      if (_tick == TICK_RATE * T32_FPS){
        if (GetUnitState(this.unit, UNIT_STATE_MANA) < 1){
          Freeze();
        }else if (GetUnitState(this.unit, UNIT_STATE_MANA) > 50 || !UnitAlive(this.unit)){
          Unfreeze();
        }
        _tick = 0;
      }
    }




  }
}
