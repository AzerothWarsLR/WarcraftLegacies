using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells.GryphonOrbit;

public sealed class GryphonOrbitArmorBuff : BoundBuff
{
  public int ArmorBonus { get; init; }

  public GryphonOrbitArmorBuff(unit caster, string effectPath) : base(caster, caster)
  {
    EffectString = effectPath;
    EffectAttachmentPoint = "overhead";
    EffectScale = 1.0f;

    BindAura(ABILITY_TP45_STORMGUARD_BUFF_APPLICATOR, BUFF_TP43_STORMGUARD);
  }

}
