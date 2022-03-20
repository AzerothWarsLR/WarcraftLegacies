using AzerothWarsCSharp.Source.Main.Libraries;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Main.Spells.Quel_thalas
{
  public static class MassBanish
  {
    private static readonly int AbilId = FourCC("A0FD");
    private static readonly int DummyAbilId = FourCC("A0FE");
    private const string DUMMY_ORDER_STRING = "banish";
    private const float RADIUS = 250;
    
    private static bool BanishFilter(unit caster, unit target)
    {
      return !IsUnitType(target, UNIT_TYPE_STRUCTURE) && !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
             !IsUnitType(target, UNIT_TYPE_MECHANICAL) && IsUnitAliveBJ(target);
    }

    private static void Cast()
    {
      DummyCast.DummyCastOnUnitsInCircle(GetTriggerUnit(), DummyAbilId, DUMMY_ORDER_STRING,
        GetUnitAbilityLevel(GetTriggerUnit(), AbilId), GetSpellTargetX(), GetSpellTargetY(), RADIUS,
        BanishFilter);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.SpellEffect, Cast, AbilId);
    }
  }
}