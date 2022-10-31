using AzerothWarsCSharp.MacroTools.Buffs;
using AzerothWarsCSharp.MacroTools.PassiveAbilitySystem;
using WCSharp.Buffs;

using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  /// <summary>
  /// When the ability holder takes lethal damage, they transform into a Spirit of Vengeance.
  /// If they attack enough times while a Spirit, they revive with some health.
  /// Otherwise, they die.
  /// </summary>
  public sealed class Vengeance : TakeDamagePassiveAbility
  {
    public int BonusDamageBase { private get; init; }
    public int BonusDamageLevel { private get; init; }
    public float HealBase { private get; init; }
    public float HealLevel { private get; init; }
    public float Duration { private get; init; }
    public int AlternateFormId { private get; init; }
    public int HitsReviveThreshold { private get; init; }
    public string? ReviveEffect { private get; init; }

    public override void OnTakesDamage()
    {
      var damager = GetEventDamageSource();
      var damaged = GetTriggerUnit();
      var abilityLevel = GetUnitAbilityLevel(damaged, AbilityTypeId);
      if (BlzGetUnitSkin(damaged) != AlternateFormId && GetEventDamage() >= GetUnitState(damaged, UNIT_STATE_LIFE) &&
          GetUnitState(damaged, UNIT_STATE_MANA) >=
          BlzGetUnitAbilityManaCost(damaged, AbilityTypeId, abilityLevel))
      {
        BlzSetEventDamage(0);
        var vengeanceBuff = new VengeanceBuff(damaged, damaged)
        {
          BonusDamage = BonusDamageBase + BonusDamageLevel * abilityLevel,
          Heal = HealBase + HealLevel * abilityLevel,
          Duration = Duration,
          AlternateFormId = AlternateFormId,
          HitsReviveThreshold = HitsReviveThreshold,
          ReviveEffect = ReviveEffect
        };
        BuffSystem.Add(vengeanceBuff);
      }
    }

    public Vengeance(int damagedUnitTypeId, int abilityTypeId) : base(damagedUnitTypeId, abilityTypeId)
    {
    }
  }
}