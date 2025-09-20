using MacroTools.SpellSystem;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Spells.ExactJustice;

/// <summary>
/// Renders nearby friendly units invulnerable.
/// </summary>
public sealed class ExactJusticeAura : Aura<ExactJusticeBuff>
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ExactJusticeAura"/> class.
  /// </summary>
  /// <param name="caster"><inheritdoc /></param>
  public ExactJusticeAura(unit caster) : base(caster)
  {
  }

  /// <inheritdoc />
  protected override ExactJusticeBuff CreateAuraBuff(unit unit) => new(Caster, unit);

  /// <inheritdoc />
  protected override bool UnitFilter(unit unit) => CastFilters.IsTargetAllyAndAlive(Caster, unit);
}
