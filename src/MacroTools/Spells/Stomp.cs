using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using MacroTools.Utils;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace MacroTools.Spells;

/// <summary>
/// Deals damage and casts a dummy spell at each unit in the area.
/// </summary>
public sealed class Stomp : Spell
{
  /// <summary>
  /// How much base damage to deal.
  /// </summary>
  public float DamageBase { get; init; } = 20;

  /// <summary>
  /// How much additional damage to deal per level.
  /// </summary>
  public float DamageLevel { get; init; } = 30;

  /// <summary>
  /// How long the stun should last.
  /// </summary>
  public int DurationBase { get; init; }

  /// <summary>
  /// How much extra duration the stun should get per level.
  /// </summary>
  public int DurationLevel { get; init; }

  /// <summary>
  /// The radius in which units are affected.
  /// </summary>
  public float Radius { get; init; } = 300;

  /// <summary>
  /// The ID of an ability that stuns units. Should be based on Storm Bolt.
  /// </summary>
  public int StunAbilityId { get; init; }

  /// <summary>
  /// The order ID for <see cref="StunAbilityId"/>.
  /// </summary>
  public int StunOrderId { get; init; }

  /// <summary>
  /// The special effect to create at the caster's position.
  /// </summary>
  public string SpecialEffect { get; init; } = "";

  private void DamageUnit(unit caster, widget target)
  {
    caster.DealDamage(target, DamageBase + DamageLevel * GetAbilityLevel(caster), false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
  }

  private void StunUnit(unit caster, unit target)
  {
    var duration = DurationBase + DurationLevel * GetAbilityLevel(caster);
    if (StunAbilityId == 0 || duration <= 0)
    {
      return;
    }

    DummyCaster.Cast(caster, StunAbilityId, StunOrderId, duration, target, DummyCastOriginType.Target);
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    EffectSystem.Add(effect.Create(SpecialEffect, caster.X, caster.Y));

    foreach (var enumUnit in GlobalGroup
               .EnumUnitsInRange(new Point(caster.X, caster.Y), Radius))
    {
      if (!CastFilters.IsTargetEnemyAndAlive(caster, enumUnit))
      {
        continue;
      }

      DamageUnit(caster, enumUnit);
      StunUnit(caster, enumUnit);
    }
  }

  /// <inheritdoc />
  public Stomp(int id) : base(id)
  {

  }
}
