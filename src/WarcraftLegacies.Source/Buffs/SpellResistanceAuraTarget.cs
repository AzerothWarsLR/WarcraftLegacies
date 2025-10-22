using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Buffs;

public sealed class SpellResistanceAuraTarget : AuraBoundBuff
{
  public SpellResistanceAuraTarget(unit caster, unit target) : base(caster, target)
  {
    BindAura(FourCC("A0B1"), FourCC("Bhab"));
    EffectString = @"Abilities\Spells\Other\GeneralAuraTarget\GeneralAuraTarget.mdl";
  }

  public override void OnApply()
  {
    Target.AddAbility(FourCC("A0B1"));
  }

  public override void OnExpire()
  {
    Target.RemoveAbility(FourCC("A0B1"));
  }
}
