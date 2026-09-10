namespace WarcraftLegacies.Source.Factions.OrcishHorde.Spells.ElementalConvergence;

/// <summary>
/// Shared between the three <see cref="ElementalConvergenceMissile"/>s launched by a single cast, so that only
/// the first one to arrive at the target point triggers the explosion.
/// </summary>
public sealed class ElementalConvergenceImpactState
{
  public bool Exploded { get; set; }
}
