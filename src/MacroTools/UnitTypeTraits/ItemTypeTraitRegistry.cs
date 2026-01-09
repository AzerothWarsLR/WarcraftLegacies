using WCSharp.Events;

namespace MacroTools.UnitTypeTraits;

public static class ItemTypeTraitRegistry
{
  /// <summary>
  /// Registers a <see cref="UnitTypeTrait"/> to a single item type, activating its functionality when a unit carrying
  /// that item experiences relevant events.
  /// </summary>
  /// <param name="trait">The trait to register.</param>
  /// <param name="itemTypeId">The item type ID to associate with the trait.</param>
  public static void Register(UnitTypeTrait trait, int itemTypeId)
  {
    RegisterPickupEvent(trait, itemTypeId);
    RegisterDropEvent(trait, itemTypeId);
  }

  private static void RegisterPickupEvent(UnitTypeTrait trait, int itemTypeId)
  {
    PlayerUnitEvents.Register(ItemTypeEvent.IsPickedUp, () =>
    {
      var unit = GetTriggerUnit();
      switch (trait)
      {
        case IEffectOnDamaged effectOnDamaged:
          PlayerUnitEvents.Register(UnitEvent.Damaging, effectOnDamaged.OnDamaged, unit);
          break;

        case IEffectOnDeath effectOnDeath:
          PlayerUnitEvents.Register(UnitEvent.Dies, effectOnDeath.OnDeath, unit);
          break;

        case IEffectOnSpellCast effectOnSpellCast:
          PlayerUnitEvents.Register(UnitEvent.SpellCast, effectOnSpellCast.OnSpellCast, unit);
          break;

        case IEffectOnSpellEffect effectOnSpellEffect:
          PlayerUnitEvents.Register(UnitEvent.SpellEffect, effectOnSpellEffect.OnSpellEffect, unit);
          break;

        case IEffectOnSpellFinish effectOnSpellFinish:
          PlayerUnitEvents.Register(UnitEvent.SpellFinish, effectOnSpellFinish.OnSpellFinish, unit);
          break;

        case IAppliesEffectOnDamage appliesEffectOnDamage:
          PlayerUnitEvents.Register(UnitEvent.Damaging, appliesEffectOnDamage.OnDealsDamage, unit);
          break;

        case IEffectOnSummonedUnit effectOnSummonedUnit:
          PlayerUnitEvents.Register(UnitEvent.Summons, effectOnSummonedUnit.OnSummonedUnit, unit);
          break;
      }
    }, itemTypeId);
  }

  private static void RegisterDropEvent(UnitTypeTrait trait, int itemTypeId)
  {
    PlayerUnitEvents.Register(ItemTypeEvent.IsDropped, () =>
    {
      var unit = GetTriggerUnit();

      switch (trait)
      {
        case IEffectOnDamaged effectOnDamaged:
          PlayerUnitEvents.Unregister(UnitEvent.Damaging, effectOnDamaged.OnDamaged, unit);
          break;

        case IEffectOnDeath effectOnDeath:
          PlayerUnitEvents.Unregister(UnitEvent.Dies, effectOnDeath.OnDeath, unit);
          break;

        case IEffectOnSpellCast effectOnSpellCast:
          PlayerUnitEvents.Unregister(UnitEvent.SpellCast, effectOnSpellCast.OnSpellCast, unit);
          break;

        case IEffectOnSpellEffect effectOnSpellEffect:
          PlayerUnitEvents.Unregister(UnitEvent.SpellEffect, effectOnSpellEffect.OnSpellEffect, unit);
          break;

        case IEffectOnSpellFinish effectOnSpellFinish:
          PlayerUnitEvents.Unregister(UnitEvent.SpellFinish, effectOnSpellFinish.OnSpellFinish, unit);
          break;

        case IAppliesEffectOnDamage appliesEffectOnDamage:
          PlayerUnitEvents.Unregister(UnitEvent.Damaging, appliesEffectOnDamage.OnDealsDamage, unit);
          break;

        case IEffectOnSummonedUnit effectOnSummonedUnit:
          PlayerUnitEvents.Unregister(UnitEvent.Summons, effectOnSummonedUnit.OnSummonedUnit, unit);
          break;
      }
    }, itemTypeId);
  }
}
