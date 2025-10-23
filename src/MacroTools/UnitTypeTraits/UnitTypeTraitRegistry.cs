using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Utils;
using WCSharp.Events;

namespace MacroTools.UnitTypeTraits;

/// <summary>
/// Responsible for registering the events that allow <see cref="UnitTypeTrait"/> instances to work.
/// </summary>
public static class UnitTypeTraitRegistry
{
  private static readonly Dictionary<int, List<UnitTypeTrait>> _unitTypeTraitsByUnitTypeId = new();

  /// <summary>
  /// Iterates across all units on the map, and fires the <see cref="IEffectOnCreated.OnCreated"/>
  /// for any <see cref="UnitTypeTrait"/>s it finds. This should be run at game start to ensure that preplaced units
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
  /// Finds any <see cref="UnitTypeTrait"/>s on the specified unit and forcibly fires <see cref="IEffectOnCreated.OnCreated"/>
  /// for each of them. Usually <see cref="InitializePreplacedUnits"/> should have covered this already.
  /// </summary>
  public static void ForceOnCreated(unit whichUnit)
  {
    if (!_unitTypeTraitsByUnitTypeId.TryGetValue(whichUnit.UnitType, out var unitTypeTraits))
    {
      return;
    }

    foreach (var unitTypeTrait in unitTypeTraits)
    {
      if (unitTypeTrait is IEffectOnCreated effectOnCreated)
      {
        effectOnCreated.OnCreated(whichUnit);
      }
    }
  }

  /// <summary>
  /// Registers the provided <see cref="UnitTypeTrait"/>, causing its functionality to be invoked when specific Warcraft 3 events occur.
  /// </summary>
  public static void Register(UnitTypeTrait unitTypeTrait)
  {
    try
    {
      RegisterEvents(unitTypeTrait);
      foreach (var unitTypeId in unitTypeTrait.UnitTypeIds)
      {
        if (!_unitTypeTraitsByUnitTypeId.TryGetValue(unitTypeId, out var unitTypeTraits))
        {
          unitTypeTraits = _unitTypeTraitsByUnitTypeId[unitTypeId] = new List<UnitTypeTrait>();
        }

        unitTypeTraits.Add(unitTypeTrait);

        unitTypeTrait.OnRegistered();
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(
        $"Failed to register {nameof(UnitTypeTrait)} for {GetObjectName(unitTypeTrait.UnitTypeIds.First())}: {ex}");
    }
  }

  private static void RegisterEvents(UnitTypeTrait unitTypeTrait)
  {
    foreach (var unitTypeId in unitTypeTrait.UnitTypeIds)
    {
      switch (unitTypeTrait)
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

        case IEffectOnDamaged effectOnDamaged:
          PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, effectOnDamaged.OnDamaged, unitTypeId);
          break;

        case IEffectOnDeath effectOnDeath:
          PlayerUnitEvents.Register(UnitTypeEvent.Dies, effectOnDeath.OnDeath, unitTypeId);
          break;

        case IEffectOnSpellCast effectOnSpellCast:
          PlayerUnitEvents.Register(UnitTypeEvent.SpellCast, effectOnSpellCast.OnSpellCast, unitTypeId);
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
