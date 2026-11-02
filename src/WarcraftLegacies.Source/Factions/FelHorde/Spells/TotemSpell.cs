using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FelHorde.Spells;

/// <summary>Places a totem at the target point, bound to the caster through a <see cref="TotemicBond"/>.</summary>
public sealed class TotemSpell : Spell
{
  public required int TotemTypeId { get; init; }
  public required float Duration { get; init; }
  public required TotemicBond Bond { get; init; }

  public TotemSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var totem = unit.Create(caster.Owner, TotemTypeId, targetPoint.X, targetPoint.Y, 270);
    Bond.Place(caster, totem, Duration);
  }
}
