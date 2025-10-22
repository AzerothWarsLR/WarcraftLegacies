using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Buffs;

public sealed class ResurrectionAuraCaster : Aura<ResurrectionAuraTarget>
{
  private readonly float _resurrectionChance;

  public ResurrectionAuraCaster(unit caster, float resurrectionChance) : base(caster)
  {
    StackBehaviour = StackBehaviour.Stack;
    EffectString = @"Abilities\Spells\Human\DevotionAura\DevotionAura.mdl";
    Radius = 800;
    _resurrectionChance = resurrectionChance;
  }

  protected override ResurrectionAuraTarget CreateAuraBuff(unit unit)
  {
    return new ResurrectionAuraTarget(Caster, unit, _resurrectionChance);
  }

  protected override bool UnitFilter(unit unit)
  {
    return unit.IsAllyTo(CastingPlayer) && !unit.IsUnitType(unittype.Hero) &&
           !unit.IsUnitType(unittype.Summoned) && !unit.IsUnitType(unittype.Structure);
  }
}
