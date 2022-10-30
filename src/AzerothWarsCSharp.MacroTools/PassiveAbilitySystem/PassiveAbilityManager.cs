using WCSharp.Events;

namespace AzerothWarsCSharp.MacroTools.PassiveAbilitySystem
{
  /// <summary>
  /// Responsible for registering the events that allow <see cref="PassiveAbility"/> instances to work.
  /// </summary>
  public static class PassiveAbilityManager
  {
    /// <summary>
    /// Registeres the provided passive ability to the <see cref="SpellSystem"/>, causing its functionality
    /// to be invoked when specific Warcraft 3 events occur.
    /// </summary>
    public static void Register(TakeDamagePassiveAbility takeDamagePassiveAbility) => 
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDamages, takeDamagePassiveAbility.OnTakesDamage,
        takeDamagePassiveAbility.DamagedUnitTypeId);

    /// <summary>
    /// Registeres the provided passive ability to the <see cref="SpellSystem"/>, causing its functionality
    /// to be invoked when specific Warcraft 3 events occur.
    /// </summary>
    public static void Register(PassiveAbility passiveAbility)
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeDamages, passiveAbility.OnDealsDamage, passiveAbility.UnitTypeId);
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeIsCreated, passiveAbility.OnCreated, passiveAbility.UnitTypeId);
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesBeingTrained, passiveAbility.OnTrained, passiveAbility.UnitTypeId);
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesTraining, passiveAbility.OnTrainedUnit, passiveAbility.UnitTypeId);
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesBeingConstructed, passiveAbility.OnConstruction,
        passiveAbility.UnitTypeId);
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeFinishesUpgrade, passiveAbility.OnUpgrade, passiveAbility.UnitTypeId);
      PlayerUnitEvents.Register(PlayerUnitEvent.HeroTypeFinishesRevive, passiveAbility.OnCreated, passiveAbility.UnitTypeId);
    }
  }
}