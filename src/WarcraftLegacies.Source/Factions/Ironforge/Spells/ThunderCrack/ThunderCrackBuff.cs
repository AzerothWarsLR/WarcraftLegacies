using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells.ThunderCrack;

public sealed class ThunderCrackBuff : BoundBuff
{
  public ThunderCrackBuff(unit caster, unit target, int level) : base(caster, target)
  {
    BindAura(GetApplicatorId(level), BUFF_TP53_THUNDER_CRACK);
  }

  private static int GetApplicatorId(int level)
  {
    if (level <= 1)
      return ABILITY_A004_THUNDER_CRACK_ARMOR_DEBUFF_APPLICATOR;
    if (level == 2)
      return ABILITY_A00O_THUNDER_CRACK_ARMOR_DEBUFF_APPLICATOR;
    if (level == 3)
      return ABILITY_A00R_THUNDER_CRACK_ARMOR_DEBUFF_APPLICATOR;
    return ABILITY_A011_THUNDER_CRACK_ARMOR_DEBUFF_APPLICATOR;
  }
}
