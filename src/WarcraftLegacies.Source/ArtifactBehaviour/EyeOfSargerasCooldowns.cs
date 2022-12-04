using MacroTools.SpellSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.Source.ArtifactBehaviour
{
  /// <summary>
  /// Eye of Sargeras' abilities go on cooldown when transferring the item between heroes to avoid abuse.
  /// </summary>
  public sealed class EyeOfSargerasCooldowns
  {
    private static readonly int SpellA = FourCC("A04G");
    private static readonly int SpellB = FourCC("ACrg");
    private static readonly int SpellC = FourCC("ACde");
    private static readonly int SpellD = FourCC("A04B");

    private static void ItemPickup()
    {
      var triggerUnit = GetTriggerUnit();
      SpellHelpers.StartUnitAbilityCooldownFull(triggerUnit, SpellA);
      SpellHelpers.StartUnitAbilityCooldownFull(triggerUnit, SpellB);
      SpellHelpers.StartUnitAbilityCooldownFull(triggerUnit, SpellC);
      SpellHelpers.StartUnitAbilityCooldownFull(triggerUnit, SpellD);
    }

    /// <summary>
    /// Sets up <see cref="EyeOfSargerasCooldowns"/>.
    /// </summary>
    public static void Setup()
    {
      PlayerUnitEvents.Register(UnitTypeEvent.PicksUpItem, ItemPickup, Constants.ITEM_I003_EYE_OF_SARGERAS);
    }
  }
}