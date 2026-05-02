using MacroTools.Extensions;
using WCSharp.Events;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells.GryphonOrbit;

public sealed class GryphonOrbitMissile : OrbitalMissile
{
  public float Damage { get; init; }
  public float Duration { get; set; }

  public GryphonOrbitMissile(unit caster, unit target) : base(caster, target)
  {
    EffectString = "war3mapImported\\WarGryphon_Yellow.mdl";
    EffectScale = 0.85f;
    Interval = PeriodicEvents.SYSTEM_INTERVAL;
    TargetImpactZ = 50;
  }

  public override void OnCollision(unit unit)
  {
    if (!unit.IsAllyTo(Caster.Owner) && unit.Alive && !unit.IsInvulnerable)
    {
      unit.TakeDamage(Caster, Damage);
    }
  }

  public override void OnPeriodic()
  {
    Duration -= PeriodicEvents.SYSTEM_INTERVAL;
    if (Duration <= 0)
    {
      Active = false;
    }
  }
}
