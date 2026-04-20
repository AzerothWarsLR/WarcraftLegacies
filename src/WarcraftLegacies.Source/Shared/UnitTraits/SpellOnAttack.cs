using System;
using MacroTools.DummyCasters;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Shared.Buffs;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Shared.UnitTraits;

/// <summary>
/// When the unit deals damage, it has a chance to cast a dummy spell against that target.
/// </summary>
public sealed class SpellOnAttack : UnitTrait, IAppliesEffectOnDamage
{
  private readonly int _abilityTypeId;

  /// <summary>
  /// The dummy spell to cast on attack.
  /// </summary>
  public int DummyAbilityId { get; init; }

  /// <summary>
  /// An order ID that can be used to cast the specified dummy ability.
  /// </summary>
  public int DummyOrderId { get; init; }

  /// <summary>
  /// The percentage chance that the effect will occur on attack.
  /// </summary>
  public float ProcChance { get; init; }

  /// <summary>
  /// The percentage chance that the effect will occur on attack.
  /// </summary>
  public float ProcChancePerLevel { get; init; }

  /// <summary>
  /// The cooldown in seconds for the effect.
  /// </summary>
  public float Cooldown { get; init; }

  /// <summary>
  /// The player must have this research for the ability to take effect.
  /// </summary>
  public int RequiredResearch { get; init; }

  /// <summary>
  /// The current level of this <see cref="Spell"/> instance for any specified unit.
  /// </summary>
  protected int GetAbilityLevel(unit whichUnit) => whichUnit.GetAbilityLevel(_abilityTypeId);

  /// <summary>
  /// Initializes a new instance of the <see cref="SpellOnAttack"/> class.
  /// </summary>
  /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
  public SpellOnAttack(int abilityTypeId)
  {
    _abilityTypeId = abilityTypeId;
  }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    if (!@event.IsAttack)
    {
      return;
    }

    var caster = @event.DamageSource;
    var target = @event.Unit;

    if (RequiredResearch != 0 &&
        caster.Owner.GetTechResearched(RequiredResearch, false) == 0)
    {
      return;
    }

    if (Cooldown > 0)
    {
      var buffsOnTarget = BuffSystem.GetBuffsOnUnit(target);
      foreach (var buff in buffsOnTarget)
      {
        if (buff is UnitTypeTraitOnCooldownBuff cooldownBuff && cooldownBuff.Trait == this)
        {
          return;
        }
      }
    }

    var procChance = ProcChance;

    if (ProcChancePerLevel > 0)
    {
      procChance = ProcChance + (GetAbilityLevel(caster) * ProcChancePerLevel);
    }

    if (GetRandomReal(0, 1) >= procChance)
    {
      return;
    }

    DoSpellOnTarget(caster, target);

    if (Cooldown > 0)
    {
      BuffSystem.Add(new UnitTypeTraitOnCooldownBuff(caster, target)
      {
        Trait = this,
        Duration = Cooldown
      });
    }
  }

  private void DoSpellOnTarget(unit caster, unit target) =>
    DummyCasterManager.GetGlobalDummyCaster().CastUnit(
      caster, DummyAbilityId, DummyOrderId,
      caster.GetAbilityLevel(_abilityTypeId),
      target, DummyCastOriginType.Caster);
}
