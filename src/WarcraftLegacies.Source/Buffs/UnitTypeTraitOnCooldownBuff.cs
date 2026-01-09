using MacroTools.UnitTraits;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Buffs;

/// <summary>
/// Marker buff to indicate that any instance of a <see cref="UnitTrait"/>
/// can't be applied to this unit for the duration.
/// </summary>
public sealed class UnitTypeTraitOnCooldownBuff : PassiveBuff
{
  /// <summary>
  /// The trait on cooldown.
  /// </summary>
  public required UnitTrait Trait { get; init; }

  /// <inheritdoc />
  public UnitTypeTraitOnCooldownBuff(unit caster, unit target) : base(caster, target)
  {
  }
}
