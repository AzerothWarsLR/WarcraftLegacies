using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// When the unit deals damage, it has a chance to cast a dummy spell without a target.
/// </summary>
public sealed class ChannelSpellOnAttack : UnitTrait, IAppliesEffectOnDamage
{
  /// <summary>
  /// The unit type ID which has this <see cref="UnitTrait"/> should also have an ability with this ID.
  /// </summary>
  public int AbilityTypeId { get; }

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
  /// The base duration of the channel
  /// </summary>
  public int DurationBase { get; init; }

  /// <summary>
  /// The duration gained per level of the channel
  /// </summary>
  public int DurationLevel { get; init; }

  /// <summary>
  /// The current level of this <see cref="Spell"/> instance for any specified unit.
  /// </summary>
  protected int GetAbilityLevel(unit whichUnit) => whichUnit.GetAbilityLevel(AbilityTypeId);

  /// <summary>
  /// Initializes a new instance of the <see cref="NoTargetSpellOnAttack"/> class.
  /// </summary>
  /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
  public ChannelSpellOnAttack(int abilityTypeId)
  {
    AbilityTypeId = abilityTypeId;
  }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var caster = @event.DamageSource;
    if (!@event.IsAttack || caster.GetAbilityLevel(AbilityTypeId) == 0)
    {
      return;
    }

    if (GetRandomReal(0, 1) < ProcChance)
    {
      ChannelNoTarget(caster);
    }
  }

  private void ChannelNoTarget(unit caster) => DummyCasterManager.GetLongLivedDummyCaster().ChannelAtCaster(caster, DummyAbilityId,
    DummyOrderId, caster.GetAbilityLevel(AbilityTypeId), DurationBase + DurationLevel * GetAbilityLevel(caster));
}
