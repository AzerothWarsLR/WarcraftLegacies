using MacroTools.Extensions;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using System.Linq;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// Target a friendly unit with a nova, healing allies and damage enemies.
  /// </summary>
  public sealed class Sunfire : Spell
  {
    public Sunfire(int id) : base(id)
    {
    }

    /// <summary>The radius of the nova around the target. </summary>
    public float Radius { get; init; }

    /// <summary>
    /// Visual effect played when the spell is cast.
    /// </summary>
    public string CasterEffect { get; init; } = string.Empty;

    /// <summary>
    /// Visual effect played when the spell is cast.
    /// </summary>
    public string TargetEffect { get; init; } = string.Empty;

    public float BaseDamage { get; init; }

    public float DamagePerLevel { get; init; }

    public float BaseHeal { get; init; }

    public float HealPerLevel { get; init; }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var abilityLevel = GetAbilityLevel(caster);
      var targetPosition = target.GetPosition();
      var casterPlayer = caster.OwningPlayer();
      var damageAmount = BaseDamage + (abilityLevel * DamagePerLevel);
      var healAmount = BaseHeal + (abilityLevel * HealPerLevel);
      var unitsInRange = GlobalGroup
                .EnumUnitsInRange(targetPosition, Radius)
                .Where(x => x != null && UnitAlive(x))
                .ToList();

      foreach (var unit in unitsInRange)
      {
        if (IsValidEnemy(unit, caster))
        {
          unit.TakeDamage(caster, damageAmount, false, false, damageType: DAMAGE_TYPE_NORMAL);
        }

        if (IsValidAlly(unit, caster))
        {
          unit.Heal(healAmount);
        }
      }

      AddSpecialEffect(CasterEffect, GetUnitX(caster), GetUnitY(caster)).SetLifespan();
      AddSpecialEffect(TargetEffect, GetUnitX(target), GetUnitY(target)).SetLifespan(0.5f).SetScale(2);
    }

    private static bool IsValidEnemy(unit target, unit caster) =>
      UnitAlive(target) &&
      !IsUnitType(target, UNIT_TYPE_STRUCTURE) &&
      !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
      !IsUnitType(target, UNIT_TYPE_MECHANICAL) &&
      !IsPlayerAlly(caster.OwningPlayer(), target.OwningPlayer());

    private static bool IsValidAlly(unit target, unit caster) =>
      UnitAlive(target) &&
      !IsUnitType(target, UNIT_TYPE_STRUCTURE) &&
      !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
      !IsUnitType(target, UNIT_TYPE_MECHANICAL) &&
      IsPlayerAlly(caster.OwningPlayer(), target.OwningPlayer());
  }
}