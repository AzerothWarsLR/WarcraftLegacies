using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Kills an allied unit to heal the caster for 125% of the unit's hit points and restores the caster's mana
/// by 10% of the unit's hit points.
/// </summary>
public sealed class DeathPact : Spell
{
  /// <summary>The radius within which the allied unit can be targeted.</summary>
  public float Radius { get; init; }

  /// <summary>The effect applied to the targeted unit when it is killed.</summary>
  public string KillEffect { get; init; } = string.Empty;

  /// <summary>The effect applied to the caster when they are healed.</summary>
  public string HealEffect { get; init; } = string.Empty;

  /// <summary>The percentage of the target unit's health that is restored to the caster.</summary>
  public float HealthRestorePercent { get; init; } = 1.25f;

  /// <summary>The percentage of the target unit's health used to restore the caster's mana.</summary>
  public float ManaRestorePercent { get; init; } = 0.10f;

  /// <inheritdoc />
  public DeathPact(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var casterPlayer = caster.Owner;
    var casterPosition = caster.GetPosition();

    var unitsInRange = GlobalGroup
      .EnumUnitsInRange(casterPosition, Radius)
      .Where(x => x != null && x.Alive && IsValidTarget(x, casterPlayer))
      .ToList();

    if (unitsInRange.Count == 0)
    {
      return;
    }

    var targetUnit = unitsInRange
      .OrderByDescending(x => x.IsUnitType(unittype.Summoned))
      .ThenByDescending(x => x.IsUnitType(unittype.Summoned) ? x.Level : 0)
      .ThenBy(x => x.Level)
      .ThenBy(x => MathEx.GetDistanceBetweenPoints(x.GetPosition(), casterPosition))
      .FirstOrDefault();


    if (targetUnit == null || !targetUnit.Alive)
    {
      return;
    }

    var targetHealth = targetUnit.Life;
    if (targetHealth <= 0)
    {
      return;
    }

    targetUnit.Kill();

    var healthToRestore = targetHealth * HealthRestorePercent;
    caster.Heal(healthToRestore);

    if (!string.IsNullOrEmpty(HealEffect))
    {
      var casterEffect = effect.Create(HealEffect, caster, "origin");
      EffectSystem.Add(casterEffect);
    }

    var manaToRestore = targetHealth * ManaRestorePercent;
    var maxMana = caster.MaxMana;
    var currentMana = caster.Mana;

    caster.Mana = Math.Min(currentMana + manaToRestore, maxMana);

    EffectSystem.Add(effect.Create(KillEffect, targetUnit.GetPosition().X, targetUnit.GetPosition().Y));
  }

  private static bool IsValidTarget(unit target, player casterPlayer)
  {
    if (target == null)
    {
      return false;
    }

    return target.Alive &&
           target.Owner == casterPlayer &&
           !target.IsResistant() &&
           !target.IsUnitType(unittype.Structure) &&
           !target.IsUnitType(unittype.Ancient) &&
           !target.IsUnitType(unittype.Mechanical) &&
           !target.IsUnitType(unittype.MagicImmune);
  }
}
