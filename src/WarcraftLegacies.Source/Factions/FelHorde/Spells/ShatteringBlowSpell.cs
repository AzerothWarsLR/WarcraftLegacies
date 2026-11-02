using MacroTools.DummyCasters;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FelHorde.Spells;

/// <summary>Strikes a target, damaging it and lowering its armor.</summary>
public sealed class ShatteringBlowSpell : Spell
{
  public required LeveledAbilityField<float> Damage { get; init; }
  public required int ArmorAbilityId { get; init; }
  public required string HitEffectPath { get; init; }

  public ShatteringBlowSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    effect.Create(HitEffectPath, target, "chest").Dispose();
    caster.DealDamage(target, Damage.GetValue(level), false, false, attacktype.Hero, damagetype.Normal, weapontype.MetalHeavyBash);
    DummyCasterManager.GetGlobalDummyCaster().CastUnit(caster, ArmorAbilityId, ORDER_FAERIE_FIRE, level, target, DummyCastOriginType.Caster);
  }
}
