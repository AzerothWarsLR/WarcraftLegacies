using System;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Spells.HealingWavePlus
{
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
      EffectString = @"Abilities\Spells\Items\HealingSalve\HealingSalveTarget.mdl"; // Default visual effect
      EffectAttachmentPoint = "overhead"; // Attach to the target's overhead
      Duration = duration; // Use the provided dynamic duration

      // Bind the in-game buff to be applied visually/mechanically
      Bind(ABILITY_HWP2_ENERGY_WAVE_BUFF_APPLICATOR, BUFF_HWP3_ENERGY_WAVE);
    }

    /// <inheritdoc />
    public override void OnApply()
    {
      Console.WriteLine($"[HealingWaveBuff] Buff applied to {GetUnitName(Target)} by {GetUnitName(Caster)} for {Duration:F2} seconds.");
      base.OnApply();
    }

    /// <inheritdoc />
    public override void OnDispose()
    {
      Console.WriteLine($"[HealingWaveBuff] Buff on {GetUnitName(Target)} has expired.");
      base.OnDispose();
    }

    /// <inheritdoc />
    public override void OnTick()
    {
      Console.WriteLine($"[HealingWaveBuff] Buff is ticking on {GetUnitName(Target)}.");
      base.OnTick();
    }
  }
}