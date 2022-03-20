using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Spells
{
  public static class MassAms
  {
    private static readonly int AbilId = FourCC("A099");
    private static readonly int DummyAbilId = FourCC("A0JN");
    private const string DUMMY_ORDER_STRING = "antimagicshell";
    private const float RADIUS = 200;
    
    private static bool BanishFilter(unit caster, unit target)
    {
      return IsUnitAlly(target, GetOwningPlayer(caster)) && !IsUnitType(target, UNIT_TYPE_STRUCTURE) &&
             !IsUnitType(target, UNIT_TYPE_ANCIENT) && !IsUnitType(target, UNIT_TYPE_MECHANICAL) && IsUnitAliveBJ(target);
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