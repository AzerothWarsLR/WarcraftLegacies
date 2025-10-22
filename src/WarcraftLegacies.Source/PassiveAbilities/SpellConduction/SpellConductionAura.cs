using MacroTools.Spells;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.PassiveAbilities.SpellConduction;

public sealed class SpellConductionAura : Aura<SpellConductionBuff>
{
  /// <summary>
  /// How much damage to redirect to the caster.
  /// </summary>
  public required float RedirectionPercentage { get; init; }

  /// <summary>
  /// Attack types that can be redirected.
  /// </summary>
  public required attacktype[] RedirectableAttackTypes { get; init; }

  /// <summary>
  /// Required for the aura to actually work.
  /// </summary>
  public required int RequiredResearch { get; init; }

  /// <inheritdoc />
  public SpellConductionAura(unit caster) : base(caster)
  {
  }

  /// <inheritdoc />
  protected override SpellConductionBuff CreateAuraBuff(unit unit)
  {
    return new SpellConductionBuff(Caster, unit)
    {
      RedirectionPercentage = RedirectionPercentage,
      RedirectableAttackTypes = RedirectableAttackTypes
    };
  }

  /// <inheritdoc />
  /// <inheritdoc />
  protected override bool UnitFilter(unit unit) =>
    Caster.Owner.GetTechResearched(RequiredResearch, false) > 0 &&
    CastFilters.IsTargetAllyAndAlive(Caster, unit);
}
