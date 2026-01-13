using MacroTools.Extensions;
using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.UnitTypeTraits;

/// <summary>
/// Causes the unit to deal additional damage to Resistant and Hero units.
/// </summary>
public sealed class Kingslayer : UnitTrait, IAppliesEffectOnDamage
{
  /// <summary>
  /// If set, the trait is only activated when this research is completed by the owning player.
  /// </summary>
  public int RequiredResearch { get; init; }

  public required float DamageBonus { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var damager = @event.DamageSource;
    if (!@event.IsAttack || !HasRequiredResearch(damager.Owner) || !@event.Unit.IsResistant())
    {
      return;
    }

    @event.Damage *= 1 + DamageBonus;
  }

  private bool HasRequiredResearch(player whichPlayer)
  {
    return RequiredResearch == 0 || whichPlayer.GetTechResearched(RequiredResearch, false) > 0;
  }
}
