using System.Collections.Generic;
using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.Shared.Spells;

/// <summary>Keeps a special effect attached to the unit for as long as it lives.</summary>
public sealed class AttachedEffect : UnitTrait, IEffectOnCreated, IEffectOnDeath
{
  private readonly Dictionary<unit, effect> _effects = new();

  public required string EffectPath { get; init; }
  public required string AttachmentPoint { get; init; }

  /// <inheritdoc />
  public void OnCreated(unit createdUnit) => _effects[createdUnit] = effect.Create(EffectPath, createdUnit, AttachmentPoint);

  /// <inheritdoc />
  public void OnDeath()
  {
    var dyingUnit = @event.Unit;
    if (!_effects.TryGetValue(dyingUnit, out var attached))
    {
      return;
    }

    attached.Dispose();
    _effects.Remove(dyingUnit);
  }
}
