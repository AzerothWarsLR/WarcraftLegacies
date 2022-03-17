//Casts Flame Strike at itself every few seconds.
namespace AzerothWarsCSharp.Source.Main.Spells.Quel_thalas
{
  public class RecurrentFlameStrike{

  
    private const int ABIL_ID = FourCC(A04H);
    private const int DUMMY_SPELL_ID = FourCC(A0F9);
    private const string DUMMY_SPELL_ORDER = "flamestrike";
    private const float DURATION = 14;
    private const float PERIOD = 7;
  


    private unit caster = null;
    private float x = 0;
    private float y = 0;
    private float tick = 0;
    private float duration = 0;
    private int level = 0;

    private void destroy( ){
      stopPeriodic();
      caster = null;
      deallocate();
    }

    private void Cast( ){
      DummyCastPoint(GetOwningPlayer(this.caster), DUMMY_SPELL_ID, DUMMY_SPELL_ORDER, this.level, this.x, this.y);
    }

    private void periodic( ){
      tick = tick + 1;
      duration = duration - 1 / T32_FPS;
      if (tick >= PERIOD * T32_FPS){
        Cast();
        tick = tick - PERIOD * T32_FPS;
      }
      if (duration <= 0){
        destroy();
      }
    }



    thistype (unit caster, float x, float y, int level ){

      this.caster = caster;
      this.duration = DURATION;
      this.x = x;
      this.y = y;
      this.level = level;
      this.tick = 0;
      startPeriodic();
      Cast();
      ;;
    }


    private static void Cast( ){
      RecurrentFlameStrike.create(GetTriggerUnit(), GetSpellTargetX(), GetSpellTargetY(), GetUnitAbilityLevel(GetTriggerUnit(), ABIL_ID));
    }

    private static void OnInit( ){
      RegisterSpellEffectAction(ABIL_ID,  Cast);
    }

  }
}
