using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Buffs;

public sealed class SpellResistanceAuraTarget : AuraBoundBuff
{
  public SpellResistanceAuraTarget(unit caster, unit target) : base(caster, target)
  {
    BindAura(ABILITY_A0B1_SPELL_ABSORPTION_DALARAN_GOLEM, BUFF_BHAB_BRILLIANCE_AURA);
    EffectString = @"Abilities\Spells\Other\GeneralAuraTarget\GeneralAuraTarget.mdl";
  }

  public override void OnApply()
  {
    Target.AddAbility(ABILITY_A0B1_SPELL_ABSORPTION_DALARAN_GOLEM);
  }

  public override void OnExpire()
  {
    Target.RemoveAbility(ABILITY_A0B1_SPELL_ABSORPTION_DALARAN_GOLEM);
  }
}
