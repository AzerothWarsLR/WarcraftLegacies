using MacroTools.DummyCasters;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Stormwind.Spells;

/// <summary>Smashes a target for damage and slows its attacks and movement.</summary>
public sealed class HammerOfArathorSpell : Spell
{
  public required float Damage { get; init; }
  public required int SlowAbilityId { get; init; }
  public required string HitEffectPath { get; init; }

  public HammerOfArathorSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    effect.Create(HitEffectPath, target, "chest").Dispose();
    caster.DealDamage(target, Damage, false, false, attacktype.Hero, damagetype.Normal, weapontype.MetalHeavyBash);
    if (target.Alive)
    {
      DummyCasterManager.GetGlobalDummyCaster()
        .CastUnit(caster, SlowAbilityId, ORDER_SLOW, 1, target, DummyCastOriginType.Target);
    }
  }
}
