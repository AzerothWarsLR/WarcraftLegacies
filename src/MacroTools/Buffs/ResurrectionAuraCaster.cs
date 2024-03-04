using WCSharp.Buffs;


namespace MacroTools.Buffs
{
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
      return IsUnitAlly(unit, CastingPlayer) && !IsUnitType(unit, UNIT_TYPE_HERO) &&
             !IsUnitType(unit, UNIT_TYPE_SUMMONED) && !IsUnitType(unit, UNIT_TYPE_STRUCTURE);
    }
  }
}