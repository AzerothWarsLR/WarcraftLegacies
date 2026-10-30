using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>The unit deals more damage to buildings and takes less damage from them.</summary>
public sealed class Fixation : UnitTrait, IAppliesEffectOnDamage, IEffectOnDamaged
{
  public required int AbilityTypeId { get; init; }
  public required float DamageBonus { get; init; }
  public required float DamageReduction { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    if (@event.DamageSource.GetAbilityLevel(AbilityTypeId) > 0 && @event.Unit.IsUnitType(unittype.Structure))
    {
      @event.Damage *= 1 + DamageBonus;
    }
  }

  /// <inheritdoc />
  public void OnDamaged()
  {
    if (@event.Unit.GetAbilityLevel(AbilityTypeId) > 0 && @event.DamageSource.IsUnitType(unittype.Structure))
    {
      @event.Damage *= 1 - DamageReduction;
    }
  }
}
