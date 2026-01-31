using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// Causes the unit to summon a number of units whenever they cast a spell.
/// </summary>
public sealed class SummonUnitOnCast : UnitTrait, IEffectOnSpellEffect
{
  private readonly int _abilityTypeId;

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
  public LeveledAbilityField<int> SummonCount { get; init; } = new();

  /// <summary>
  /// The special effect that appears when the ability triggers.
  /// </summary>
  public string SpecialEffectPath { get; init; } = "";

  /// <summary>
  /// The percentage chance that the effect will occur on cast.
  /// </summary>
  public float ProcChance { get; init; }

  /// <summary>
  /// Only spells in this list willl summon a unit.
  /// </summary>
  public List<int> AbilityWhitelist { get; init; } = new();

  /// <inheritdoc />
  public SummonUnitOnCast(int abilityTypeId) => _abilityTypeId = abilityTypeId;

  /// <inheritdoc />
  public void OnSpellEffect()
  {
    var triggerUnit = @event.Unit;
    var abilityLevel = triggerUnit.GetAbilityLevel(_abilityTypeId);

    if (GetRandomReal(0, 1) > ProcChance)
    {
      return;
    }

    if (abilityLevel == 0 || !AbilityWhitelist.Contains(@event.SpellAbilityId))
    {
      return;
    }

    var summonCount = SummonCount.Base + SummonCount.PerLevel * abilityLevel;

    for (var i = 0; i < summonCount; i++)
    {
      var summonedUnit = unit.Create(triggerUnit.Owner, SummonUnitTypeId, triggerUnit.X, triggerUnit.Y, triggerUnit.Facing);
      summonedUnit.AddType(unittype.Summoned);
      summonedUnit.SetTimedLife(Duration);
      var summonedUnitX = summonedUnit.X;
      var summonedUnitY = summonedUnit.Y;
      EffectSystem.Add(effect.Create(SpecialEffectPath, summonedUnitX, summonedUnitY), 1);
    }
  }
}
