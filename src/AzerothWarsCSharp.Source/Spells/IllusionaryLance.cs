using AzerothWarsCSharp.MacroTools;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Spells
{
  public static class IllusionaryLance
  {
    private static readonly int UnittypeId = FourCC("U02A");
    private static readonly int AbilId = FourCC("A0SF");
    private static readonly int DummyAbilId = FourCC("A0SI");
    private const int DUMMY_ORDER_ID = 852274;

    private const float ILLUSIONCHANCE_HERO = 01;
    private const float ILLUSIONCHANCE_ILLUSION = 001;
    
    private static void Damaging()
    {
      var level = GetUnitAbilityLevel(GetEventDamageSource(), AbilId);
      if (level > 0 && BlzGetEventIsAttack())
      {
        float chance;
        if (IsUnitIllusion(GetEventDamageSource()))
        {
          chance = level * ILLUSIONCHANCE_ILLUSION;
        }
        else
        {
          chance = level * ILLUSIONCHANCE_HERO;
        }

        if (GetRandomReal(0, 1) <= chance)
        {
          DummyCast.DummyCastUnitId(GetOwningPlayer(GetEventDamageSource()), DummyAbilId, DUMMY_ORDER_ID, 1,
            GetEventDamageSource());
        }
      }
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDamages, Damaging, UnittypeId);
    }
  }
}