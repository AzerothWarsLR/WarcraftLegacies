using MacroTools.Extensions;
using MacroTools.UnitTypeTraits;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// Causes the unit to create a unit upon death.
/// </summary>
public sealed class CreateUnitOnDeath : UnitTypeTrait, IEffectOnDeath
{
  /// <summary>
  /// How long the summoned unit should last.
  /// </summary>
  public float Duration { get; init; }

  /// <summary>
  /// The unit type to summon on death.
  /// </summary>
  public int CreateUnitTypeId { get; init; }

  /// <summary>
  /// How many units to summon.
  /// </summary>
  public int CreateCount { get; init; } = 1;

  /// <summary>
  /// The special effect that appears when the ability triggers.
  /// </summary>
  public string SpecialEffectPath { get; init; } = "";

  /// <summary>
  /// The player must have this research for the ability to take effect.
  /// </summary>
  public int RequiredResearch { get; init; }

  /// <inheritdoc />
  public void OnDeath()
  {
    var triggerUnit = @event.Unit;
    if (triggerUnit.Owner.GetTechResearched(RequiredResearch, false) == 0 || triggerUnit.IsUnitType(unittype.Summoned))
    {
      return;
    }

    var triggerUnitX = triggerUnit.X;
    var triggerUnitY = triggerUnit.Y;

    for (var i = 0; i < CreateCount; i++)
    {
      unit.Create(triggerUnit.Owner, CreateUnitTypeId, triggerUnitX, triggerUnitY, triggerUnit.Facing)
        .SetTimedLife(Duration);
    }

    EffectSystem.Add(effect.Create(SpecialEffectPath, triggerUnitX, triggerUnitY), 1);
    triggerUnit.Dispose();
  }
}
