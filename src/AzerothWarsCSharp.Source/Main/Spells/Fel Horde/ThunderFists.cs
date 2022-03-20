using AzerothWarsCSharp.Source.Main.Libraries;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Main.Spells.Fel_Horde
{
  public static class ThunderFists
  {
    private static readonly int UnittypeId = FourCC("O01P");
    private static readonly int AbilId = FourCC("A0LN");
    private static readonly int DummyAbilId = FourCC("A024");
    private const string DUMMY_ORDER_ID = "forkedlightning";

    private const float CHANCE = 0.15f;

    private static void Damaging()
    {
      var level = GetUnitAbilityLevel(GetEventDamageSource(), AbilId);
      if (level > 0 && BlzGetEventIsAttack() && GetRandomReal(0, 1) <= CHANCE)
      {
        DummyCast.DummyCastUnitFromPoint(GetOwningPlayer(GetEventDamageSource()), DummyAbilId, DUMMY_ORDER_ID, level,
          GetTriggerUnit(), GetUnitX(GetEventDamageSource()), GetUnitY(GetEventDamageSource()));
      }
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDamages, Damaging, UnittypeId);
    }
  }
}