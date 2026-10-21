using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Spells;

/// <summary>Strikes a target for damage that grows with its missing health; a kill heals the caster.</summary>
public sealed class GrimTollSpell : Spell
{
  public required LeveledAbilityField<float> Damage { get; init; }
  public required float MissingHealthFraction { get; init; }
  public required float HealFraction { get; init; }
  public required string StrikeEffectPath { get; init; }
  public required string KillEffectPath { get; init; }

  public GrimTollSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var damage = Damage.GetValue(GetAbilityLevel(caster)) + (target.MaxLife - target.Life) * MissingHealthFraction;
    effect.Create(StrikeEffectPath, target, "chest").Dispose();
    caster.DealDamage(target, damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    if (target.Alive)
    {
      caster.QueueOrder(ORDER_ATTACK, target);
      return;
    }

    effect.Create(KillEffectPath, caster, "origin").Dispose();
    caster.Life += caster.MaxLife * HealFraction;
  }
}
