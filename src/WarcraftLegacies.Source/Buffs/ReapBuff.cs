using MacroTools.Extensions;
using WCSharp.Buffs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Buffs
{
  /// <summary>Gives the caster additional Strength.</summary>
  public sealed class ReapBuff : PassiveBuff
  {
    /// <summary>The buff holder gains this much Strength.</summary>
    public int StrengthGain { get; init; }
    
    /// <inheritdoc />
    public ReapBuff(unit caster, string effectPath) : base(caster, caster)
    {
      EffectString = effectPath;
      EffectAttachmentPoint = "origin";
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