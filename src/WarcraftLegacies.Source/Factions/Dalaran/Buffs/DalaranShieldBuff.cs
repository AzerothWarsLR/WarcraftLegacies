using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Dalaran.Buffs;

public sealed class DalaranShieldBuff : BoundBuff
{
  public DalaranShieldBuff(unit caster, unit target) : base(caster, target)
  {
    BindAura(ABILITY_A0E1_DALARAN_SHIELD_BUFF_APPLICATOR, BUFF_B0DS_DALARAN_SHIELD);
  }
}
