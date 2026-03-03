using System.Linq;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Deals damage and/or casts a dummy spell at each unit in the area.
/// </summary>
public sealed class MassAnySpell : Spell
{
  /// <summary>
  /// The ID of the single-target ability to cast on units in the area.
  /// </summary>
  public int DummyAbilityId { get; init; }

  /// <summary>
  /// The order string used to cast <see cref="DummyAbilityId"/>.
  /// </summary>
  public int DummyAbilityOrderId { get; init; }

  /// <summary>
  /// The radius in which units are affected.
  /// </summary>
  public float Radius { get; init; }

  /// <summary>
  /// A filter that units must pass to be considered eligible targets for the spell.
  /// </summary>
  public required DummyCasterManager.CastFilter CastFilter { get; init; }

  /// <summary>
  /// What kind of thing the spell targets.
  /// </summary>
  public SpellTargetType TargetType { get; init; } = SpellTargetType.None;

  /// <summary>
  /// What kind of dummy caster is used to cast the spell.
  /// <remarks>Use <see cref="DummyCasterType.AbilitySpecific"/> if the spell being cast will break if it is removed from
  /// the dummy unit before its effect takes place, e.g. Death Coil.</remarks>
  /// <remarks>Currently does not support <see cref="DummyCasterType.LongLived"/>.</remarks>
  /// </summary>
  public DummyCasterType DummyCasterType { get; init; } = DummyCasterType.Global;

  /// <summary>
  /// The chance of each unit in the area being affected.
  /// </summary>
  public float Chance { get; init; } = 1.0f;

  /// <summary>
  /// Where each dummy spell should be cast from.
  /// <remarks>Defaults to <see cref="DummyCastOriginType.Target"/>, which causes each spell to cast from each target's positions.</remarks>
  /// </summary>
  public DummyCastOriginType DummyCastOriginType { get; init; } = DummyCastOriginType.Target;

  /// <summary>
  /// How much damage the spell does to each affected unit, ignoring any levels.
  /// </summary>
  public float DamageBase { get; init; }

  /// <summary>
  /// How much damage the spell does to each affected unit per spell level.
  /// </summary>
  public float DamageLevel { get; init; }

  /// <summary>
  /// Initializes a new instance of the <see cref="MassAnySpell"/> class.
  /// </summary>
  /// <inheritdoc />
  public MassAnySpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var center = TargetType == SpellTargetType.None ? new Point(caster.X, caster.Y) : targetPoint;
    var units = GlobalGroup.EnumUnitsInRange(center.X, center.Y, Radius).Where(u => CastFilter(caster, u));

    var filteredUnits = units.Where(u => GetRandomReal(0, 1) <= Chance).ToList();

    var damage = DamageBase + DamageLevel * GetAbilityLevel(caster);
    foreach (var unit in filteredUnits)
    {
      if (damage > 0 && unit.IsEnemyTo(caster.Owner))
      {
        caster.DealDamage(unit, damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      }
    }

    if (DummyCasterType == DummyCasterType.Global)
    {
      DummyCasterManager.GetGlobalDummyCaster()
        .CastOnUnitsInCircle(
          caster,
          DummyAbilityId,
          DummyAbilityOrderId,
          GetAbilityLevel(caster),
          center,
          Radius,
          (c, t) => filteredUnits.Contains(t),
          DummyCastOriginType
        );
    }
    else if (DummyCasterType == DummyCasterType.AbilitySpecific)
    {
      DummyCasterManager.GetAbilitySpecificDummyCaster(DummyAbilityId, DummyAbilityOrderId)
        .CastOnUnitsInCircle(
          caster,
          GetAbilityLevel(caster),
          center,
          Radius,
          (c, t) => filteredUnits.Contains(t),
          DummyCastOriginType
        );
    }
  }
}
