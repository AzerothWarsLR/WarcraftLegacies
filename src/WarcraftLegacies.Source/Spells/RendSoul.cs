using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Automatically kills an allied unit to restore hit points and mana based on its current hit points,
/// prioritizing summoned units, and summons a temporary unit at the victim's position.
/// </summary>

public sealed class RendSoul : Spell
{
  public float HealthRestorePercent { get; init; }
  public float ManaRestorePercent { get; init; }
  public float Radius { get; init; }
  public int UnitTypeSummoned { get; init; }
  public string KillEffect { get; init; } = string.Empty;
  public string HealEffect { get; init; } = string.Empty;
  public int Duration { get; init; }

  /// <inheritdoc />
  public RendSoul(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var casterPlayer = caster.Owner;
    var casterPosition = caster.GetPosition();

    var unitsInRange = GlobalGroup
      .EnumUnitsInRange(casterPosition, Radius)
      .Where(x => IsValidTarget(x, casterPlayer))
      .ToList();

    if (unitsInRange.Count == 0)
    {
      Refund(caster);
      return;
    }
    var targetUnit = unitsInRange
      .OrderByDescending(x => x.IsUnitType(unittype.Summoned))
      .ThenByDescending(x => x.IsUnitType(unittype.Summoned) ? x.Level : 0)
      .ThenBy(x => x.Level)
      .ThenBy(x => MathEx.GetDistanceBetweenPoints(x.GetPosition(), casterPosition))
      .FirstOrDefault();
    if (targetUnit == null)
    {
      Refund(caster);
      return;
    }
    var targetHealth = targetUnit.Life;
    var targetX = targetUnit.X;
    var targetY = targetUnit.Y;

    targetUnit.Kill();

    caster.Life += targetHealth * HealthRestorePercent;

    if (!string.IsNullOrEmpty(HealEffect))
    {
      EffectSystem.Add(effect.Create(HealEffect, caster, "origin"));
    }
    Delay.Add(() =>
    {
      var manaToRestore = targetHealth * ManaRestorePercent;
      caster.Mana = Math.Min(caster.Mana + manaToRestore, caster.MaxMana);
    });

    if (!string.IsNullOrEmpty(KillEffect))
    {
      EffectSystem.Add(effect.Create(KillEffect, targetX, targetY));
    }

    var summonedUnit = unit.Create(caster.Owner, UnitTypeSummoned, targetX, targetY, caster.Facing);
    summonedUnit.SetTimedLife(Duration);
    summonedUnit.AddType(unittype.Summoned);
  }

  private static bool IsValidTarget(unit target, player casterPlayer)
  {
    return target.Alive &&
           target.Owner == casterPlayer &&
           !target.IsResistant() &&
           !target.IsUnitType(unittype.Structure) &&
           !target.IsUnitType(unittype.Ancient) &&
           !target.IsUnitType(unittype.Mechanical) &&
           !target.IsUnitType(unittype.MagicImmune);
  }
  private void Refund(unit caster)
  {
    //Delay to avoid mana overcap.
    Delay.Add(() =>
    {
      var ability = caster.GetAbility(Id);
      caster.Mana += ability.GetManaCost_amcs(caster.GetAbilityLevel(Id) - 1);
      caster.SetAbilityCooldownRemaining(Id, 0);
    });
  }
}
