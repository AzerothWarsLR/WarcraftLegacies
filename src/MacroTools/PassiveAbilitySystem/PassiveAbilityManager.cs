using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Utils;
using WCSharp.Events;


namespace MacroTools.PassiveAbilitySystem
{
  /// <summary>
  /// Responsible for registering the events that allow <see cref="PassiveAbility"/> instances to work.
  /// </summary>
  public static class PassiveAbilityManager
  {
    private static readonly Dictionary<int, List<PassiveAbility>> PassiveAbilitiesByUnitTypeId = new();

    /// <summary>
    /// Iterates across all units on the map, and fires the <see cref="PassiveAbility.OnCreated"/>
    /// for any <see cref="PassiveAbility"/>s it finds. This should be run at game start to ensure that preplaced units
    /// are initialized correctly.
    /// </summary>
    public static void InitializePreplacedUnits()
    {
      var group = GroupUtils.GetAllUnits();
      foreach (var unit in group)
      {
        if (!PassiveAbilitiesByUnitTypeId.TryGetValue(GetUnitTypeId(unit), out var passiveAbilities)) continue;
        foreach (var passiveAbility in passiveAbilities)
          passiveAbility.OnCreated(unit);
      }
    }
    
    /// <summary>
    /// Registeres the provided passive ability to the <see cref="SpellSystem"/>, causing its functionality
    /// to be invoked when specific Warcraft 3 events occur.
    /// </summary>
    public static void Register(TakeDamagePassiveAbility takeDamagePassiveAbility)
    {
      PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, takeDamagePassiveAbility.OnTakesDamage,
        takeDamagePassiveAbility.DamagedUnitTypeId);
    }

    /// <summary>
    /// Registeres the provided passive ability to the <see cref="SpellSystem"/>, causing its functionality
    /// to be invoked when specific Warcraft 3 events occur.
    /// </summary>
    public static void Register(PassiveAbility passiveAbility)
    {
      try
      {
        RegisterEvents(passiveAbility);
        foreach (var unitTypeId in passiveAbility.UnitTypeIds)
        {
          if (!PassiveAbilitiesByUnitTypeId.ContainsKey(unitTypeId))
          {
            PassiveAbilitiesByUnitTypeId.Add(unitTypeId, new List<PassiveAbility>());
          }

          PassiveAbilitiesByUnitTypeId[unitTypeId].Add(passiveAbility);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to register {nameof(PassiveAbility)} for {GetObjectName(passiveAbility.UnitTypeIds.First())}: {ex}");
      }
    }

    private static void RegisterEvents(PassiveAbility passiveAbility)
    {
      foreach (var unitTypeId in passiveAbility.UnitTypeIds)
      {
        void UnitCreated() => passiveAbility.OnCreated(GetTriggerUnit());
        
        PlayerUnitEvents.Register(UnitTypeEvent.IsCreated, UnitCreated, unitTypeId);
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesBeingTrained, passiveAbility.OnTrained, unitTypeId);
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesTraining, passiveAbility.OnTrainedUnit, unitTypeId);
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesBeingConstructed, passiveAbility.OnConstruction, unitTypeId);
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesUpgrade, passiveAbility.OnUpgrade, unitTypeId);
        PlayerUnitEvents.Register(UnitTypeEvent.Dies, passiveAbility.OnDeath, unitTypeId);
        PlayerUnitEvents.Register(UnitTypeEvent.SpellEffect, passiveAbility.OnSpellEffect, unitTypeId);
        PlayerUnitEvents.Register(UnitTypeEvent.SpellFinish, passiveAbility.OnSpellFinish, unitTypeId);
        PlayerUnitEvents.Register(HeroTypeEvent.FinishesRevive, UnitCreated, unitTypeId);
        PlayerUnitEvents.Register(UnitTypeEvent.ReceivesPointOrder, passiveAbility.OnOrderIssued, unitTypeId);
        PlayerUnitEvents.Register(UnitTypeEvent.CancelsUpgrade, passiveAbility.OnCancelUpgrade, unitTypeId);

        switch (passiveAbility)
        {
          case IAppliesEffectOnDamage appliesEffectOnDamage:
            PlayerUnitEvents.Register(UnitTypeEvent.Damaging, appliesEffectOnDamage.OnDealsDamage, unitTypeId);
            break;
          case IEffectOnTakesDamage effectOnTakesDamage:
            PlayerUnitEvents.Register(UnitTypeEvent.IsDamaged, effectOnTakesDamage.OnTakesDamage, unitTypeId);
            break;
          case IEffectOnSummonedUnit effectOnSummonedUnit:
            PlayerUnitEvents.Register(UnitTypeEvent.Summons, effectOnSummonedUnit.OnSummonedUnit, unitTypeId);
            break;
        }
      }
    }
  }
}