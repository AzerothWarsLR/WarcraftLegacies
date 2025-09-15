using WCSharp.Buffs;

namespace MacroTools.Buffs
{
  public sealed class SpellResistanceAuraTarget : AuraBoundBuff
  {
    public SpellResistanceAuraTarget(unit caster, unit target) : base(caster, target)
    {
      Bind(FourCC("A0B1"), FourCC("Bhab"));
      EffectString = @"Abilities\Spells\Other\GeneralAuraTarget\GeneralAuraTarget.mdl";
    }

    public override void OnApply()
    {
      UnitAddAbility(Target, FourCC("A0B1"));
    }

    public override void OnExpire()
    {
      UnitRemoveAbility(Target, FourCC("A0B1"));
    }
  }
}