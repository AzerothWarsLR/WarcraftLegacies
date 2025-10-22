using MacroTools.UnitTypeTraits;

namespace WarcraftLegacies.Source.PassiveAbilities;

/// <summary>
/// Causes the unit to summon a unit upon death.
/// </summary>
public sealed class CreateCorpseOnDeath : UnitTypeTrait, IEffectOnDeath
{

  /// <summary>
  /// The unit type corpse to summon on death.
  /// </summary>
  public int CorpseUnitTypeId { get; init; }

  /// <summary>
  /// How many corpses to summon.
  /// </summary>
  public int CorpseCount { get; init; } = 1;

  /// <summary>
  /// The player must have this research for the ability to take effect.
  /// </summary>
  public int RequiredResearch { get; init; }

  /// <inheritdoc />
  public CreateCorpseOnDeath(int unitTypeId) : base(unitTypeId)
  {
  }

  /// <inheritdoc />
  public void OnDeath()
  {
    var triggerUnit = @event.Unit;
    if (RequiredResearch != 0 && (triggerUnit.Owner.GetTechResearched(RequiredResearch, false) == 0))
    {
      return;
    }

    for (var i = 0; i < CorpseCount; i++)
    {
      unit.CreateCorpse(triggerUnit.Owner, CorpseUnitTypeId, triggerUnit.X, triggerUnit.Y, triggerUnit.Facing);
    }

    triggerUnit.Dispose();
  }
}
