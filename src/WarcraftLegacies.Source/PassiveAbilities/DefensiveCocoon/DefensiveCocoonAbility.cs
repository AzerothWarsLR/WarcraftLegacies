using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;


namespace WarcraftLegacies.Source.PassiveAbilities.DefensiveCocoon
{
  /// <summary>
  /// When the ability holder takes lethal damage, they transform into a Spirit of Vengeance.
  /// If they attack enough times while a Spirit, they revive with some health.
  /// Otherwise, they die.
  /// </summary>
  public sealed class DefensiveCocoonAbility : TakeDamagePassiveAbility
  {
    public required int RequiredResearch { get; init; }
    public required float MaximumHealthPercentage { private get; init; }
    public required float Duration { private get; init; }
    public required int EggId { private get; init; }
    public required string ReviveEffect { private get; init; }

    public DefensiveCocoonAbility(IEnumerable<int> damagedUnitTypeIds, int abilityTypeId) 
        : base(damagedUnitTypeIds, abilityTypeId)
    {
    }
    
    public override void OnTakesDamage()
    {
      var damaged = GetTriggerUnit();
      var abilityLevel = GetUnitAbilityLevel(damaged, AbilityTypeId);
      if (!ShouldBecomeEgg(abilityLevel, damaged)) 
        return;
      
      BlzSetEventDamage(0);
      var heroLevel = IsUnitType(damaged, UNIT_TYPE_HERO) ? GetHeroLevel(damaged) : 0;
      
      var cocoonBuff = new DefensiveCocoonBuff(damaged, damaged)
      {
        Duration = Duration,
        EggId = EggId,
        ReviveEffect = ReviveEffect,
        MaximumHitPoints = (int)(damaged.GetMaximumHitPoints() * MaximumHealthPercentage),
        OriginalHeroLevel = heroLevel,
        IsOriginalUnitHero = IsUnitType(damaged, UNIT_TYPE_HERO)
      };
      BuffSystem.Add(cocoonBuff);
    }

    private bool ShouldBecomeEgg(int abilityLevel, unit target) =>
      GetPlayerTechCount(target.OwningPlayer(), RequiredResearch, false) > 0 && 
      abilityLevel != 0 &&
      BlzGetUnitSkin(target) != EggId && 
      GetEventDamage() >= GetUnitState(target, UNIT_STATE_LIFE) &&
      !IsUnitIllusion(target);
  }
}