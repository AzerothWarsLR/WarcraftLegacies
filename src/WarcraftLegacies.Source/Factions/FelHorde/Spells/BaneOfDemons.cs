using MacroTools.Extensions;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Legion;

namespace WarcraftLegacies.Source.Factions.FelHorde.Spells;

/// <summary>Once the owner has a research, the unit deals more damage to demons and to the Burning Legion.</summary>
public sealed class BaneOfDemons : UnitTrait, IAppliesEffectOnDamage
{
  public required int RequiredResearch { get; init; }
  public required float DamageBonus { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    if (@event.DamageSource.Owner.GetTechResearched(RequiredResearch, false) == 0)
    {
      return;
    }

    var target = @event.Unit;
    if (target.Race == race.Demon || target.Owner.GetPlayerData().Faction is LegionFaction)
    {
      @event.Damage *= 1 + DamageBonus;
    }
  }
}
