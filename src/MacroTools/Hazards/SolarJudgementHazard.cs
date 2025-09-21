using MacroTools.Libraries;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace MacroTools.Hazards;

public sealed class SolarJudgementHazard : Hazard
{
  public float Radius { get; init; }
  public float BoltRadius { get; init; }
  public float BoltDamage { get; init; }
  public float UndeadDamageMultiplier { get; init; } = 1;
  public float HealMultiplier { get; init; } = 1;
  public string? EffectPath { get; init; }
  public string? EffectHealPath { get; init; }

  private void DoBolt(float x, float y)
  {
    effect.Create(EffectPath, x, y).Dispose();
    var unitsInRange = GlobalGroup.EnumUnitsInRange(new Point(x, y), BoltRadius);
    foreach (var target in unitsInRange)
    {
      if (CastFilters.IsTargetEnemyAndAlive(Caster, target))
      {
        var damageMult = target.IsUnitType(unittype.Undead) ? UndeadDamageMultiplier : 1f;
        Caster.DealDamage(target, BoltDamage * damageMult, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      }
      if (CastFilters.IsTargetAllyAndAlive(Caster, target))
      {
        target.Life = target.Life + BoltDamage * HealMultiplier;
        effect.Create(EffectHealPath, target, "origin").Dispose();
      }
    }
  }

  private void DoRandomBolts()
  {
    var randomAngle = GetRandomReal(0, 2 * MathEx.Pi);
    var randomRadius = GetRandomReal(0, Radius);
    DoBolt(Position.X + randomRadius * Cos(randomAngle), Position.Y + randomRadius * Sin(randomAngle));
  }

  protected override void OnPeriodic() => DoRandomBolts();

  public SolarJudgementHazard(unit caster, float x, float y) : base(caster, x, y)
  {
  }
}
