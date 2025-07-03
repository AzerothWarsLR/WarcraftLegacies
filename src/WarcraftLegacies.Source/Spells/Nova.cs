using MacroTools.DummyCasters;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using System.Linq;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// Target a unit with a nova, potentially healing allies and/or damage enemies and causing a stun.
  /// </summary>
  public sealed class Nova : Spell
  {
    public Nova(int id) : base(id)
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

    /// <summary>
    /// The ID of an ability that stuns units. Should be based on Storm Bolt.
    /// </summary>
    public int StunAbilityId { get; init; }

    /// <summary>
    /// The order ID for <see cref="StunAbilityId"/>.
    /// </summary>
    public int StunOrderId { get; init; }

    /// <summary>
    /// How long the stun should last.
    /// </summary>
    public int DurationBase { get; init; }

    /// <summary>
    /// How much extra duration the stun should get per level.
    /// </summary>
    public int DurationLevel { get; init; }

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
          StunUnit(caster, unit);
        }

        if (IsValidAlly(unit, caster))
        {
          unit.Heal(healAmount);
        }
      }

      AddSpecialEffect(CasterEffect, GetUnitX(caster), GetUnitY(caster)).SetLifespan();
      AddSpecialEffect(TargetEffect, GetUnitX(target), GetUnitY(target)).SetLifespan(0.5f).SetScale(2);
    }

    private void StunUnit(unit caster, unit target)
    {
      var duration = DurationBase + DurationLevel * GetAbilityLevel(caster);
      if (StunAbilityId == 0 || duration <= 0)
        return;
      DummyCasterManager.GetGlobalDummyCaster().CastUnit(caster, StunAbilityId, StunOrderId, duration, target, DummyCastOriginType.Target);
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