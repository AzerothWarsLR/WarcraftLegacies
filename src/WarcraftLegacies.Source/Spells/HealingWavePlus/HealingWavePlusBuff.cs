using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Spells.HealingWavePlus;

/// <summary>
/// A buff applied to the last healed unit by Healing Wave, adding a visual indicator.
/// </summary>
public sealed class HealingWaveBuff : BoundBuff
{
  /// <summary>
  /// Constructor of the `HealingWaveBuff`.
  /// </summary>
  /// <param name="caster">The unit who cast the spell.</param>
  /// <param name="target">The target unit receiving the buff.</param>
  /// <param name="duration">The duration for which the buff stays active.</param>
  public HealingWaveBuff(unit caster, unit target, float duration)
    : base(caster, target)
  {
    EffectString = @"Abilities\Spells\Items\HealingSalve\HealingSalveTarget.mdl";
    EffectAttachmentPoint = "origin";
    Duration = duration;


    BindAura(ABILITY_HWP2_ENERGY_WAVE_BUFF_APPLICATOR, BUFF_HWP3_ENERGY_WAVE);
  }
}
