using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Spells.ElementalConvergence;

/// <summary>
/// One of the three elements Thrall gathers above his own head while channeling <see cref="ElementalConvergenceSpell"/>.
/// Orbits continuously (rather than sitting still) because the missile models used for it only animate correctly
/// while in motion.
/// </summary>
public sealed class ElementalConvergenceOrb : OrbitalMissile
{
  public int EffectRed { get; init; }

  public int EffectGreen { get; init; }

  public int EffectBlue { get; init; }

  private bool _colored;

  public ElementalConvergenceOrb(unit caster) : base(caster, caster)
  {
  }

  public override void OnPeriodic()
  {
    if (!_colored && Effect != null)
    {
      Effect.SetColor(EffectRed, EffectGreen, EffectBlue);
      Effect.PlayAnimation(animtype.Stand);
      _colored = true;
    }
  }
}
