using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Kill the target unit to restore hit points and mana based on its maximum hit points, and create a summoned unit at
/// its position.
/// </summary>
public sealed class RendSoul : Spell
{
  public float HitPointsPerTargetMaximumHitPoints { get; init; }

  public float ManaPointsPerTargetMaximumHitPoints { get; init; }

  public int UnitTypeSummoned { get; init; }

  public string EffectTarget { get; init; } = "";

  public string EffectCaster { get; init; } = "";

  public int Duration { get; init; }

  /// <inheritdoc />
  public RendSoul(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var targetMaximumHitPoints = target.MaxLife;
    var healthGained = targetMaximumHitPoints * HitPointsPerTargetMaximumHitPoints;
    var manaGained = targetMaximumHitPoints * ManaPointsPerTargetMaximumHitPoints;

    EffectSystem.Add(effect.Create(EffectCaster, caster.X, caster.Y));
    EffectSystem.Add(effect.Create(EffectTarget, target.X, target.Y));

    var targetPosition = target.GetPosition();
    target.Kill();

    caster.Heal(healthGained);
    caster.RestoreMana(manaGained);

    var summonedUnit = unit.Create(caster.Owner, UnitTypeSummoned, targetPosition.X, targetPosition.Y, caster.Facing);
    summonedUnit.SetTimedLife(Duration);
    summonedUnit.AddType(unittype.Summoned);
  }
}
