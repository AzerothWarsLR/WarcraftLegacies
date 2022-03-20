//Casts Flame Strike at itself every few seconds.

using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Main.Spells.Quel_thalas
{
  public static class RecurrentFlameStrike
  {
    private static readonly int AbilId = FourCC("A04H");
    private static readonly int DummySpellId = FourCC("A0F9");
    private const string DUMMY_SPELL_ORDER = "flamestrike";
    private const float DURATION = 14;
    private const float PERIOD = 7;
    
    private unit caster;
    private float x;
    private float y;
    private float tick;
    private float duration;
    private int level;

    private void destroy()
    {
      stopPeriodic();
      caster = null;
      deallocate();
    }

    private void Cast()
    {
      DummyCastPoint(GetOwningPlayer(caster), DummySpellId, DUMMY_SPELL_ORDER, level, x, y);
    }

    private void periodic()
    {
      tick = tick + 1;
      duration = duration - 1 / T32_FPS;
      if (tick >= PERIOD * T32_FPS)
      {
        Cast();
        tick = tick - PERIOD * T32_FPS;
      }

      if (duration <= 0)
      {
        destroy();
      }
    }


    thistype(unit caster, float x, float y, int level)
    {
      this.caster = caster;
      duration = DURATION;
      this.x = x;
      this.y = y;
      this.level = level;
      tick = 0;
      startPeriodic();
      Cast();
      ;
      ;
    }


    private static void Cast()
    {
      RecurrentFlameStrike.create(GetTriggerUnit(), GetSpellTargetX(), GetSpellTargetY(),
        GetUnitAbilityLevel(GetTriggerUnit(), AbilId));
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.SpellEffect, Cast, AbilId);
    }
  }
}