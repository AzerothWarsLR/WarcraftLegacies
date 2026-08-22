using System;

namespace WarcraftLegacies.Source.Shared.UnitTraits.BonusDamageAttack;

public sealed class DamageCondition
{
  /// <summary>
  /// Determines whether this rule applies to the target.
  /// </summary>
  public required Func<unit, bool> Condition { get; init; }

  /// <summary>
  /// Amount of bonus damage to deal when this rule applies.
  /// </summary>
  public required float Damage { get; init; }

  /// <summary>
  /// Option effect to play when this rule applies.
  /// </summary>
  public string? Effect { get; init; }
}
