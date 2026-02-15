using System.Linq;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Casts a Healing Wave dummy spell on a friendly unit near the target.
/// </summary>
public sealed class SplitHealingWave : Spell
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
  /// How close to the original target the secondary target must be.
  /// </summary>
  public required float Radius { get; init; }

  /// <inheritdoc />
  public SplitHealingWave(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit primaryTarget, Point targetPoint)
  {
    var casterOwner = caster.Owner;

    var secondaryTarget = GlobalGroup.EnumUnitsInRange(primaryTarget.X, primaryTarget.Y, Radius)
      .Where(x => IsValidTarget(casterOwner, x) && x != primaryTarget)
      .OrderBy(x => x.MaxLife - x.Life)
      .FirstOrDefault();

    if (secondaryTarget == null)
    {
      return;
    }

    DummyCasterManager
      .GetGlobalDummyCaster()
      .CastUnit(caster, DummyAbilityId, DummyAbilityOrderId, GetAbilityLevel(caster), secondaryTarget, DummyCastOriginType.Caster);
  }

  private static bool IsValidTarget(player casterOwner, unit target)
  {
    return target.Alive &&
           casterOwner.IsAlly(target.Owner) &&
           !target.IsUnitType(unittype.Structure) &&
           !target.IsUnitType(unittype.Ancient) &&
           !target.IsUnitType(unittype.Mechanical) &&
           !target.IsUnitType(unittype.MagicImmune);
  }
}
