using MacroTools.UnitTypeTraits;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.PassiveAbilities;

/// <summary>Causes the unit to be removed when it dies, instead of leaving a corpse.</summary>
public sealed class RemoveOnDeath : UnitTypeTrait, IEffectOnDeath
{
  /// <summary>An effect that appears when the unit dies.</summary>
  public string? DeathEffectPath { get; init; }

  /// <inheritdoc />
  public RemoveOnDeath(int unitTypeId) : base(unitTypeId)
  {
  }

  /// <inheritdoc />
  public void OnDeath()
  {
    var triggerUnit = @event.Unit;

    if (DeathEffectPath != null)
    {
      EffectSystem.Add(effect.Create(DeathEffectPath, triggerUnit.X, triggerUnit.Y));
    }

    triggerUnit.Dispose();
  }
}
