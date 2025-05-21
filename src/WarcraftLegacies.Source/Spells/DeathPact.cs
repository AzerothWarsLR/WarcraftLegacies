﻿using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
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
        try
        {
            var casterPlayer = caster.OwningPlayer();
            var casterPosition = caster.GetPosition();

          
            var unitsInRange = GlobalGroup
                .EnumUnitsInRange(casterPosition, Radius)
                .Where(x => x != null && UnitAlive(x) && IsValidTarget(x, casterPlayer))
                .ToList();
            
            if (unitsInRange.Count == 0)
            {
                return;
            }
            
            var targetUnit = unitsInRange
                .OrderByDescending(x => IsUnitType(x, UNIT_TYPE_SUMMONED)) 
                .ThenByDescending(x => IsUnitType(x, UNIT_TYPE_SUMMONED) ? GetUnitLevel(x) : 0)
                .ThenBy(x => GetUnitLevel(x))
                .ThenBy(x => MathEx.GetDistanceBetweenPoints(x.GetPosition(), casterPosition))
                .FirstOrDefault();

          
            if (targetUnit == null || !UnitAlive(targetUnit))
            {
                return;
            }

            var targetHealth = GetUnitState(targetUnit, UNIT_STATE_LIFE);
            if (targetHealth <= 0)
            {
                return;
            }

          
            targetUnit.Kill();

            var healthToRestore = targetHealth * HealthRestorePercent;
            caster.Heal(healthToRestore);

            if (!string.IsNullOrEmpty(HealEffect))
            {
                var casterEffect = AddSpecialEffectTarget(HealEffect, caster, "origin");
                casterEffect.SetLifespan();
            }

            var manaToRestore = targetHealth * ManaRestorePercent;
            var maxMana = GetUnitState(caster, UNIT_STATE_MAX_MANA);
            var currentMana = GetUnitState(caster, UNIT_STATE_MANA);

            SetUnitState(caster, UNIT_STATE_MANA, Math.Min(currentMana + manaToRestore, maxMana));

            
            AddSpecialEffect(KillEffect, targetUnit.GetPosition().X, targetUnit.GetPosition().Y)
                .SetLifespan();
        }
        catch (Exception)
        {}
    }

    private static bool IsValidTarget(unit target, player casterPlayer)
    {
        if (target == null)
            return false;

        return UnitAlive(target) &&
               target.OwningPlayer() == casterPlayer &&
               !target.IsResistant() &&
               !IsUnitType(target, UNIT_TYPE_STRUCTURE) &&
               !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
               !IsUnitType(target, UNIT_TYPE_MECHANICAL) &&
               !IsUnitType(target, UNIT_TYPE_MAGIC_IMMUNE);
    }
  }
}