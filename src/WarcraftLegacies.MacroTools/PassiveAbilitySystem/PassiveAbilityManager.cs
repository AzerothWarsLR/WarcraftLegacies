using System;
using System.Collections.Generic;
using WarcraftLegacies.MacroTools.Wrappers;
using WCSharp.Events;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.PassiveAbilitySystem
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
      using var group = new GroupWrapper().EnumUnitsInRect(WCSharp.Shared.Data.Rectangle.WorldBounds);
      foreach (var unit in group.EmptyToList())
      {
        if (PassiveAbilitiesByUnitTypeId.TryGetValue(GetUnitTypeId(unit), out var passiveAbilities))
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
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDamages, takeDamagePassiveAbility.OnTakesDamage,
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
        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDamages, passiveAbility.OnDealsDamage, passiveAbility.UnitTypeId);
        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeIsCreated, UnitCreated, passiveAbility.UnitTypeId);
        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesBeingTrained, passiveAbility.OnTrained, passiveAbility.UnitTypeId);
        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesTraining, passiveAbility.OnTrainedUnit, passiveAbility.UnitTypeId);
        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesBeingConstructed, passiveAbility.OnConstruction,
          passiveAbility.UnitTypeId);
        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesUpgrade, passiveAbility.OnUpgrade, passiveAbility.UnitTypeId);
        PlayerUnitEvents.Register(PlayerUnitEvent.HeroTypeFinishesRevive, UnitCreated, passiveAbility.UnitTypeId);

        if (!PassiveAbilitiesByUnitTypeId.ContainsKey(passiveAbility.UnitTypeId))
        {
          PassiveAbilitiesByUnitTypeId.Add(passiveAbility.UnitTypeId, new List<PassiveAbility>());
        }

        PassiveAbilitiesByUnitTypeId[passiveAbility.UnitTypeId].Add(passiveAbility);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to register {nameof(PassiveAbility)} for {GetObjectName(passiveAbility.UnitTypeId)}: {ex}");
      }
    }

    private static void UnitCreated()
    {
      var triggerUnit = GetTriggerUnit();
      foreach (var passiveAbility in PassiveAbilitiesByUnitTypeId[GetUnitTypeId(triggerUnit)])
        passiveAbility.OnCreated(triggerUnit);
    }
  }
}