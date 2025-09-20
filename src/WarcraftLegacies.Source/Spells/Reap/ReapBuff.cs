using MacroTools.Extensions;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Spells.Reap
{
  /// <summary>Gives the caster additional Strength.</summary>
  public sealed class ReapBuff : BoundBuff
  {
    /// <summary>The buff holder gains this much Strength.</summary>
    public int StrengthGain { get; init; }
    
    /// <inheritdoc />
    public ReapBuff(unit caster, string effectPath) : base(caster, caster)
    {
      EffectString = effectPath;
      EffectAttachmentPoint = "origin";
      EffectScale = 2;
      BindAura(ABILITY_ZB03_REAP_BUFF_APPLICATOR, BUFF_ZB04_REAP);
    }
    
    public override void OnApply()
    {
      Caster.AddHeroAttributes(StrengthGain, 0, 0);
      base.OnApply();
    }

    public override void OnDispose()
    {
      Caster.AddHeroAttributes(-StrengthGain, 0, 0);
      base.OnDispose();
    }
  }
}