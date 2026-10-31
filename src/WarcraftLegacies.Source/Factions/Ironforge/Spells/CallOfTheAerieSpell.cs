using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Adds quest rewards to Call of the Aerie: an extra rider and a shorter cooldown.</summary>
public sealed class CallOfTheAerieSpell : Spell
{
  public required int RiderUnitTypeId { get; init; }
  public required float RiderDuration { get; init; }
  public required int ExtraRiderResearch { get; init; }
  public required int HalvedCooldownResearch { get; init; }
  public required string SummonEffectPath { get; init; }

  public CallOfTheAerieSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var owner = caster.Owner;
    if (owner.GetTechResearched(ExtraRiderResearch, false) > 0)
    {
      var rider = unit.Create(owner, RiderUnitTypeId, caster.X, caster.Y, caster.Facing);
      rider.ApplyTimedLife(0, RiderDuration);
      effect.Create(SummonEffectPath, rider.X, rider.Y).Dispose();
    }

    if (owner.GetTechResearched(HalvedCooldownResearch, false) == 0)
    {
      return;
    }

    var level = GetAbilityLevel(caster);
    var cooldownTimer = timer.Create();
    cooldownTimer.Start(0, false, () =>
    {
      cooldownTimer.Dispose();
      BlzStartUnitAbilityCooldown(caster, Id, BlzGetUnitAbilityCooldown(caster, Id, level - 1) / 2);
    });
  }
}
