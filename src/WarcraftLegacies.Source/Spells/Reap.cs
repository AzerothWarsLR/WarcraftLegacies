using System.Linq;
using MacroTools;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using static War3Api.Common;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>Kills nearby enemy units to grant the caster Strength for a limited time.</summary>
  public sealed class Reap : Spell
  {
    /// <summary>Number of units slain by the ability.</summary>
    public LeveledAbilityField<int> UnitsSlain { get; init; } = new();

    /// <summary>Strength gained per unit slain.</summary>
    public LeveledAbilityField<int> StrengthPerUnit { get; init; } = new();

    /// <summary>How far away units can be slain.</summary>
    public LeveledAbilityField<float> Radius { get; init; } = new();

    /// <summary>An effect that briefly appears at each enemy slain.</summary>
    public string KillEffect { get; init; } = string.Empty;

    /// <summary>An effect that gets applied to the caster while they are buffed.</summary>
    public string BuffEffect { get; init; } = string.Empty;
    
    /// <inheritdoc />
    public Reap(int id) : base(id)
    {
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var casterPosition = caster.GetPosition();
      var radius = Radius.Base + Radius.PerLevel * GetAbilityLevel(caster);
      var unitsSlain = UnitsSlain.Base + UnitsSlain.PerLevel * GetAbilityLevel(caster);
      var killTargets = CreateGroup()
        .EnumUnitsInRange(casterPosition, radius)
        .EmptyToList()
        .Where(x => IsValidTarget(x, caster))
        .OrderBy(GetUnitLevel)
        .Take(unitsSlain);

      foreach (var killTarget in killTargets)
      {
        killTarget.TakeDamage(caster, killTarget.GetHitPoints(), damageType: DAMAGE_TYPE_UNIVERSAL, attackType: ATTACK_TYPE_CHAOS);
        AddSpecialEffect(KillEffect, GetUnitX(killTarget), GetUnitY(killTarget))
          .SetLifespan();
      }
    }

    private static bool IsValidTarget(unit target, unit caster)
    {
      return false;
    }
  }
}