using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells.ThunderCrack;

public sealed class ThunderCrackBuff : BoundBuff
{
  public ThunderCrackBuff(unit caster, unit target, int level) : base(caster, target)
  {
    BindAura(ABILITY_A004_THUNDER_CRACK_ARMOR_DEBUFF_APPLICATOR, BUFF_TP53_THUNDER_CRACK, level);
  }
}
