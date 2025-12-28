using MacroTools.Spells;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells.AvengersShield;

public sealed class AvengersShieldSpell : Spell
{
  public float DamageBase { get; init; }
  public float DamageLevel { get; init; }
  public int MaxBounces { get; init; }
  public float BounceRadius { get; init; }
  public float SilenceDuration { get; init; }
  public float ProjectileSpeed { get; init; }
  public string ProjectileEffect { get; init; }
  public string ImpactEffect { get; init; }

  public AvengersShieldSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (target == null)
    {
      return;
    }

    var level = GetAbilityLevel(caster);

    var missile = new AvengersShieldProjectile(caster, target)
    {
      Damage = DamageBase + DamageLevel * level,
      RemainingBounces = MaxBounces,
      BounceRadius = BounceRadius,
      SilenceDuration = SilenceDuration,
      BounceDelay = 0.08f,
      DamageFalloff = 0.85f,
      Speed = ProjectileSpeed,
      EffectString = ProjectileEffect,
      ImpactEffect = ImpactEffect
    };

    MissileSystem.Add(missile);
  }
}
