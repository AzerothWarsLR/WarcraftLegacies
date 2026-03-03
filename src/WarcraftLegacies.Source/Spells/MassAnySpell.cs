using System.Linq;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Effects;
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
  /// Where each dummy spell should be cast from.
  /// <remarks>Defaults to <see cref="DummyCastOriginType.Target"/>, which causes each spell to cast from each target's positions.</remarks>
  /// </summary>
  public DummyCastOriginType DummyCastOriginType { get; init; } = DummyCastOriginType.Target;

  /// <summary>
  /// How much damage the spell deals.
  /// </summary>
  public LeveledAbilityField<float>? Damage { get; init; }

  /// <summary>
  /// The special effect to create at the spell radius origin.
  /// </summary>
  public string? SpecialEffect { get; init; }

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

    if (SpecialEffect != null)
    {
      EffectSystem.Add(effect.Create(SpecialEffect, center.X, center.Y));
    }

    var units = GlobalGroup.EnumUnitsInRange(center.X, center.Y, Radius).Where(u => CastFilter(caster, u));

    var casterAbilityLevel = GetAbilityLevel(caster);
    var damage = 0f;
    if (Damage != null)
    {
      damage = Damage.Base + Damage.PerLevel * casterAbilityLevel;
    }

    var dummyCaster = DummyCasterManager.GetGlobalDummyCaster();
    foreach (var unit in units)
    {
      dummyCaster.CastUnit(caster, DummyAbilityId, DummyAbilityOrderId, casterAbilityLevel, unit, DummyCastOriginType);
      if (damage > 0)
      {
        caster.DealDamage(unit, damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      }
    }
  }
}
