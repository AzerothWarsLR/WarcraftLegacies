using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Buffs;

public sealed class SpellResistanceAuraCaster : Aura<SpellResistanceAuraTarget>
{
  public SpellResistanceAuraCaster(unit caster) : base(caster)
  {
    StackBehaviour = StackBehaviour.Stack;
    EffectString = @"Abilities\Spells\Human\DevotionAura\DevotionAura.mdl";
    Radius = 300;
  }

  protected override SpellResistanceAuraTarget CreateAuraBuff(unit unit)
  {
    return new SpellResistanceAuraTarget(Caster, unit);
  }

  protected override bool UnitFilter(unit unit)
  {
    return unit.IsAllyTo(CastingPlayer);
  }
}
