using System;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Casts a dummy spell on a unit, point, or no target.
/// </summary>
public sealed class CastDummySpell : Spell
{
  /// <summary>
  /// The dummy spell to cast.
  /// </summary>
  public required int DummyAbilityId { get; init; }

  /// <summary>
  /// The order string used to cast the dummy spell.
  /// </summary>
  public required int DummyAbilityOrderId { get; init; }

  /// <summary>
  /// Who, or what, to cast the dummy spell on.
  /// </summary>
  public required SpellTargetType TargetType { get; init; }

  /// <summary>
  /// Where the dummy spell should be cast from.
  /// </summary>
  public required DummyCastOriginType OriginType { get; init; }

  /// <inheritdoc />
  public CastDummySpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    switch (TargetType)
    {
      case SpellTargetType.None:
        DummyCasterManager.GetGlobalDummyCaster().CastNoTarget(caster, DummyAbilityId, DummyAbilityOrderId, GetAbilityLevel(caster));
        break;
      case SpellTargetType.Unit:
        DummyCasterManager.GetGlobalDummyCaster().CastUnit(caster, DummyAbilityId, DummyAbilityOrderId, GetAbilityLevel(caster), target, OriginType);
        break;
      case SpellTargetType.Point:
        DummyCasterManager.GetGlobalDummyCaster().CastPoint(caster.Owner, DummyAbilityId, DummyAbilityOrderId, GetAbilityLevel(caster), targetPoint);
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }
}
