using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Spells
{
  public static class BombingRun
  {
    private static readonly int AbilId = FourCC("A0S5");
    private static readonly int LocustSwarmId = FourCC("A0S1");
    
    private static void Cast()
    {
      DummyCast.DummyChannelInstantFromPoint(GetOwningPlayer(GetTriggerUnit()), LocustSwarmId, "locustswarm", 1,
        GetSpellTargetX(), GetSpellTargetY(), 15);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.SpellEffect, Cast, AbilId);
    }
  }
}