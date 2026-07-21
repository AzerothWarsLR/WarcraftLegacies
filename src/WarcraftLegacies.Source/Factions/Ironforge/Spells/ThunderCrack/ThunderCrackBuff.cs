using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells.ThunderCrack;

public sealed class ThunderCrackBuff : BoundBuff
{
  public required float ArmorReduction { private get; init; }

  public ThunderCrackBuff(unit caster, unit target) : base(caster, target)
  {
    BindAura(ABILITY_TP54_THUNDER_CRACK_BUFF_APPLICATOR, BUFF_TP53_THUNDER_CRACK);
  }

  public override void OnApply()
  {
    Target.Armor -= ArmorReduction;
  }

  public override void OnDispose()
  {
    Target.Armor += ArmorReduction;
  }
}
