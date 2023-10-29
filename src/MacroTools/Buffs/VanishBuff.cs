using MacroTools;
using System.Collections.Generic;
using WCSharp.Buffs;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Buffs
{
  /// <summary>Gives the caster invisibiltiy and attack.</summary>
  public sealed class VanishBuff : BoundBuff
  {
    /// <summary>The buff holder gains attack and invisibility.</summary>

    /// <inheritdoc />
    public VanishBuff(unit caster, string effectPath, int bindApplicatorID, int bindBuffID) : base(caster, caster)
    {
      EffectString = effectPath;
      EffectAttachmentPoint = "origin";
      EffectScale = 0;
      Bind(bindApplicatorID, bindBuffID);
    }

    public override void OnApply()
    {
      base.OnApply();
    }

    public override void OnDispose()
    {
      base.OnDispose();
    }
  }
}