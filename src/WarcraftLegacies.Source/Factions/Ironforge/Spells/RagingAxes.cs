using MacroTools.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>While toggled on, the unit's attacks deal more damage but hurt the unit too.</summary>
public sealed class RagingAxes : UnitTrait, IAppliesEffectOnDamage
{
  public required int BuffId { get; init; }
  public required float DamageMultiplier { get; init; }
  public required float RecoilFraction { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var attacker = @event.DamageSource;
    if (!@event.IsAttack || attacker.GetAbilityLevel(BuffId) == 0)
    {
      return;
    }

    @event.Damage *= DamageMultiplier;
    var recoil = @event.Damage * RecoilFraction;
    var remaining = attacker.Life - recoil;
    if (remaining < 1)
    {
      remaining = 1;
    }

    attacker.Life = remaining;
  }
}
