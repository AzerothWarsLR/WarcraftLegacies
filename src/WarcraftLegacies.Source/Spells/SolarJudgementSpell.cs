using System;
using MacroTools.Hazards;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
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
}