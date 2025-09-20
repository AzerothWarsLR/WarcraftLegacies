using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.PassiveAbilitySystem;

namespace MacroTools.PassiveAbilities;

/// <summary>
/// When the unit deals casts a spell, it has a chance to cast a dummy spell without a target.
/// </summary>
public sealed class NoTargetSpellOnCast : PassiveAbility, IEffectOnSpellEffect
{
  /// <summary>
  /// The unit type ID which has this <see cref="PassiveAbility"/> should also have an ability with this ID.
  /// </summary>
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
  /// <param name="unitTypeId"><inheritdoc /></param>
  /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
  public NoTargetSpellOnCast(int unitTypeId, int abilityTypeId) : base(unitTypeId)
  {
    _abilityTypeId = abilityTypeId;
  }

  public List<int> AbilityWhitelist { get; init; } = new();

  /// <inheritdoc />
  public void OnSpellEffect()
  {
    var caster = GetTriggerUnit();
    var abilityLevel = GetUnitAbilityLevel(caster, _abilityTypeId);
    if (abilityLevel == 0 || !AbilityWhitelist.Contains(GetSpellAbilityId()))
    {
      return;
    }

    if (GetRandomReal(0, 1) < ProcChance)
    {
      DoSpellNoTarget(caster);
    }
  }

  private void DoSpellNoTarget(unit caster) => DummyCasterManager.GetGlobalDummyCaster().CastNoTarget(caster, DummyAbilityId,
    DummyOrderId, GetUnitAbilityLevel(caster, _abilityTypeId));
}
