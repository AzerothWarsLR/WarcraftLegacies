using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.Reap;

/// <summary>Kills nearby enemy units to grant the caster Strength for a limited time.</summary>
public sealed class Reap : Spell
{
  /// <summary>Number of units slain by the ability.</summary>
  public LeveledAbilityField<int> UnitsSlain { get; init; } = new();

  /// <summary>Strength gained per unit slain.</summary>
  public LeveledAbilityField<int> StrengthPerUnit { get; init; } = new();

  /// <summary>Strength gained per unit slain.</summary>
  public LeveledAbilityField<int> StrengthPerUnitUpgraded { get; init; } = new();

  /// <summary>How far away units can be slain.</summary>
  public LeveledAbilityField<float> Radius { get; init; } = new();

  /// <summary>An effect that briefly appears at each enemy slain.</summary>
  public string KillEffect { get; init; } = string.Empty;

  /// <summary>An effect that gets applied to the caster while they are buffed.</summary>
  public string BuffEffect { get; init; } = string.Empty;

  /// <summary>How long the Strength buff lasts.</summary>
  public float Duration { get; init; }

  /// <summary>A caster matching this condition is considered to have the upgraded version of the spell.</summary>
  public Func<unit, bool> UpgradeCondition { get; init; } = _ => false;

  /// <inheritdoc />
  public Reap(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    try
    {
      var casterPosition = caster.GetPosition();
      var abilityLevel = GetAbilityLevel(caster);
      var radius = Radius.Base + Radius.PerLevel * abilityLevel;
      var unitsSlain = UnitsSlain.Base + UnitsSlain.PerLevel * abilityLevel;
      var killTargets = GlobalGroup
        .EnumUnitsInRange(casterPosition, radius)
        .Where(x => IsValidTarget(x, caster))
        .OrderBy(x => x.Level)
        .ThenBy(x => MathEx.GetDistanceBetweenPoints(casterPosition, x.GetPosition()))
        .Take(unitsSlain)
        .ToList();

      if (killTargets.Count == 0)
      {
        return;
      }

      foreach (var killTarget in killTargets)
      {
        killTarget.TakeDamage(caster, killTarget.Life, damageType: damagetype.Universal,
          attackType: attacktype.Chaos);
        EffectSystem.Add(effect.Create(KillEffect, killTarget.X, killTarget.Y));
      }

      var strengthGainPerTarget = UpgradeCondition(caster)
        ? StrengthPerUnitUpgraded.Base + StrengthPerUnitUpgraded.PerLevel * abilityLevel
        : StrengthPerUnit.Base + StrengthPerUnit.PerLevel * abilityLevel;

      BuffSystem.Add(new ReapBuff(caster, BuffEffect)
      {
        Active = true,
        Duration = Duration,
        IsBeneficial = true,
        StrengthGain = strengthGainPerTarget * killTargets.Count
      });
    }
    catch (Exception ex)
    {
      Logger.LogError($"Failed to cast {nameof(Reap)}: {ex}");
    }
  }

  private static bool IsValidTarget(unit target, unit caster) =>
    target.Alive &&
    !target.IsResistant() &&
    !target.IsUnitType(unittype.Structure) &&
    !target.IsUnitType(unittype.Ancient) &&
    !target.IsUnitType(unittype.Mechanical) &&
    !target.IsUnitType(unittype.MagicImmune) &&
    !caster.Owner.IsAlly(target.Owner);
}
