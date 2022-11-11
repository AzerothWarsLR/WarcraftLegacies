using WCSharp.Buffs;
using static War3Api.Common;

namespace MacroTools.Buffs
{
  public sealed class SpellResistanceAuraTarget : AuraBoundBuff
  {
    public SpellResistanceAuraTarget(unit caster, unit target) : base(caster, target)
    {
      Bind(FourCC("AAAA"), FourCC("BBBB"));
      EffectString = @"Abilities\Spells\Other\GeneralAuraTarget\GeneralAuraTarget.mdl";
    }

    public override void OnApply()
    {
      UnitAddAbility(Target, FourCC("Alsr"));
    }

    public override void OnExpire()
    {
      UnitRemoveAbility(Target, FourCC("Alsr"));
    }
  }
}