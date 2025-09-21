using MacroTools.Extensions;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Effects;

namespace MacroTools.PassiveAbilities;

/// <summary>
/// Causes the unit to summon a unit upon death.
/// </summary>
public sealed class SummonUnitOnDeath : PassiveAbility, IEffectOnDeath
{
  /// <summary>
  /// How long the summoned unit should last.
  /// </summary>
  public float Duration { get; init; }

  /// <summary>
  /// The unit type to summon on death.
  /// </summary>
  public int SummonUnitTypeId { get; init; }

  /// <summary>
  /// How many units to summon.
  /// </summary>
  public int SummonCount { get; init; } = 1;

  /// <summary>
  /// The special effect that appears when the ability triggers.
  /// </summary>
  public string SpecialEffectPath { get; init; } = "";

  /// <summary>
  /// The player must have this research for the ability to take effect.
  /// </summary>
  public int RequiredResearch { get; init; }

  /// <inheritdoc />
  public SummonUnitOnDeath(int unitTypeId) : base(unitTypeId)
  {
  }

  /// <inheritdoc />
  public void OnDeath()
  {
    var triggerUnit = @event.Unit;
    if (triggerUnit.Owner.GetTechResearched(RequiredResearch, false) == 0 || triggerUnit.IsUnitType(unittype.Summoned))
    {
      return;
    }

    var pos = triggerUnit.GetPosition();
    for (var i = 0; i < SummonCount; i++)
    {
      var summonedUnit = unit.Create(triggerUnit.Owner, SummonUnitTypeId, pos.X, pos.Y, triggerUnit.Facing);
      summonedUnit.AddType(unittype.Summoned);
      summonedUnit.SetTimedLife(Duration);
    }

    EffectSystem.Add(effect.Create(SpecialEffectPath, pos.X, pos.Y), 1);
    triggerUnit.Dispose();
  }
}
