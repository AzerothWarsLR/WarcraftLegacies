using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Spells.Kul_tiras
{
  public static class Scattershot
  {
    private static readonly int AbilId = FourCC("A0GP");
    private static readonly int DummyAbilId = FourCC("A0GL");
    private const string DUMMY_ORDER_STRING = "thunderbolt";
    private const float RADIUS = 250;

    private static bool ScattershotFilter(unit caster, unit target)
    {
      return !IsUnitAlly(target, GetOwningPlayer(caster)) && !IsUnitType(target, UNIT_TYPE_STRUCTURE) &&
             !IsUnitType(target, UNIT_TYPE_ANCIENT) && !IsUnitType(target, UNIT_TYPE_MECHANICAL) &&
             IsUnitAliveBJ(target);
    }

    private static void Cast()
    {
      DummyCast.DummyCastFromPointOnUnitsInCircle(GetTriggerUnit(), DummyAbilId, DUMMY_ORDER_STRING,
        GetUnitAbilityLevel(GetTriggerUnit(), AbilId), GetSpellTargetX(), GetSpellTargetY(), RADIUS,
        GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()), ScattershotFilter);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.SpellEffect, Cast, AbilId);
    }
  }
}