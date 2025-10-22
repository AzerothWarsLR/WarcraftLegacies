using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Instances;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using WarcraftLegacies.Source.Buffs;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>Summons a limited number of units from an area to the caster's position.</summary>
public sealed class DelayedMultiTargetRecall : Spell
{
  public float Radius { get; init; }

  /// <summary>How many units get summoned by the spell.</summary>
  public int AmountToTarget { get; init; }

  /// <summary>The minimum number of seconds the spell will take to finish.</summary>
  public int MinDuration { get; init; }

  /// <summary>The maximum number of seconds the spell will take to finish.</summary>
  public int MaxDuration { get; init; }

  /// <summary>
  /// How long it takes to travel between two <see cref="Instance"/>s with no <see cref="Gate"/>s connecting them.
  /// </summary>
  public int CrossDimensionalDuration { get; init; }

  /// <summary>The value used to divide the distance to calculate the time. smaller value means spell will take longer and larger value means spell will be quicker</summary>
  public int DistanceDivider { get; init; }

  /// <summary>The percentage of units to lose when the caster dies (rounded down)</summary>
  public float DeathPenalty { get; init; }

  public SpellTargetType TargetType { get; init; } = SpellTargetType.None;

  public DelayedMultiTargetRecall(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var casterPosition = caster.GetPosition();
    var center = TargetType == SpellTargetType.None ? casterPosition : targetPoint;

    var distance = InstanceSystem.GetDistanceBetweenPointsEx(casterPosition, center);
    var distanceDuration = (int)distance / DistanceDivider;
    var finalDuration = distance == -1
      ? CrossDimensionalDuration
      : Math.Clamp(distanceDuration, MinDuration, MaxDuration);

    var targets = GlobalGroup
      .EnumUnitsInRange(center, Radius)
      .Where(x => IsValidTarget(caster, x))
      .Take(AmountToTarget)
      .ToList();

    if (targets.Count == 0)
    {
      return;
    }

    var delayedRecallBuff = new DelayedRecallBuff(caster, caster, targets)
    {
      Duration = finalDuration,
      DeathPenalty = DeathPenalty
    };

    BuffSystem.Add(delayedRecallBuff);
  }

  private static bool IsValidTarget(unit caster, unit target)
  {
    return caster.Owner == target.Owner &&
           target.Alive &&
           target.IsInvulnerable == false &&
           !target.IsResistant() &&
           !target.IsUnitType(unittype.Structure) &&
           !target.IsUnitType(unittype.Ancient) &&
           caster != target &&
           !target.IsUnitBoat();
  }
}
