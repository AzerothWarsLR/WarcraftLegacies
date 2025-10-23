using MacroTools.DummyCasters;
using MacroTools.UnitTypeTraits;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// When the unit deals damage, it has a chance to cast a dummy spell without a target.
/// </summary>
public sealed class NoTargetSpellOnAttack : UnitTypeTrait, IAppliesEffectOnDamage
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
  /// Initializes a new instance of the <see cref="NoTargetSpellOnAttack"/> class.
  /// </summary>
  /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
  public NoTargetSpellOnAttack(int abilityTypeId) => _abilityTypeId = abilityTypeId;

  /// <summary>
  /// The player must have this research for the ability to take effect.
  /// </summary>
  public int RequiredResearch { get; init; }

  /// <inheritdoc />

  public void OnDealsDamage()
  {
    var caster = @event.DamageSource;
    if (!@event.IsAttack || caster.GetAbilityLevel(_abilityTypeId) == 0)
    {
      return;
    }

    if (RequiredResearch != 0)
    {
      if (caster.Owner.GetTechResearched(RequiredResearch, false) == 0)
      {
        return;
      }
    }

    if (GetRandomReal(0, 1) < ProcChance)
    {
      DoSpellNoTarget(caster);
    }
  }
  private void DoSpellNoTarget(unit caster) => DummyCasterManager.GetGlobalDummyCaster().CastNoTarget(caster, DummyAbilityId,
    DummyOrderId, caster.GetAbilityLevel(_abilityTypeId));
}
