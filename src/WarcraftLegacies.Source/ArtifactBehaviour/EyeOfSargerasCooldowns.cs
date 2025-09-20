using MacroTools.Extensions;
using WCSharp.Events;

namespace WarcraftLegacies.Source.ArtifactBehaviour;

/// <summary>
/// Eye of Sargeras' abilities go on cooldown when transferring the item between heroes to avoid abuse.
/// </summary>
public static class EyeOfSargerasCooldowns
{
  private const int SpellA = ABILITY_A04G_INVISIBILITY_EYE_OF_SARGERAS_NEUTRAL_HOSTILE;
  private const int SpellB = ABILITY_ACRG_RAIN_OF_FIRE_SPELLBOOK;
  private const int SpellC = ABILITY_ACDE_DEVOUR_MAGIC_RAVAGER;
  private const int SpellD = ABILITY_A04B_DEMON_CALL_EYE_OF_SARGERAS;

  private static void ItemPickup()
  {
    var triggerUnit = GetTriggerUnit();
    triggerUnit.StartAbilityCooldown(SpellA);
    triggerUnit.StartAbilityCooldown(SpellB);
    triggerUnit.StartAbilityCooldown(SpellC);
    triggerUnit.StartAbilityCooldown(SpellD);
  }

  /// <summary>
  /// Sets up <see cref="EyeOfSargerasCooldowns"/>.
  /// </summary>
  public static void Setup() =>
    PlayerUnitEvents.Register(ItemTypeEvent.IsPickedUp, ItemPickup, ITEM_I003_EYE_OF_SARGERAS);
}
