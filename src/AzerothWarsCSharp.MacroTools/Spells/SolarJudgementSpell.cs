using AzerothWarsCSharp.MacroTools.Hazards;
using AzerothWarsCSharp.MacroTools.SpellSystem;

namespace AzerothWarsCSharp.MacroTools.Spells
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
    public string EffectPath { get; init; }
    public string EffectHealPath { get; init; }
    
    public SolarJudgementSpell(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, widget target, float targetX, float targetY)
    {
      var level = GetAbilityLevel(caster);
      var hazard = new SolarJudgementHazard(null, caster, targetX, targetY)
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
      SpellSystem.HazardSystem.Add(hazard);
    }
  }
}