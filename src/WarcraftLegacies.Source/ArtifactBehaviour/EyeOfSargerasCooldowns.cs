using WarcraftLegacies.MacroTools.SpellSystem;
using WCSharp.Events;

using static War3Api.Common;

namespace WarcraftLegacies.Source.Artifacts
{
  public class EyeOfSargerasCooldowns
  {
    private static readonly int SpellA = FourCC("A04G");
    private static readonly int SpellB = FourCC("ACrg");
    private static readonly int SpellC = FourCC("ACde");
    private static readonly int SpellD = FourCC("A04B");

    private static void ItemPickup()
    {
      unit triggerUnit = GetTriggerUnit();
      SpellHelpers.StartUnitAbilityCooldownFull(triggerUnit, SpellA);
      SpellHelpers.StartUnitAbilityCooldownFull(triggerUnit, SpellB);
      SpellHelpers.StartUnitAbilityCooldownFull(triggerUnit, SpellC);
      SpellHelpers.StartUnitAbilityCooldownFull(triggerUnit, SpellD);
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypePicksUpItem, ItemPickup, FourCC("I003"));
    }
  }
}