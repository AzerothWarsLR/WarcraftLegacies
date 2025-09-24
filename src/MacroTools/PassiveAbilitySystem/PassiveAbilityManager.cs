using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Utils;
using WCSharp.Events;

namespace MacroTools.PassiveAbilitySystem;

/// <summary>
/// Responsible for registering the events that allow <see cref="PassiveAbility"/> instances to work.
/// </summary>
public static class PassiveAbilityManager
{
  private static readonly Dictionary<int, List<PassiveAbility>> _passiveAbilitiesByUnitTypeId = new();

  /// <summary>
  /// Iterates across all units on the map, and fires the <see cref="IEffectOnCreated.OnCreated"/>
  /// for any <see cref="PassiveAbility"/>s it finds. This should be run at game start to ensure that preplaced units
  /// are initialized correctly.
  /// </summary>
  public static void InitializePreplacedUnits()
  {
    var group = GlobalGroup
      .EnumUnitsInRect(WCSharp.Shared.Data.Rectangle.WorldBounds);

    foreach (var unit in group)
    {
      ForceOnCreated(unit);
    }
  }

  /// <summary>
  /// Finds any <see cref="PassiveAbility"/>s on the specified unit and forcibly fires <see cref="IEffectOnCreated.OnCreated"/>
  /// for each of them. Usually <see cref="InitializePreplacedUnits"/> should have covered this already.
  /// </summary>
  public static void ForceOnCreated(unit whichUnit)
  {
    if (!_passiveAbilitiesByUnitTypeId.TryGetValue(whichUnit.UnitType, out var passiveAbilities))
    {
      return;
    }

    foreach (var passiveAbility in passiveAbilities)
    {
      if (passiveAbility is IEffectOnCreated effectOnCreated)
      {
        effectOnCreated.OnCreated(whichUnit);
      }
    }
  }

  /// <summary>
  /// Registeres the provided passive ability to the <see cref="SpellSystem"/>, causing its functionality
  /// to be invoked when specific Warcraft 3 events occur.
  /// </summary>
  public static void Register(TakeDamagePassiveAbility takeDamagePassiveAbility)
  {
    foreach (var unit in takeDamagePassiveAbility.DamagedUnitTypeIds)
    {
      PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, takeDamagePassiveAbility.OnTakesDamage, unit);
    }
  }

  /// <summary>
  /// Registers the provided passive ability, causing its functionality to be invoked when specific Warcraft 3 events occur.
  /// </summary>
  public static void Register(PassiveAbility passiveAbility)
  {
    try
    {
      RegisterEvents(passiveAbility);
      foreach (var unitTypeId in passiveAbility.UnitTypeIds)
      {
        if (!_passiveAbilitiesByUnitTypeId.TryGetValue(unitTypeId, out var passiveAbilities))
        {
          passiveAbilities = _passiveAbilitiesByUnitTypeId[unitTypeId] = new List<PassiveAbility>();
        }

        passiveAbilities.Add(passiveAbility);

        passiveAbility.OnRegistered();
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(
        $"Failed to register {nameof(PassiveAbility)} for {GetObjectName(passiveAbility.UnitTypeIds.First())}: {ex}");
    }
  }

  private static void RegisterEvents(PassiveAbility passiveAbility)
  {
    foreach (var unitTypeId in passiveAbility.UnitTypeIds)
    {
      switch (passiveAbility)
      {
        case IEffectOnCreated effectOnCreated:
          void UnitCreated() => effectOnCreated.OnCreated(@event.Unit);
          PlayerUnitEvents.Register(UnitTypeEvent.IsCreated, UnitCreated, unitTypeId);
          PlayerUnitEvents.Register(HeroTypeEvent.FinishesRevive, UnitCreated, unitTypeId);
          break;

        case IEffectOnTrained effectOnTrained:
          PlayerUnitEvents.Register(UnitTypeEvent.FinishesBeingTrained, effectOnTrained.OnTrained, unitTypeId);
          break;

        case IEffectOnConstruction effectOnConstruction:
          PlayerUnitEvents.Register(UnitTypeEvent.FinishesBeingConstructed, effectOnConstruction.OnConstruction,
            unitTypeId);
          break;

        case IEffectOnUpgrade effectOnUpgrade:
          PlayerUnitEvents.Register(UnitTypeEvent.FinishesUpgrade, effectOnUpgrade.OnUpgrade, unitTypeId);
          break;

        case IEffectOnDeath effectOnDeath:
          PlayerUnitEvents.Register(UnitTypeEvent.Dies, effectOnDeath.OnDeath, unitTypeId);
          break;

        case IEffectOnSpellEffect effectOnSpellEffect:
          PlayerUnitEvents.Register(UnitTypeEvent.SpellEffect, effectOnSpellEffect.OnSpellEffect, unitTypeId);
          break;

        case IEffectOnSpellFinish effectOnSpellFinish:
          PlayerUnitEvents.Register(UnitTypeEvent.SpellFinish, effectOnSpellFinish.OnSpellFinish, unitTypeId);
          break;

        case IEffectOnCancelUpgrade effectOnCancelUpgrade:
          PlayerUnitEvents.Register(UnitTypeEvent.CancelsUpgrade, effectOnCancelUpgrade.OnCancelUpgrade, unitTypeId);
          break;

        case IAppliesEffectOnDamage appliesEffectOnDamage:
          PlayerUnitEvents.Register(UnitTypeEvent.Damaging, appliesEffectOnDamage.OnDealsDamage, unitTypeId);
          break;

        case IEffectOnSummonedUnit effectOnSummonedUnit:
          PlayerUnitEvents.Register(UnitTypeEvent.Summons, effectOnSummonedUnit.OnSummonedUnit, unitTypeId);
          break;
      }
    }
  }
}
