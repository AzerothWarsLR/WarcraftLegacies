using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// When the unit casts a spell, it has a chance to cast a dummy spell.
/// </summary>
public sealed class SpellOnCast : UnitTrait, IEffectOnSpellEffect
{
  private readonly int _abilityTypeId;

  /// <summary>
  /// The dummy spell to cast on attack.
  /// </summary>
  public required int DummyAbilityId { get; init; }

  /// <summary>
  /// An order ID that can be used to cast the specified dummy ability.
  /// </summary>
  public required int DummyOrderId { get; init; }

  public required SpellTargetType TargetType { get; init; }

  /// <summary>
  /// Initializes a new instance of the <see cref="NoTargetSpellOnAttack"/> class.
  /// </summary>
  /// <param name="abilityTypeId">The ability the provided unit type has which represents this object.</param>
  public SpellOnCast(int abilityTypeId) => _abilityTypeId = abilityTypeId;

  public required List<int> AbilityWhitelist { get; init; }

  /// <inheritdoc />
  public void OnSpellEffect()
  {
    var caster = @event.Unit;
    var abilityLevel = caster.GetAbilityLevel(_abilityTypeId);
    if (abilityLevel == 0 || !AbilityWhitelist.Contains(@event.SpellAbilityId))
    {
      return;
    }

    switch (TargetType)
    {
      case SpellTargetType.None:
        DummyCasterManager.GetGlobalDummyCaster().CastNoTarget(caster, DummyAbilityId,
          DummyOrderId, caster.GetAbilityLevel(_abilityTypeId));
        break;
      case SpellTargetType.Unit:
        DummyCasterManager.GetGlobalDummyCaster().CastUnit(caster, DummyAbilityId,
          DummyOrderId, caster.GetAbilityLevel(_abilityTypeId), GetSpellTargetUnit(), DummyCastOriginType.Caster);
        break;
      case SpellTargetType.Point:
        DummyCasterManager.GetGlobalDummyCaster().CastPoint(caster.Owner, DummyAbilityId,
          DummyOrderId, caster.GetAbilityLevel(_abilityTypeId), new Point(GetSpellTargetX(), GetSpellTargetY()));
        break;
    }
  }
}
