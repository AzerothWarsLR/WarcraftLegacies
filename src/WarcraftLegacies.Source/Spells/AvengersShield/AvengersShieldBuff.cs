using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Spells.AvengersShield;

public sealed class AvengersShieldBuff : BoundBuff
{
  public AvengersShieldBuff(unit caster, unit target)
    : base(caster, target)
  {
    EffectString = @"Abilities\Spells\Other\Silence\SilenceTarget.mdl";
    EffectAttachmentPoint = "origin";

    BindAura(
      ABILITY_STED_AVENGERS_SHIELD_BUFF_APPLICATOR,
      BUFF_PBEN_AVENGER_S_SHIELD);
  }
}
