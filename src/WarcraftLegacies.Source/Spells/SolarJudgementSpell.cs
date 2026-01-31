using System;
using MacroTools.Hazards;
using MacroTools.Libraries;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

public sealed class SolarJudgementSpell : Spell
{
  public float DamageBase { get; init; }
  public float DamageLevel { get; init; }
  public float Duration { get; init; }
  public float Period { get; init; }
  public float HealMultiplier { get; init; }
  public float UndeadDamageMultiplier { get; init; }
  public float Radius { get; init; }
  public float BoltRadius { get; init; }
  public string? EffectPath { get; init; }
  public string? EffectHealPath { get; init; }

  public SolarJudgementSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    try
    {
      var level = GetAbilityLevel(caster);
      var hazard = new SolarJudgementHazard(caster, targetPoint.X, targetPoint.Y)
      {
        Radius = Radius,
        BoltRadius = BoltRadius,
        BoltDamage = DamageBase + DamageLevel * level,
        UndeadDamageMultiplier = UndeadDamageMultiplier,
        HealMultiplier = HealMultiplier,
        EffectPath = EffectPath,
        EffectHealPath = EffectHealPath,
        Interval = Period,
        Duration = Duration,
      };
      HazardSystem.Add(hazard);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to cast {nameof(SolarJudgementSpell)}: {ex}");
    }
  }
}

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
    var unitsInRange = GlobalGroup.EnumUnitsInRange(x, y, BoltRadius);
    foreach (var target in unitsInRange)
    {
      if (CastFilters.IsTargetEnemyAndAlive(Caster, target))
      {
        var damageMult = target.IsUnitType(unittype.Undead) ? UndeadDamageMultiplier : 1f;
        Caster.DealDamage(target, BoltDamage * damageMult, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      }
      if (CastFilters.IsTargetAllyAndAlive(Caster, target))
      {
        target.Life += BoltDamage * HealMultiplier;
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
