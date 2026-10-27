using MacroTools.Spells;
using MacroTools.UnitTraits;
using MacroTools.Utils;

namespace WarcraftLegacies.Source.Factions.Sunfury.Spells;

/// <summary>The unit's attacks drain mana from their target and restore mana to it and, less, to its owner's nearby units.</summary>
public sealed class SiphoningStrikes : UnitTrait, IAppliesEffectOnDamage
{
  public required int AbilityTypeId { get; init; }
  public required LeveledAbilityField<float> Mana { get; init; }
  public required LeveledAbilityField<float> AllyMana { get; init; }
  public required float Radius { get; init; }
  public required string DrainEffectPath { get; init; }
  public required string RestoreEffectPath { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var attacker = @event.DamageSource;
    var target = @event.Unit;
    var level = attacker.GetAbilityLevel(AbilityTypeId);
    if (!@event.IsAttack || level == 0 || !target.IsEnemyTo(attacker.Owner))
    {
      return;
    }

    var mana = Mana.GetValue(level);
    if (target.Mana > 0)
    {
      target.Mana -= mana > target.Mana ? target.Mana : mana;
      effect.Create(DrainEffectPath, target, "chest").Dispose();
    }

    attacker.Mana += mana;
    var allyMana = AllyMana.GetValue(level);
    foreach (var ally in GlobalGroup.EnumUnitsInRange(attacker.X, attacker.Y, Radius))
    {
      if (ally != attacker && ally.Alive && ally.Owner == attacker.Owner && ally.MaxMana > 0)
      {
        ally.Mana += allyMana;
      }
    }

    effect.Create(RestoreEffectPath, attacker, "origin").Dispose();
  }
}
