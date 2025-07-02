using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using WCSharp.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// Kills an allied unit to heal the caster for a percentage of the unit's hit points
  /// and restores the caster's mana by a percentage of the unit's hit points.
  /// </summary>
  public sealed class DeathPact : Spell
  {
    public float Radius { get; init; }
    public string KillEffect { get; init; } = string.Empty;
    public string HealEffect { get; init; } = string.Empty;
    public float HealthRestorePercent { get; init; } = 1.25f;
    public float ManaRestorePercent { get; init; } = 0.10f;

    public DeathPact(int id) : base(id) { }

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
          Console.WriteLine($"[DeathPact DEBUG] No valid units to sacrifice within radius {Radius}.");
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
          Console.WriteLine("[DeathPact DEBUG] Target unit is null or dead after selection.");
          return;
        }

        var targetHealth = GetUnitState(targetUnit, UNIT_STATE_LIFE);
        if (targetHealth <= 0)
        {
          Console.WriteLine($"[DeathPact DEBUG] Target unit '{targetUnit.GetName()}' has no health.");
          return;
        }

        Console.WriteLine($"[DeathPact DEBUG] Sacrificing unit '{targetUnit.GetName()}' with {targetHealth} HP.");

        targetUnit.Kill();

        var healthToRestore = targetHealth * HealthRestorePercent;
        caster.Heal(healthToRestore);

        Console.WriteLine($"[DeathPact DEBUG] Healed caster '{caster.GetName()}' for {healthToRestore} HP.");

        if (!string.IsNullOrEmpty(HealEffect))
        {
          var casterEffect = AddSpecialEffectTarget(HealEffect, caster, "origin");
          casterEffect.SetLifespan();
        }

        var manaToRestore = targetHealth * ManaRestorePercent;

        Delay.Add(() =>
        {
          var currentMana = GetUnitState(caster, UNIT_STATE_MANA);
          var maxMana = GetUnitState(caster, UNIT_STATE_MAX_MANA);
          var restoredMana = Math.Min(currentMana + manaToRestore, maxMana);
          SetUnitState(caster, UNIT_STATE_MANA, restoredMana);

          Console.WriteLine($"[DeathPact DEBUG] [DELAYED] Restored {manaToRestore} mana to caster '{caster.GetName()}'. " +
                            $"Current: {currentMana} → Final: {restoredMana}");

          GetExpiredTimer().Destroy();
        });

        AddSpecialEffect(KillEffect, targetUnit.GetPosition().X, targetUnit.GetPosition().Y).SetLifespan();
      }
      catch (Exception e)
      {
        Console.WriteLine($"[DeathPact ERROR] {e.Message}");
      }
    }

    private static bool IsValidTarget(unit target, player casterPlayer)
    {
      return target != null &&
             UnitAlive(target) &&
             target.OwningPlayer() == casterPlayer &&
             !target.IsResistant() &&
             !IsUnitType(target, UNIT_TYPE_STRUCTURE) &&
             !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
             !IsUnitType(target, UNIT_TYPE_MECHANICAL) &&
             !IsUnitType(target, UNIT_TYPE_MAGIC_IMMUNE);
    }
  }
}