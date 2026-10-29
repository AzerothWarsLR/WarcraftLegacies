using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>When the unit takes damage at low health, reservists rush in to defend it.</summary>
public sealed class LastStand : UnitTrait, IEffectOnDamaged
{
  private readonly HashSet<unit> _onCooldown = new();

  public required int AbilityTypeId { get; init; }
  public required LeveledAbilityField<float> Cooldown { get; init; }
  public required float HealthThreshold { get; init; }
  public required int SummonCount { get; init; }
  public required int SummonUnitTypeId { get; init; }
  public required LeveledAbilityField<float> SummonDuration { get; init; }
  public required string SummonEffectPath { get; init; }

  /// <inheritdoc />
  public void OnDamaged()
  {
    var damaged = @event.Unit;
    var level = damaged.GetAbilityLevel(AbilityTypeId);
    if (level == 0 || @event.Damage <= 0 || !damaged.Alive || _onCooldown.Contains(damaged) ||
        !@event.DamageSource.IsEnemyTo(damaged.Owner))
    {
      return;
    }

    if ((damaged.Life - @event.Damage) / damaged.MaxLife >= HealthThreshold)
    {
      return;
    }

    _onCooldown.Add(damaged);
    for (var i = 0; i < SummonCount; i++)
    {
      var angle = damaged.Facing * MathEx.DegToRad + MathEx.Pi * (i + 0.5f) / SummonCount - MathEx.Pi / 2;
      var reservist = unit.Create(damaged.Owner, SummonUnitTypeId, damaged.X + 150 * Cos(angle), damaged.Y + 150 * Sin(angle),
        damaged.Facing);
      reservist.AddType(unittype.Summoned);
      reservist.SetTimedLife(SummonDuration.GetValue(level), FourCC("BTLF"));
      AddSpecialEffect(SummonEffectPath, reservist.X, reservist.Y).Dispose();
    }

    var cooldown = timer.Create();
    cooldown.Start(Cooldown.GetValue(level), false, () =>
    {
      cooldown.Dispose();
      _onCooldown.Remove(damaged);
    });
  }
}
