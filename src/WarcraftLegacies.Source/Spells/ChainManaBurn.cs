using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Events;
using WCSharp.Lightnings;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Burns mana from the target unit, then bounces to other units, with a reduced effect on each bounce.
/// </summary>
public sealed class ChainManaBurn : Spell
{
  /// <inheritdoc />
  public ChainManaBurn(int id) : base(id)
  {
  }

  /// <summary>
  /// The amount of mana burned from the first unit targeted.
  /// </summary>
  public required LeveledAbilityField<int> ManaBurned { get; init; }

  /// <summary>
  /// The number of times the chain bounces, non-inclusive of the first target.
  /// </summary>
  public required int MaximumBounces { get; init; }

  /// <summary>
  /// The percentage of mana burn lost per bounce.
  /// </summary>
  public required float BurnReductionPerBounce { get; init; }

  /// <summary>
  /// The maximum radius around struck targets that bounces can occur from.
  /// </summary>
  public required float MaximumBounceRadius { get; init; }

  /// <summary>
  /// The maximum radius around the initial target in which bounces can occur.
  /// </summary>
  public float MaximumTotalRadius { get; init; } = 1000f;

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var possibleTargets = GlobalGroup
      .EnumUnitsInRange(target.X, target.Y, MaximumTotalRadius)
      .Where(x => IsValidTarget(caster, x))
      .ToList();
    var manaBurned = ManaBurned.Base + ManaBurned.PerLevel * GetAbilityLevel(caster);
    DoBounce(caster, caster, target, manaBurned, MaximumBounces, possibleTargets);
  }

  private void DoBounce(unit caster, unit origin, unit target, float amount, int bouncesRemaining,
    List<unit> possibleTargets)
  {
    possibleTargets.Remove(target);
    LightningSystem.Add(new Lightning("MBUR", origin, target)
    {
      Duration = 0.75f
    });

    BurnMana(caster, target, amount);

    if (bouncesRemaining == 0 || possibleTargets.Count == 0)
    {
      return;
    }

    var nextTarget = possibleTargets
      .Where(x => x.Mana > 0)
      .Select(x => new { Target = x, Distance = WCSharp.Shared.Util.DistanceBetweenPoints(target, x) })
      .Where(t => t.Distance < MaximumBounceRadius)
      .MinBy(t => t.Distance)
      ?.Target;

    if (nextTarget != null)
    {
      PeriodicEvents.AddPeriodicEvent(() =>
      {
        DoBounce(caster, target, nextTarget, amount * (1 - BurnReductionPerBounce), bouncesRemaining - 1, possibleTargets);
        return false;
      }, 0.12f);
    }
  }

  private static void BurnMana(unit caster, unit target, float amount)
  {
    amount = Math.Min(amount, target.Mana);
    target.Mana -= amount;
    target.Damage(caster, amount, ATTACK_TYPE_NORMAL);
  }

  private static bool IsValidTarget(unit caster, unit target)
  {
    return caster != target &&
           (target.IsEnemyTo(caster.Owner) || target.Owner == player.NeutralPassive) &&
           target.Alive &&
           !target.IsInvulnerable &&
           !target.IsUnitType(UNIT_TYPE_MECHANICAL) &&
           !target.IsABuilding;
  }
}
